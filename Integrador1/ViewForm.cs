using Integrador1;
using Integrador1.Abstract;
using Integrador1.Entities;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm()
    {
        Application.ThreadException += (sender, e) => ManejarExcepcion("Excepción no controlada", e.Exception);
        AppDomain.CurrentDomain.UnhandledException += static (sender, e) => ManejarExcepcion("Error grave", e.ExceptionObject as Exception ?? new Exception("Unknown exception"));

        InitializeComponent();
        ConfigurarDelegados();
        ConfigurarEnlaces();
        CargarDatosIniciales();
    }

    private readonly ViewController _viewController = new();
    private readonly BindingSource _personaBindingSource = [];
    private readonly BindingSource _autosDePersonaBindingSource = [];
    private readonly BindingSource _autosDisponiblesBindingSource = [];
    private readonly BindingSource _autosAsignadosBindingSource = [];

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private static void MostrarMensaje(string mensaje, string titulo) => MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
    private static void MostrarError(string mensaje, Exception ex) => MessageBox.Show(ex.Message, mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
    private static bool MostrarConfirmacion(string mensaje, string titulo) => MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    private static void ManejarExcepcion(string mensaje, Exception ex)
    {
        Service.LogError(mensaje, ex);
        MostrarError(mensaje, ex);
    }

    private static void NuevoObjeto<T>(BindingSource source, T nuevoObjeto, Button boton)
    {
        source.Add(nuevoObjeto);
        source.MoveLast();
        boton.Enabled = false;
    }

    private static void GuardarEntidad<T>(BindingSource source,
                                          Action<T> actualizar,
                                          Action<T> crear,
                                          Action recargar,
                                          Button boton) where T : IEntity
    {
        try
        {
            if (source.Current is T entidad)
            {
                (entidad.Id == 0 ? crear : actualizar)(entidad);
                recargar();
            }
        }
        catch (Exception ex) { ManejarExcepcion("Error al guardar.", ex); }
        finally { boton.Enabled = true; }
    }

    private static void EliminarObjeto<T>(BindingSource source,
                                          Func<T, bool> eliminar,
                                          Action recargar)
    {
        if (MostrarConfirmacion("¿Está seguro que desea eliminar la entidad seleccionada?", "Confirmación"))
        {
            if (source.Current is T objetoSeleccionado)
            {
                eliminar(objetoSeleccionado);
                recargar();
            }
        }
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void CargarAutosAsignados() => _autosAsignadosBindingSource.DataSource = _viewController.AutosAsignados();

    private static void ConfigurarDelegados()
    {
        Auto.AutoEliminado += static mensaje => MostrarMensaje(mensaje, "Auto eliminado");
        Persona.PersonaEliminada += static mensaje => MostrarMensaje(mensaje, "Persona eliminada");
    }

    private void ConfigurarEnlaces()
    {
        try
        {
            var bindings = new (Control Control, string Property, BindingSource Source)[]
            {
                (IdPersonaTextBox, nameof(Persona.Id), _personaBindingSource),
                (DniTextBox, nameof(Persona.DNI), _personaBindingSource),
                (NombreTextBox, nameof(Persona.Nombre), _personaBindingSource),
                (ApellidoTextBox, nameof(Persona.Apellido), _personaBindingSource),
                (IdAutoTextBox, nameof(Auto.Id), _autosDisponiblesBindingSource),
                (PatenteTextBox, nameof(Auto.Patente), _autosDisponiblesBindingSource),
                (MarcaTextBox, nameof(Auto.Marca), _autosDisponiblesBindingSource),
                (ModeloTextBox, nameof(Auto.Modelo), _autosDisponiblesBindingSource),
                (AñoTextBox, nameof(Auto.Año), _autosDisponiblesBindingSource),
                (PrecioTextBox, nameof(Auto.Precio), _autosDisponiblesBindingSource)
            };

            foreach (var (control, property, source) in bindings)
            {
                control.DataBindings.Add("Text", source, property);
            }

            PersonasDataGridView.DataSource = _personaBindingSource;
            AutosDePersonaDataGridView.DataSource = _autosDePersonaBindingSource;
            AutosDisponiblesDataGridView.DataSource = _autosDisponiblesBindingSource;
            AutosAsignadosDataGridView.DataSource = _autosAsignadosBindingSource;
        }
        catch (Exception ex) { ManejarExcepcion("Error al configurar enlaces.", ex); }
    }

    private void CargarDatosIniciales()
    {
        CargarDatos(_personaBindingSource, _viewController.ObtenerPersonas);
        CargarDatos(_autosDisponiblesBindingSource, () => _viewController.ObtenerAutos().Where(auto => auto.DueñoId == 0).ToList());
        CargarAutosAsignados();
    }

    private static void CargarDatos<T>(BindingSource source, Func<List<T>> obtenerDatos)
    {
        try { source.DataSource = obtenerDatos(); }
        catch (Exception ex) { ManejarExcepcion("Error al cargar datos.", ex); }
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void CargarPersonas() => CargarDatos(_personaBindingSource, _viewController.ObtenerPersonas);
    private void NuevoPersonaButton_Click(object sender, EventArgs e) => NuevoObjeto(_personaBindingSource, new Persona(), NuevoPersonaButton);
    private void EliminarPersonaButton_Click(object sender, EventArgs e) => EliminarObjeto<Persona>(_personaBindingSource, _viewController.EliminarPersona, CargarPersonas);

    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (_personaBindingSource.Current is Persona personaSeleccionada)
            {
                //_autosDePersonaBindingSource.DataSource = personaSeleccionada.Autos;
                _autosDePersonaBindingSource.DataSource = personaSeleccionada.ListarAutos();
                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
        }
        catch (Exception ex) { ManejarExcepcion("Error al seleccionar una persona.", ex); }
    }

    private void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        GuardarEntidad<Persona>
        (
            _personaBindingSource,
            persona => _viewController.ActualizarPersona(persona),
            persona => _viewController.CrearPersona
            (
                persona.DNI ?? string.Empty,
                persona.Nombre ?? string.Empty,
                persona.Apellido ?? string.Empty
            ),
            CargarPersonas,
            NuevoPersonaButton
        );
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personaBindingSource.Current is Persona personaSeleccionada
            && _autosDisponiblesBindingSource.Current is Auto autoSeleccionado)
        {
            try
            {
                ViewController.AsignarAutoAPersona(personaSeleccionada, autoSeleccionado);

                _viewController.ActualizarPersona(personaSeleccionada);
                _viewController.ActualizarAuto(autoSeleccionado);

                _autosDePersonaBindingSource.DataSource = personaSeleccionada.Autos;
                _autosDePersonaBindingSource.ResetBindings(false);
                _autosDisponiblesBindingSource.Remove(autoSeleccionado);
                _autosDisponiblesBindingSource.ResetBindings(false);

                CargarAutosAsignados();

                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
            catch (Exception ex) { ManejarExcepcion("Error al asignar un auto a una persona.", ex); }
        }
    }

    private void QuitarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personaBindingSource.Current is Persona personaSeleccionada
            && _autosDePersonaBindingSource.Current is Auto autoSeleccionado)
        {
            try
            {
                ViewController.DesasignarAutoDePersona(personaSeleccionada, autoSeleccionado);

                _viewController.ActualizarPersona(personaSeleccionada);
                _viewController.ActualizarAuto(autoSeleccionado);

                _autosDePersonaBindingSource.DataSource = personaSeleccionada.Autos;
                _autosDePersonaBindingSource.ResetBindings(false); // Notificar a los controles enlazados
                _autosDisponiblesBindingSource.Add(autoSeleccionado); // Agregar el auto a la lista de disponibles
                _autosDisponiblesBindingSource.ResetBindings(false); // Notificar a los controles enlazados

                CargarAutosAsignados();

                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
            catch (Exception ex) { ManejarExcepcion("Error al quitar un auto de una persona.", ex); }
        }
    }

    //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

    private void CargarAutosDisponibles() => CargarDatos(_autosDisponiblesBindingSource, () => _viewController.ObtenerAutos().Where(auto => auto.DueñoId == 0).ToList());
    private void NuevoAutoButton_Click(object sender, EventArgs e) => NuevoObjeto(_autosDisponiblesBindingSource, new Auto(), NuevoAutoButton);
    private void EliminarAutoButton_Click(object sender, EventArgs e) => EliminarObjeto<Auto>(_autosDisponiblesBindingSource, _viewController.EliminarAuto, CargarAutosDisponibles);

    private void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        GuardarEntidad<Auto>
        (
            _autosDisponiblesBindingSource,
            auto => _viewController.ActualizarAuto(auto),
            auto => _viewController.CrearAuto
            (
                auto.Patente ?? string.Empty,
                auto.Marca ?? string.Empty,
                auto.Modelo ?? string.Empty,
                auto.Año,
                auto.Precio
            ),
            CargarAutosDisponibles,
            NuevoAutoButton
        );
    }
}
