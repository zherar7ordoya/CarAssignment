using Integrador.Domain.Entities;
using Integrador.Domain.Interfaces;
using Integrador.Infrastructure.Logging;
using Integrador.Infrastructure.Messaging;
using Integrador.Presentation.Presenters;
using Integrador.Shared.Exceptions;
using Integrador.Shared.Extensions;

using MediatR;

namespace Integrador;

partial class ViewForm
{
    private readonly IMediator _mediator;
    private readonly ViewPresenter _presenter;

    private readonly BindingSource _personasBS = [];
    private readonly BindingSource _autosPersonaBS = [];
    private readonly BindingSource _autosDisponiblesBS = [];
    private readonly BindingSource _autosAsignadosBS = [];

    readonly ILogger _logger = new Logger();
    readonly IMessenger _messenger = new Messenger();

    //private static void ConfigurarDelegados()
    //{
    //    Car.AutoEliminado += static mensaje => Messenger.MostrarMensaje(mensaje, "Auto eliminado");
    //    Person.PersonaEliminada += static mensaje => Messenger.MostrarMensaje(mensaje, "Persona eliminada");
    //}

    private void ConfigurarEnlaces()
    {
        try
        {
            ConfigurarBindingSources();
            ConfigurarDataGridView();
        }
        catch (Exception ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error al configurar los enlaces.");
        }
    }

    private void ConfigurarBindingSources()
    {
        var bindings = new (Control Control, string Property, BindingSource Source)[]
        {
            (IdPersonaTextBox, nameof(Person.Id), _personasBS),
            (DniTextBox, nameof(Person.DNI), _personasBS),
            (NombreTextBox, nameof(Person.Nombre), _personasBS),
            (ApellidoTextBox, nameof(Person.Apellido), _personasBS),
            (IdAutoTextBox, nameof(Car.Id), _autosDisponiblesBS),
            (PatenteTextBox, nameof(Car.Patente), _autosDisponiblesBS),
            (MarcaTextBox, nameof(Car.Marca), _autosDisponiblesBS),
            (ModeloTextBox, nameof(Car.Modelo), _autosDisponiblesBS),
            (AñoTextBox, nameof(Car.Año), _autosDisponiblesBS),
            (PrecioTextBox, nameof(Car.Precio), _autosDisponiblesBS)
        };

        ConfigurarBindingSources(bindings);
    }

    private static void ConfigurarBindingSources((Control Control, string Property, BindingSource Source)[] bindings)
    {
        foreach (var (control, property, source) in bindings)
        {
            control.DataBindings.Add("Text", source, property);
        }
    }

    private void ConfigurarDataGridView()
    {
        ConfigurarDataGridView(PersonasDGV, _personasBS,
        [
            ("Id", "ID"),
            ("DNI", "DNI"),
            ("Nombre", "Nombre"),
            ("Apellido", "Apellido")
        ]);

        ConfigurarDataGridView(AutosPersonaDGV, _autosPersonaBS,
        [
            ("Id", "ID"),
            ("Patente", "Patente"),
            ("Marca", "Marca"),
            ("Modelo", "Modelo"),
            ("Año", "Año"),
            ("Precio", "Precio")
        ]);

        ConfigurarDataGridView(AutosDisponiblesDGV, _autosDisponiblesBS,
        [
            ("Id", "ID"),
            ("Patente", "Patente"),
            ("Marca", "Marca"),
            ("Modelo", "Modelo"),
            ("Año", "Año"),
            ("Precio", "Precio")
        ]);

        ConfigurarDataGridView(AutosAsignadosDGV, _autosAsignadosBS,
        [
            ("Marca", "Marca"),
            ("Año", "Año"),
            ("Modelo", "Modelo"),
            ("Patente", "Patente"),
            ("Documento", "Documento"),
            ("Dueño", "Dueño")
        ]);
    }

    private static void ConfigurarDataGridView(DataGridView dataGridView, BindingSource bindingSource, (string Property, string Header)[] columns)
    {
        dataGridView.AutoGenerateColumns = false;
        dataGridView.DataSource = bindingSource;
        dataGridView.Columns.Clear();

        foreach (var (property, header) in columns)
        {
            dataGridView.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = property,
                HeaderText = header,
            });
        }
    }

    private async void LoadData()
    {
        _personasBS.DataSource = await _presenter.ListarPersonas();
        _autosDisponiblesBS.DataSource = await _presenter.ListarAutosDisponibles();
        _autosAsignadosBS.DataSource = await _presenter.ListarAutosAsignados();
    }

    private void OnAutoAsignado(Person persona, Car auto)
    {
        //ReloadData(persona, auto, fueAsignado: true);
        LoadData();
    }

    private void OnAutoDesasignado(Person persona, Car auto)
    {
        //ReloadData(persona, auto, fueAsignado: false);
        LoadData();
    }

    private async void ReloadData(Person persona,
                                  Car auto,
                                  bool fueAsignado)
    {
        _autosPersonaBS.DataSource = persona.Autos;
        _autosPersonaBS.ResetBindings(false);

        if (fueAsignado) { _autosDisponiblesBS.Remove(auto); }
        else { _autosDisponiblesBS.Add(auto); }

        _autosDisponiblesBS.ResetBindings(false);
        _autosAsignadosBS.DataSource = await _presenter.ListarAutosAsignados();

        ValorTotalAutosLabel.Text = persona.GetValorAutos().ToString("C");
        CantidadAutosTextBox.Text = persona.GetCantidadAutos().ToString();
    }
}
