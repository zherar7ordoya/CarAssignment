using Integrador.BusinessLogic.Commands;
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
            CargarDatosIniciales();
        }, "Error durante la inicialización del formulario.");
    }

    private readonly ViewController _controller = new();
    private readonly BindingSource _personasBS = [];
    private readonly BindingSource _autosDePersonaBS = [];
    private readonly BindingSource _autosDisponiblesBS = [];
    private readonly BindingSource _autosAsignadosBS = [];

    private static void ConfigurarDelegados()
    {
        Auto.AutoEliminado += static mensaje => Messenger.MostrarMensaje(mensaje, "Auto eliminado");
        Persona.PersonaEliminada += static mensaje => Messenger.MostrarMensaje(mensaje, "Persona eliminada");
    }

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

        foreach (var (control, property, source) in bindings)
        {
            control.DataBindings.Add("Text", source, property);
        }
    }

    private void ConfigurarDataGridViews()
    {
        ConfigurarDataGridView(PersonasDGV, _personasBS,
        [
            ("Id", "ID"),
            ("DNI", "DNI"),
            ("Nombre", "Nombre"),
            ("Apellido", "Apellido")
        ]);

        ConfigurarDataGridView(AutosDePersonaDGV, _autosDePersonaBS,
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

        _autosAsignadosBS.DataSource = _controller.AutosAsignados();

        ConfigurarDataGridView(AutosAsignadosDGV, _autosAsignadosBS,
        [
            ("Marca", "Marca"),
            ("Año", "Año"),
            ("Modelo", "Modelo"),
            ("Patente", "Patente"),
            ("Documento", "DNI Dueño"),
            ("Dueño", "Nombre Dueño")
        ]);
    }

    private static void ConfigurarDataGridView(DataGridView dataGridView,
                                               BindingSource bindingSource,
                                               (string Property, string Header)[] columns)
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

    private void CargarDatosIniciales()
    {
        ViewController.CargarDatos(_personasBS, _controller.ObtenerPersonas);
        ViewController.CargarDatos(_autosDisponiblesBS, _controller.AutosDisponibles);
        ViewController.CargarDatos(_autosAsignadosBS, _controller.AutosAsignados);
    }

    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona personaSeleccionada)
        {
            _autosDePersonaBS.DataSource = personaSeleccionada.Autos;
            ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
            CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
        }
    }

    private void NuevoPersonaButton_Click(object sender, EventArgs e)
    {
        NuevoPersonaCommand nuevo = new(_personasBS, NuevoPersonaButton);
        var (Success, ErrorMessage) = SafeExecutor.Execute(nuevo.Execute);

        if (!Success)
        {
            ExceptionHandler.HandleException("Error al crear una nueva persona.", new Exception(ErrorMessage));
        }
    }

    private void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona persona)
        {
            ICommand command = persona.Id == 0
            ? new CrearPersonaCommand(_controller,
                                      persona.DNI ?? string.Empty,
                                      persona.Nombre ?? string.Empty,
                                      persona.Apellido ?? string.Empty)
            : new ActualizarPersonaCommand(_controller, persona);

            var (Success, ErrorMessage) = SafeExecutor.Execute(command.Execute);

            if (Success)
            {
                ViewController.CargarDatos(_personasBS, _controller.ObtenerPersonas);
            }
            else
            {
                ExceptionHandler.HandleException("Error al guardar.", new Exception(ErrorMessage));
            }

            NuevoPersonaButton.Enabled = true;
        }
    }

    private void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona persona)
        {
            EliminarPersonaCommand eliminar = new(_controller, persona);
            var (Success, ErrorMessage) = SafeExecutor.Execute(eliminar.Execute);

            if (Success)
            {
                ViewController.CargarDatos(_personasBS, _controller.ObtenerPersonas);
                Messenger.MostrarMensaje("Persona eliminada correctamente.", "Éxito");
            }
            else
            {
                ExceptionHandler.HandleException("Error al eliminar la persona.", new Exception(ErrorMessage));
            }
        }
        else { Messenger.MostrarMensaje("No se ha seleccionado ninguna persona.", "Advertencia"); }
    }

    private void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona personaSeleccionada
            && _autosDisponiblesBS.Current is Auto autoSeleccionado)
        {
            var (Success, ErrorMessage) = _controller.AsignarAutoAPersona(personaSeleccionada, autoSeleccionado);

            if (Success)
            {
                _autosDePersonaBS.DataSource = personaSeleccionada.Autos;
                _autosDePersonaBS.ResetBindings(false);
                _autosDisponiblesBS.Remove(autoSeleccionado);
                _autosDisponiblesBS.ResetBindings(false);
                ViewController.CargarDatos(_autosAsignadosBS, _controller.AutosAsignados);
                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
            else
            {
                ExceptionHandler.HandleException("Error al asignar un auto a una persona.", new Exception(ErrorMessage));
            }
        }
    }

    private void QuitarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona personaSeleccionada
            && _autosDePersonaBS.Current is Auto autoSeleccionado)
        {
            var (Success, ErrorMessage) = _controller.QuitarAutoDePersona(personaSeleccionada, autoSeleccionado);

            if (Success)
            {
                _autosDePersonaBS.DataSource = personaSeleccionada.Autos;
                _autosDePersonaBS.ResetBindings(false);
                _autosDisponiblesBS.Add(autoSeleccionado);
                _autosDisponiblesBS.ResetBindings(false);
                ViewController.CargarDatos(_autosAsignadosBS, _controller.AutosAsignados);
                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
            else
            {
                ExceptionHandler.HandleException("Error al quitar un auto de una persona.", new Exception(ErrorMessage));
            }
        }
    }

    private void NuevoAutoButton_Click(object sender, EventArgs e)
    {
        NuevoAutoCommand nuevo = new(_autosDisponiblesBS, NuevoAutoButton);
        var (Success, ErrorMessage) = nuevo.Execute();

        if (!Success)
        {
            ExceptionHandler.HandleException("Error al crear un nuevo auto.", new Exception(ErrorMessage));
        }
    }

    private void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        if (_autosDisponiblesBS.Current is Auto auto)
        {
            ICommand command = auto.Id == 0
            ? new CrearAutoCommand(_controller,
                                      auto.Patente ?? string.Empty,
                                      auto.Marca ?? string.Empty,
                                      auto.Modelo ?? string.Empty,
                                      auto.Año,
                                      auto.Precio)
            : new ActualizarAutoCommand(_controller, auto);

            var (Success, ErrorMessage) = SafeExecutor.Execute(command.Execute);

            if (Success)
            {
                ViewController.CargarDatos(_autosDisponiblesBS, _controller.AutosDisponibles);
            }
            else
            {
                ExceptionHandler.HandleException("Error al guardar.", new Exception(ErrorMessage));
            }

            NuevoAutoButton.Enabled = true;
        }
    }

    private void EliminarAutoButton_Click(object sender, EventArgs e)
    {
        if (_autosDisponiblesBS.Current is Auto auto)
        {
            EliminarAutoCommand eliminar = new(_controller, auto);

            var (Success, ErrorMessage) = SafeExecutor.Execute(eliminar.Execute);

            if (Success)
            {
                ViewController.CargarDatos(_autosDisponiblesBS, _controller.AutosDisponibles);
                Messenger.MostrarMensaje("Auto eliminado correctamente.", "Éxito");
            }
            else
            {
                ExceptionHandler.HandleException("Error al eliminar el auto.", new Exception(ErrorMessage));
            }
        }
        else { Messenger.MostrarMensaje("No se ha seleccionado ningún auto.", "Advertencia"); }
    }
}
