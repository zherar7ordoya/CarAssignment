using Integrador.Adapters.Presentation.Presenters;
using Integrador.Entities;
using Integrador.Infrastructure;
using Integrador.Infrastructure.Extensions;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm()
    {
        Application.ThreadException += (sender, e) => ExceptionHandler.HandleException("Excepción no controlada", e.Exception);
        AppDomain.CurrentDomain.UnhandledException += static (sender, e) => ExceptionHandler.HandleException("Error grave", e.ExceptionObject as Exception ?? new Exception("Unknown exception"));

        ExceptionHandler.Execute(() =>
        {
            InitializeComponent();
            ConfigurarDelegados();
            ConfigurarEnlaces();
            LoadData();
        }, "Error durante la inicialización del formulario.");
    }

    private readonly BindingSource _personasBS = [];
    private readonly BindingSource _autosPersonaBS = [];
    private readonly BindingSource _autosDisponiblesBS = [];
    private readonly BindingSource _autosAsignadosBS = [];

    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona persona)
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
        if (_personasBS.Current is Persona persona)
        {
            ViewPresenter.GuardarPersona(persona, _personasBS, NuevoPersonaButton);
        }
    }

    private void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona persona)
        {
            ViewPresenter.EliminarPersona(persona, _personasBS);
        }
    }

    private void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona persona && _autosDisponiblesBS.Current is Auto auto)
        {
            ViewPresenter.AsignarAuto(persona, auto, OnAutoAsignado);
        }
    }

    private void DesasignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona persona && _autosPersonaBS.Current is Auto auto)
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
        if (_autosDisponiblesBS.Current is Auto auto)
        {
            ViewPresenter.GuardarAuto(auto, _autosDisponiblesBS, NuevoAutoButton);
        }
    }

    private void EliminarAutoButton_Click(object sender, EventArgs e)
    {
        if (_autosDisponiblesBS.Current is Auto auto)
        {
            ViewPresenter.EliminarAuto(auto, _autosDisponiblesBS);
        }
    }
}
