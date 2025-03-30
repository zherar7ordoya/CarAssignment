using Integrador.Domain.Entities;
using Integrador.Domain.Interfaces;
using Integrador.Infrastructure.Exceptions;
using Integrador.Infrastructure.Interfaces;
using Integrador.Presentation.Presenters;

namespace Integrador;

partial class ViewForm
{
    private readonly IMessenger _messenger;
    private readonly ICarFactory _carFactory;
    private readonly IPersonFactory _personFactory;
    private readonly IExceptionHandler _exceptionHandler;

    private readonly ViewPresenter _presenter;

    private readonly BindingSource _personasBS = [];
    private readonly BindingSource _autosPersonaBS = [];
    private readonly BindingSource _autosDisponiblesBS = [];
    private readonly BindingSource _autosAsignadosBS = [];

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
            _exceptionHandler.Handle(ex, "Error al configurar los enlaces.");
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
}
