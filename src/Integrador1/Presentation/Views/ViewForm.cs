using Integrador.Domain.Entities;
using Integrador.Infrastructure.Messaging;
using Integrador.Presentation.Presenters;
using Integrador.Shared.Exceptions;
using Integrador.Shared.Extensions;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm()
    {
        System.Windows.Forms.Application.ThreadException += (sender, e) => ExceptionHandler.HandleException("Excepción no controlada", e.Exception);
        AppDomain.CurrentDomain.UnhandledException += static (sender, e) => ExceptionHandler.HandleException("Error grave", e.ExceptionObject as Exception ?? new Exception("Unknown exception"));

        ExceptionHandler.Execute(() =>
        {
            InitializeComponent();
            ConfigurarDelegados();
            ConfigurarEnlaces();
            LoadData();
        }, "Error durante la inicialización del formulario.");
    }

    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (_personasBS.Current is Person persona)
        {
            _autosPersonaBS.DataSource = persona.Autos;
            ValorTotalAutosLabel.Text = persona.GetValorAutos().ToString("C");
            CantidadAutosTextBox.Text = persona.GetCantidadAutos().ToString();
        }
    }

    private void NuevoPersonaButton_Click(object sender, EventArgs e)
    {
        ViewPresenter.NuevoPersona(_personasBS, NuevoPersonaButton);
    }

    private void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Person persona)
        {
            ViewPresenter.GuardarPersona(persona, _personasBS, NuevoPersonaButton);
        }
    }

    private void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        var confirmacion = Messenger.Confirmar("¿Está seguro que desea eliminar la persona seleccionada?", "Eliminar persona");
        if (_personasBS.Current is Person persona && confirmacion)
        {
            ViewPresenter.EliminarPersona(persona, _personasBS);
        }
    }

    private void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Person persona && _autosDisponiblesBS.Current is Car auto)
        {
            ViewPresenter.AsignarAuto(persona, auto, OnAutoAsignado);
        }
    }

    private void DesasignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Person persona && _autosPersonaBS.Current is Car auto)
        {
            ViewPresenter.DesasignarAuto(persona, auto, OnAutoDesasignado);
        }
    }

    private void NuevoAutoButton_Click(object sender, EventArgs e)
    {
        ViewPresenter.NuevoAuto(_autosDisponiblesBS, NuevoAutoButton);
    }

    private void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        if (_autosDisponiblesBS.Current is Car auto)
        {
            ViewPresenter.GuardarAuto(auto, _autosDisponiblesBS, NuevoAutoButton);
        }
    }

    private void EliminarAutoButton_Click(object sender, EventArgs e)
    {
        var confirmacion = Messenger.Confirmar("¿Está seguro que desea eliminar el auto seleccionado?", "Eliminar auto");
        if (_autosDisponiblesBS.Current is Car auto && confirmacion)
        {
            ViewPresenter.EliminarAuto(auto, _autosDisponiblesBS);
        }
    }
}
