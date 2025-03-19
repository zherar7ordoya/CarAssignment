using Integrador.Abstract;
using Integrador.Model;
using Integrador.Service;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm()
    {
        Application.ThreadException += (sender, e) => ExceptionHandler.ManejarExcepcion("Excepción no controlada", e.Exception);
        AppDomain.CurrentDomain.UnhandledException += static (sender, e) => ExceptionHandler.ManejarExcepcion("Error grave", e.ExceptionObject as Exception ?? new Exception("Unknown exception"));
        InitializeComponent();
        //ConfigurarDelegados(); /* ES MOLESTO, SE DEJA PORQUE LO PIDE LA CONSIGNA. */
        ConfigurarEnlaces();
        CargarDatosIniciales();
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
        try
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

            ConfigurarDataGridView(PersonasDGV,
                                   _personasBS, 
                                   [
                                       ("Id", "ID"),
                                       ("DNI", "DNI"),
                                       ("Nombre", "Nombre"),
                                       ("Apellido", "Apellido")
                                   ]);

            ConfigurarDataGridView(AutosDePersonaDGV,
                                   _autosDePersonaBS,
                                   [
                                       ("Id", "ID"),
                                       ("Patente", "Patente"),
                                       ("Marca", "Marca"),
                                       ("Modelo", "Modelo"),
                                       ("Año", "Año"),
                                       ("Precio", "Precio")
                                   ]);

            ConfigurarDataGridView(AutosDisponiblesDGV,
                                   _autosDisponiblesBS,
                                   [
                                       ("Id", "ID"),
                                       ("Patente", "Patente"),
                                       ("Marca", "Marca"),
                                       ("Modelo", "Modelo"),
                                       ("Año", "Año"),
                                       ("Precio", "Precio")
                                   ]);

            var autosAsignados = _controller.AutosAsignados();
            _autosAsignadosBS.DataSource = autosAsignados;
            ConfigurarDataGridView(AutosAsignadosDGV,
                                   _autosAsignadosBS,
                                   [
                                       ("Marca", "Marca"),
                                       ("Año", "Año"),
                                       ("Modelo", "Modelo"),
                                       ("Patente", "Patente"),
                                       ("Documento", "DNI Dueño"),
                                       ("Dueño", "Nombre Dueño")
                                   ]);
        }
        catch (Exception ex) { ExceptionHandler.ManejarExcepcion("Error al configurar enlaces.", ex); }
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

    


    private void NuevoPersonaButton_Click(object sender, EventArgs e) => ViewController.NuevoObjeto(_personasBS, new Persona(), NuevoPersonaButton);
    private void EliminarPersonaButton_Click(object sender, EventArgs e) => ViewController.EliminarObjeto<Persona>(_personasBS, _controller.EliminarPersona, () => ViewController.CargarDatos(_personasBS, _controller.ObtenerPersonas));

    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (_personasBS.Current is Persona personaSeleccionada)
            {
                _autosDePersonaBS.DataSource = personaSeleccionada.Autos;
                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
        }
        catch (Exception ex) { ExceptionHandler.ManejarExcepcion("Error al seleccionar una persona.", ex); }
    }

    private void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        ViewController.GuardarEntidad<Persona>
        (
            _personasBS,
            persona => _controller.ActualizarPersona(persona),
            persona => _controller.CrearPersona
            (
                persona.DNI ?? string.Empty,
                persona.Nombre ?? string.Empty,
                persona.Apellido ?? string.Empty
            ),
            () => ViewController.CargarDatos(_personasBS, _controller.ObtenerPersonas),
            NuevoPersonaButton
        );
    }

    //private void AsignarAutoButton_Click(object sender, EventArgs e)
    //{
    //    if (_personasBS.Current is Persona personaSeleccionada
    //        && _autosDisponiblesBS.Current is Auto autoSeleccionado)
    //    {
    //        try
    //        {
    //            ViewController.AsignarAutoAPersona(personaSeleccionada, autoSeleccionado);
    //            _controller.ActualizarPersona(personaSeleccionada);
    //            _controller.ActualizarAuto(autoSeleccionado);
    //            _autosDePersonaBS.DataSource = personaSeleccionada.Autos;
    //            _autosDePersonaBS.ResetBindings(false);
    //            _autosDisponiblesBS.Remove(autoSeleccionado);
    //            _autosDisponiblesBS.ResetBindings(false);
    //            ViewController.CargarDatos(_autosAsignadosBS, _controller.AutosAsignados);
    //            ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
    //            CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
    //        }
    //        catch (Exception ex) { ExceptionHandler.ManejarExcepcion("Error al asignar un auto a una persona.", ex); }
    //    }
    //}

    //private void QuitarAutoButton_Click(object sender, EventArgs e)
    //{
    //    if (_personasBS.Current is Persona personaSeleccionada
    //        && _autosDePersonaBS.Current is Auto autoSeleccionado)
    //    {
    //        try
    //        {
    //            ViewController.DesasignarAutoDePersona(personaSeleccionada, autoSeleccionado);
    //            _controller.ActualizarPersona(personaSeleccionada);
    //            _controller.ActualizarAuto(autoSeleccionado);
    //            _autosDePersonaBS.DataSource = personaSeleccionada.Autos;
    //            _autosDePersonaBS.ResetBindings(false);
    //            _autosDisponiblesBS.Add(autoSeleccionado);
    //            _autosDisponiblesBS.ResetBindings(false);
    //            ViewController.CargarDatos(_autosAsignadosBS, _controller.AutosAsignados);
    //            ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
    //            CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
    //        }
    //        catch (Exception ex) { ExceptionHandler.ManejarExcepcion("Error al quitar un auto de una persona.", ex); }
    //    }
    //}

    private void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona personaSeleccionada
            && _autosDisponiblesBS.Current is Auto autoSeleccionado)
        {
            var resultado = _controller.AsignarAutoAPersona(personaSeleccionada, autoSeleccionado);

            if (resultado.Success)
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
                ExceptionHandler.ManejarExcepcion("Error al asignar un auto a una persona.", new Exception(resultado.ErrorMessage));
            }
        }
    }

    private void QuitarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona personaSeleccionada
            && _autosDePersonaBS.Current is Auto autoSeleccionado)
        {
            var resultado = _controller.QuitarAutoDePersona(personaSeleccionada, autoSeleccionado);

            if (resultado.Success)
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
                ExceptionHandler.ManejarExcepcion("Error al quitar un auto de una persona.", new Exception(resultado.ErrorMessage));
            }
        }
    }

    private void NuevoAutoButton_Click(object sender, EventArgs e) => ViewController.NuevoObjeto(_autosDisponiblesBS, new Auto(), NuevoAutoButton);
    private void EliminarAutoButton_Click(object sender, EventArgs e) => ViewController.EliminarObjeto<Auto>(_autosDisponiblesBS, _controller.EliminarAuto, () => ViewController.CargarDatos(_autosDisponiblesBS, _controller.AutosDisponibles));

    private void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        ViewController.GuardarEntidad<Auto>
        (
            _autosDisponiblesBS,
            auto => _controller.ActualizarAuto(auto),
            auto => _controller.CrearAuto
            (
                auto.Patente ?? string.Empty,
                auto.Marca ?? string.Empty,
                auto.Modelo ?? string.Empty,
                auto.Año,
                auto.Precio
            ),
            () => ViewController.CargarDatos(_autosDisponiblesBS, _controller.AutosDisponibles),
            NuevoAutoButton
        );
    }
}
