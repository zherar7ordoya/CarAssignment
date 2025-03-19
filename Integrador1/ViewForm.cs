using Integrador.Abstract;
using Integrador.Entities;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm()
    {
        Application.ThreadException += (sender, e) => ManejarExcepcion("Excepción no controlada", e.Exception);
        AppDomain.CurrentDomain.UnhandledException += static (sender, e) => ManejarExcepcion("Error grave", e.ExceptionObject as Exception ?? new Exception("Unknown exception"));
        InitializeComponent();
        //ConfigurarDelegados(); /* ES MOLESTO, SE DEJA PORQUE LO PIDE LA CONSIGNA. */
        ConfigurarEnlaces();
        CargarDatosIniciales();
    }

    private readonly ViewController _viewController = new();
    private readonly BindingSource _personasBS = [];
    private readonly BindingSource _autosDePersonaBS = [];
    private readonly BindingSource _autosDisponiblesBS = [];
    private readonly BindingSource _autosAsignadosBS = [];

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

            var autosAsignados = _viewController.AutosAsignados();
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
        catch (Exception ex) { ManejarExcepcion("Error al configurar enlaces.", ex); }
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
        CargarDatos(_personasBS, _viewController.ObtenerPersonas);
        CargarDatos(_autosDisponiblesBS, _viewController.AutosDisponibles);
        CargarDatos(_autosAsignadosBS, _viewController.AutosAsignados);
    }

    private static void CargarDatos<T>(BindingSource source, Func<List<T>> obtenerDatos)
    {
        try { source.DataSource = obtenerDatos(); }
        catch (Exception ex) { ManejarExcepcion("Error al cargar datos.", ex); }
    }


    private void NuevoPersonaButton_Click(object sender, EventArgs e) => NuevoObjeto(_personasBS, new Persona(), NuevoPersonaButton);
    private void EliminarPersonaButton_Click(object sender, EventArgs e) => EliminarObjeto<Persona>(_personasBS, _viewController.EliminarPersona, () => CargarDatos(_personasBS, _viewController.ObtenerPersonas));

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
        catch (Exception ex) { ManejarExcepcion("Error al seleccionar una persona.", ex); }
    }

    private void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        GuardarEntidad<Persona>
        (
            _personasBS,
            persona => _viewController.ActualizarPersona(persona),
            persona => _viewController.CrearPersona
            (
                persona.DNI ?? string.Empty,
                persona.Nombre ?? string.Empty,
                persona.Apellido ?? string.Empty
            ),
            () => CargarDatos(_personasBS, _viewController.ObtenerPersonas),
            NuevoPersonaButton
        );
    }

    private void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona personaSeleccionada
            && _autosDisponiblesBS.Current is Auto autoSeleccionado)
        {
            try
            {
                ViewController.AsignarAutoAPersona(personaSeleccionada, autoSeleccionado);
                _viewController.ActualizarPersona(personaSeleccionada);
                _viewController.ActualizarAuto(autoSeleccionado);
                _autosDePersonaBS.DataSource = personaSeleccionada.Autos;
                _autosDePersonaBS.ResetBindings(false);
                _autosDisponiblesBS.Remove(autoSeleccionado);
                _autosDisponiblesBS.ResetBindings(false);
                CargarDatos(_autosAsignadosBS, _viewController.AutosAsignados);
                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
            catch (Exception ex) { ManejarExcepcion("Error al asignar un auto a una persona.", ex); }
        }
    }

    private void QuitarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personasBS.Current is Persona personaSeleccionada
            && _autosDePersonaBS.Current is Auto autoSeleccionado)
        {
            try
            {
                ViewController.DesasignarAutoDePersona(personaSeleccionada, autoSeleccionado);
                _viewController.ActualizarPersona(personaSeleccionada);
                _viewController.ActualizarAuto(autoSeleccionado);
                _autosDePersonaBS.DataSource = personaSeleccionada.Autos;
                _autosDePersonaBS.ResetBindings(false);
                _autosDisponiblesBS.Add(autoSeleccionado);
                _autosDisponiblesBS.ResetBindings(false);
                CargarDatos(_autosAsignadosBS, _viewController.AutosAsignados);
                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
            catch (Exception ex) { ManejarExcepcion("Error al quitar un auto de una persona.", ex); }
        }
    }

    private void NuevoAutoButton_Click(object sender, EventArgs e) => NuevoObjeto(_autosDisponiblesBS, new Auto(), NuevoAutoButton);
    private void EliminarAutoButton_Click(object sender, EventArgs e) => EliminarObjeto<Auto>(_autosDisponiblesBS, _viewController.EliminarAuto, () => CargarDatos(_autosDisponiblesBS, _viewController.AutosDisponibles));

    private void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        GuardarEntidad<Auto>
        (
            _autosDisponiblesBS,
            auto => _viewController.ActualizarAuto(auto),
            auto => _viewController.CrearAuto
            (
                auto.Patente ?? string.Empty,
                auto.Marca ?? string.Empty,
                auto.Modelo ?? string.Empty,
                auto.Año,
                auto.Precio
            ),
            () => CargarDatos(_autosDisponiblesBS, _viewController.AutosDisponibles),
            NuevoAutoButton
        );
    }
}
