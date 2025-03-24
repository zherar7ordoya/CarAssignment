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
            ViewHelper.ConfigurarDelegados();
            ConfigurarEnlaces();
            CargarDatosIniciales();
        }, "Error durante la inicialización del formulario.");
    }

    private readonly BindingSource _personasBS = [];
    private readonly BindingSource _autosPersonaBS = [];
    private readonly BindingSource _autosDisponiblesBS = [];
    private readonly BindingSource _autosAsignadosBS = [];

    private void ConfigurarEnlaces()
    {
        SafeExecutor.Execute(() =>
        {
            ConfigurarBindingsDeControles();
            ConfigurarDataGridViews();
            CargarDatosIniciales();
        });
    }

    private void ConfigurarBindingsDeControles()
    {
        var bindings = new (Control Control, string Property, BindingSource Source)[]
        {
            (IdPersonaTextBox, nameof(Persona.Id), _personasBS),
            (DniTextBox, nameof(Persona.DNI), _personasBS),
            (NombreTextBox, nameof(Persona.Nombre), _personasBS),
            (ApellidoTextBox, nameof(Persona.Apellido), _personasBS),
            (IdAutoTextBox, nameof(Auto.Id), _autosDisponiblesBS),
            (PatenteTextBox, nameof(Auto.Patente), _autosDisponiblesBS),
            (MarcaTextBox, nameof(Auto.Marca), _autosDisponiblesBS),
            (ModeloTextBox, nameof(Auto.Modelo), _autosDisponiblesBS),
            (AñoTextBox, nameof(Auto.Año), _autosDisponiblesBS),
            (PrecioTextBox, nameof(Auto.Precio), _autosDisponiblesBS)
        };

        ViewHelper.ConfigurarBindingsDeControles(bindings);
    }

    private void ConfigurarDataGridViews()
    {
        ViewHelper.ConfigurarDataGridView(PersonasDGV, _personasBS,
        [
            ("Id", "ID"),
            ("DNI", "DNI"),
            ("Nombre", "Nombre"),
            ("Apellido", "Apellido")
        ]);

        ViewHelper.ConfigurarDataGridView(AutosPersonaDGV, _autosPersonaBS,
        [
            ("Id", "ID"),
            ("Patente", "Patente"),
            ("Marca", "Marca"),
            ("Modelo", "Modelo"),
            ("Año", "Año"),
            ("Precio", "Precio")
        ]);

        ViewHelper.ConfigurarDataGridView(AutosDisponiblesDGV, _autosDisponiblesBS,
        [
            ("Id", "ID"),
            ("Patente", "Patente"),
            ("Marca", "Marca"),
            ("Modelo", "Modelo"),
            ("Año", "Año"),
            ("Precio", "Precio")
        ]);

        ViewHelper.ConfigurarDataGridView(AutosAsignadosDGV, _autosAsignadosBS,
        [
            ("Marca", "Marca"),
            ("Año", "Año"),
            ("Modelo", "Modelo"),
            ("Patente", "Patente"),
            ("Documento", "Documento"),
            ("Dueño", "Dueño")
        ]);
    }

    private void CargarDatosIniciales()
    {
        _personasBS.DataSource = ViewController.ListarPersonas();
        _autosDisponiblesBS.DataSource = ViewController.ListarAutosDisponibles();
        _autosAsignadosBS.DataSource = ViewController.ListarAutosAsignados();
    }

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

    private void ActualizarVistaDespuesDeAsignacion(Persona persona,
                                                    Auto auto,
                                                    bool fueAsignado)
    {
        _autosPersonaBS.DataSource = persona.Autos;
        _autosPersonaBS.ResetBindings(false);

        if (fueAsignado) { _autosDisponiblesBS.Remove(auto); }
        else { _autosDisponiblesBS.Add(auto); }

        _autosDisponiblesBS.ResetBindings(false);
        _autosAsignadosBS.DataSource = ViewController.ListarAutosAsignados();

        ValorTotalAutosLabel.Text = persona.GetValorAutos().ToString("C");
        CantidadAutosTextBox.Text = persona.GetCantidadAutos().ToString();
    }

    private void OnAutoAsignado(Persona persona, Auto auto)
    {
        ActualizarVistaDespuesDeAsignacion(persona, auto, fueAsignado: true);
    }

    private void OnAutoDesasignado(Persona persona, Auto auto)
    {
        ActualizarVistaDespuesDeAsignacion(persona, auto, fueAsignado: false);
    }
}
