using Integrador.Domain.Entities;
using Integrador.Domain.Interfaces;
using Integrador.Infrastructure.Interfaces;
using Integrador.Presentation.Presenters;
using Integrador.Shared.Extensions;

using MediatR;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm(IMediator mediator,
                    IMessenger messenger,
                    ICarFactory carFactory,
                    IPersonFactory personFactory,
                    Infrastructure.Exceptions.IExceptionHandler exceptionHandler)
    {
        System.Windows.Forms.Application.ThreadException += (sender, e) => exceptionHandler.Handle(e.Exception);
        AppDomain.CurrentDomain.UnhandledException += (sender, e) => exceptionHandler.Handle(e.ExceptionObject as Exception ?? new Exception("Excepción al cargar el Form."));

        InitializeComponent();
        _messenger = messenger;
        _carFactory = carFactory;
        _personFactory = personFactory;
        _exceptionHandler = exceptionHandler;
        _presenter = new ViewPresenter(mediator);

        try
        {
            // ConfigurarDelegados();
            ConfigurarEnlaces();
            LoadData();
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, "Error durante la inicialización del formulario.");
        }
    }

    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (_personasBS.Current is Person persona)
        {
            _autosPersonaBS.DataSource = persona.Autos;
            _autosPersonaBS.ResetBindings(false); // Forzar actualización
            ValorTotalAutosLabel.Text = persona.GetValorAutos().ToString("C");
            CantidadAutosTextBox.Text = persona.GetCantidadAutos().ToString();
        }
    }

    private async void NuevoPersonaButton_Click(object sender, EventArgs e)
    {
        try
        {
            var nuevaPersona = _personFactory.CreateDefault(); // Datos por defecto
            _personasBS.Add(nuevaPersona);
            _personasBS.MoveLast();
            NuevoPersonaButton.Enabled = false;
        }
        catch (Exception ex)
        {
            await Task.Run(() => _exceptionHandler.Handle(ex));
        }
    }

    private async void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Person persona)
        {
            bool success = await _presenter.GuardarPersona(persona);
            if (success) LoadData();
            NuevoAutoButton.Enabled = true;
        }
    }

    private async void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        var confirmacion = _messenger.AskConfirmation("¿Está seguro que desea eliminar la persona seleccionada?", "Eliminar persona");

        if (_personasBS.Current is Person persona && confirmacion)
        {
            bool success = await _presenter.EliminarPersona(persona);
            if (success) LoadData();
        }
    }

    private async void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Person persona && _autosDisponiblesBS.Current is Car auto)
        {
            bool success = await _presenter.AsignarAuto(persona, auto);
            if (success) LoadData(); // Recargar todo
        }
    }

    private async void DesasignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Person persona && _autosPersonaBS.Current is Car auto)
        {
            bool success = await _presenter.DesasignarAuto(persona, auto);
            if (success) LoadData(); // Recargar todo
        }
    }

    private async void NuevoAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            var nuevoAuto = _carFactory.CreateDefault(); // Datos por defecto
            _autosDisponiblesBS.Add(nuevoAuto);
            _autosDisponiblesBS.MoveLast();
            NuevoAutoButton.Enabled = false;
        }
        catch (Exception ex)
        {
            await Task.Run(() => _exceptionHandler.Handle(ex));
        }
    }

    private async void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        if (_autosDisponiblesBS.Current is Car auto)
        {
            bool success = await _presenter.GuardarAuto(auto);
            if (success) LoadData();
            NuevoAutoButton.Enabled = true;
        }
    }

    private async void EliminarAutoButton_Click(object sender, EventArgs e)
    {
        var confirmacion = _messenger.AskConfirmation("¿Está seguro que desea eliminar el auto seleccionado?", "Eliminar auto");

        if (_autosDisponiblesBS.Current is Car auto && confirmacion)
        {
            bool success = await _presenter.EliminarAuto(auto);
            if (success) LoadData();
        }
    }
}
