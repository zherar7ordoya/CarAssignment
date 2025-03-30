using Integrador.Domain.Entities;
using Integrador.Presentation.Presenters;
using Integrador.Shared.Exceptions;
using Integrador.Shared.Extensions;

using MediatR;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm(IMediator mediator)
    {
        System.Windows.Forms.Application.ThreadException += (sender, e) => new ExceptionHandler(_logger, _messenger).Handle(e.Exception);
        AppDomain.CurrentDomain.UnhandledException += (sender, e) => new ExceptionHandler(_logger, _messenger).Handle(e.ExceptionObject as Exception ?? new Exception("Excepción al cargar el Form."));

        InitializeComponent();
        _mediator = mediator;
        _presenter = new ViewPresenter(mediator);

        try
        {
            // ConfigurarDelegados();
            ConfigurarEnlaces();
            LoadData();
        }
        catch (Exception ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, "Error durante la inicialización del formulario.");
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
        await _presenter.NuevoPersona(_personasBS, NuevoPersonaButton);
    }

    private async void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Person persona)
        {
           await _presenter.GuardarPersona(persona, _personasBS, NuevoPersonaButton);
        }
    }

    private async void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        var confirmacion = _messenger.AskConfirmation("¿Está seguro que desea eliminar la persona seleccionada?", "Eliminar persona");

        if (_personasBS.Current is Person persona && confirmacion)
        {
            await _presenter.EliminarPersona(persona, _personasBS);
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
        await _presenter.NuevoAuto(_autosDisponiblesBS, NuevoAutoButton);
    }

    private async void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        if (_autosDisponiblesBS.Current is Car auto)
        {
            await _presenter.GuardarAuto(auto, _autosDisponiblesBS, NuevoAutoButton);
        }
    }

    private async void EliminarAutoButton_Click(object sender, EventArgs e)
    {
        var confirmacion = _messenger.AskConfirmation("¿Está seguro que desea eliminar el auto seleccionado?", "Eliminar auto");
        if (_autosDisponiblesBS.Current is Car auto && confirmacion)
        {
            await _presenter.EliminarAuto(auto, _autosDisponiblesBS);
        }
    }
}
