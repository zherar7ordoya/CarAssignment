using Integrador.Core;
using Integrador.CrossCutting;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm()
    {
        Application.ThreadException += (sender, e) => ExceptionHandler.HandleException("Excepción no controlada", e.Exception);
        AppDomain.CurrentDomain.UnhandledException += static (sender, e) => ExceptionHandler.HandleException("Error grave", e.ExceptionObject as Exception ?? new Exception("Unknown exception"));

        SafeExecutor.Execute(() =>
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
        ViewController.NuevoPersona(_personasBS, NuevoPersonaButton);
    }

    private void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona persona)
        {
            ViewController.GuardarPersona(persona, _personasBS);
        }
    }

    private void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona persona)
        {
            ViewController.EliminarPersona(persona, _personasBS);
        }
    }

    private void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona persona && _autosDisponiblesBS.Current is Auto auto)
        {
            ViewController.AsignarAuto(persona, auto, OnAutoAsignado);
        }
    }

    private void DesasignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona persona && _autosPersonaBS.Current is Auto auto)
        {
            ViewController.DesasignarAuto(persona, auto, OnAutoDesasignado);
        }
    }

    private void NuevoAutoButton_Click(object sender, EventArgs e)
    {
        ViewController.NuevoAuto(_autosDisponiblesBS, NuevoAutoButton);
    }

    private void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        if (_autosDisponiblesBS.Current is Auto auto)
        {
            ViewController.GuardarAuto(auto, _autosDisponiblesBS);
        }
    }

    private void EliminarAutoButton_Click(object sender, EventArgs e)
    {
        if (_autosDisponiblesBS.Current is Auto auto)
        {
            ViewController.EliminarAuto(auto, _autosDisponiblesBS);
        }
    }
}
