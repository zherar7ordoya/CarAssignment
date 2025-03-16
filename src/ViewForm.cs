using Integrador.Entities;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm()
    {
        InitializeComponent();

        _viewController = new ViewController();

        ConfigurarEnlaces();

        Auto.AutoEliminado += mensaje =>
        MessageBox.Show(mensaje, "Objeto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        Persona.PersonaEliminada += mensaje =>
        MessageBox.Show(mensaje, "Objeto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);

        CargarDatosIniciales();
    }

    private readonly ViewController _viewController;
    private readonly BindingSource _personaBindingSource = [];
    private readonly BindingSource _autosDePersonaBindingSource = [];
    private readonly BindingSource _autosDisponiblesBindingSource = [];
    private readonly BindingSource _autosAsignadosBindingSource = [];


    // Métodos para enlaces.----------------------------------------------------
    private void ConfigurarEnlaces()
    {
        try
        {
            // Enlazar los TextBox a las propiedades de Persona
            IdPersonaTextBox.DataBindings.Add("Text", _personaBindingSource, "Id");
            DniTextBox.DataBindings.Add("Text", _personaBindingSource, "DNI");
            NombreTextBox.DataBindings.Add("Text", _personaBindingSource, "Nombre");
            ApellidoTextBox.DataBindings.Add("Text", _personaBindingSource, "Apellido");

            // Enlazar los TextBox a las propiedades de Auto
            IdAutoTextBox.DataBindings.Add("Text", _autosDisponiblesBindingSource, "Id");
            PatenteTextBox.DataBindings.Add("Text", _autosDisponiblesBindingSource, "Patente");
            MarcaTextBox.DataBindings.Add("Text", _autosDisponiblesBindingSource, "Marca");
            ModeloTextBox.DataBindings.Add("Text", _autosDisponiblesBindingSource, "Modelo");
            AñoTextBox.DataBindings.Add("Text", _autosDisponiblesBindingSource, "Año");
            PrecioTextBox.DataBindings.Add("Text", _autosDisponiblesBindingSource, "Precio");

            // Enlazar las grillas
            PersonasDataGridView.DataSource = _personaBindingSource;
            AutosDePersonaDataGridView.DataSource = _autosDePersonaBindingSource;
            AutosDisponiblesDataGridView.DataSource = _autosDisponiblesBindingSource;
            AutosAsignadosDataGridView.DataSource = _autosAsignadosBindingSource;
        }
        catch (Exception ex)
        {
            Service.LogError("Error al configurar enlaces.", ex);
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void CargarDatosIniciales()
    {
        CargarPersonas();
        CargarAutosDisponibles();
        CargarAutosAsignados();
    }

    // Métodos para Personas.---------------------------------------------------
    private void LimpiarPersona()
    {
        IdPersonaTextBox.Clear();
        DniTextBox.Clear();
        NombreTextBox.Clear();
        ApellidoTextBox.Clear();
    }

    private void CargarPersonas()
    {
        _personaBindingSource.DataSource = _viewController.ObtenerPersonas();
    }


    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (_personaBindingSource.Current is Persona personaSeleccionada)
            {
                _autosDePersonaBindingSource.DataSource = personaSeleccionada.Autos;
                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
        }
        catch (Exception ex)
        {
            Service.LogError("Error al seleccionar una persona.", ex);
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void NuevoPersonaButton_Click(object sender, EventArgs e)
    {
        // Crear un nuevo objeto Persona (usará los valores por defecto definidos en la clase)
        var nuevoPersona = new Persona();

        // Agregar el nuevo persona al BindingSource
        _personaBindingSource.Add(nuevoPersona);

        // Mover el foco al nuevo persona
        _personaBindingSource.MoveLast();

        // Limpiar los controles (opcional, si es necesario)
        LimpiarPersona();

        // Deshabilitar el botón "Nuevo"
        NuevoPersonaButton.Enabled = false;
    }

    private void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_personaBindingSource.Current is Persona personaSeleccionada)
            {
                personaSeleccionada.DNI = DniTextBox.Text;
                personaSeleccionada.Nombre = NombreTextBox.Text;
                personaSeleccionada.Apellido = ApellidoTextBox.Text;

                if (personaSeleccionada.Id == 0) // Nueva persona
                {
                    _viewController.CrearPersona(personaSeleccionada.DNI,
                                                 personaSeleccionada.Nombre,
                                                 personaSeleccionada.Apellido);
                }
                else // Persona existente
                {
                    _viewController.ActualizarPersona(personaSeleccionada);
                }

                LimpiarPersona();
                CargarPersonas();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            NuevoPersonaButton.Enabled = true;
        }
    }

    private void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("¿Está seguro que desea eliminar la persona seleccionada?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        if (_personaBindingSource.Current is Persona personaSeleccionada)
        {
            _viewController.EliminarPersona(personaSeleccionada);
            LimpiarPersona();
            CargarPersonas();
        }
    }


    // Métodos para Autos.------------------------------------------------------
    private void LimpiarAuto()
    {
        IdAutoTextBox.Clear();
        PatenteTextBox.Clear();
        MarcaTextBox.Clear();
        ModeloTextBox.Clear();
        AñoTextBox.Clear();
        PrecioTextBox.Clear();
        CantidadAutosTextBox.Clear();
    }

    private void CargarAutosDisponibles()
    {
        // Obtener todos los autos y filtrar los que no tienen dueño (DueñoId == 0)
        var autosDisponibles = _viewController.ObtenerAutos()
        .Where(a => a.DueñoId == 0)
        .ToList();

        // Asignar los autos filtrados al BindingSource
        _autosDisponiblesBindingSource.DataSource = autosDisponibles;

        // Notificar al DataGridView que los datos han cambiado
        //_autosDisponiblesBindingSource.ResetBindings(false);
    }

    private void AutosDisponiblesDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (_autosDisponiblesBindingSource.Current is Auto autoSeleccionado)
            {
                GuardarAutoButton.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            Service.LogError("Error al seleccionar un auto.", ex);
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void NuevoAutoButton_Click(object sender, EventArgs e)
    {
        // Crear un nuevo objeto Auto (usará los valores por defecto definidos en la clase)
        var nuevoAuto = new Auto();

        // Agregar el nuevo auto al BindingSource
        _autosDisponiblesBindingSource.Add(nuevoAuto);

        // Mover el foco al nuevo auto
        _autosDisponiblesBindingSource.MoveLast();

        // Limpiar los controles (opcional, si es necesario)
        LimpiarAuto();

        // Deshabilitar el botón "Nuevo"
        NuevoAutoButton.Enabled = false;
    }

    private void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_autosDisponiblesBindingSource.Current is Auto autoSeleccionado)
            {
                autoSeleccionado.Patente = PatenteTextBox.Text;
                autoSeleccionado.Marca = MarcaTextBox.Text;
                autoSeleccionado.Modelo = ModeloTextBox.Text;
                autoSeleccionado.Año = int.Parse(AñoTextBox.Text);
                autoSeleccionado.Precio = decimal.Parse(PrecioTextBox.Text);

                if (autoSeleccionado.Id == 0) // Nuevo auto
                {
                    _viewController.CrearAuto(autoSeleccionado.Patente,
                                              autoSeleccionado.Marca,
                                              autoSeleccionado.Modelo,
                                              autoSeleccionado.Año,
                                              autoSeleccionado.Precio);
                }
                else // Auto existente
                {
                    _viewController.ActualizarAuto(autoSeleccionado);
                }

                LimpiarAuto();
                CargarAutosDisponibles();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            NuevoAutoButton.Enabled = true;
        }
    }

    private void EliminarAutoButton_Click(object sender, EventArgs e)
    {
        if (MessageBox.Show("¿Está seguro que desea eliminar el auto seleccionado?",
                            "Confirmación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) != DialogResult.Yes)
        {
            return;
        }

        if (_autosDisponiblesBindingSource.Current is Auto autoSeleccionado)
        {
            _viewController.EliminarAuto(autoSeleccionado);
            LimpiarAuto();
            CargarAutosDisponibles();
        }
    }


    // Métodos para Asignaciones.-----------------------------------------------
    private void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personaBindingSource.Current is Persona personaSeleccionada
            && _autosDisponiblesBindingSource.Current is Auto autoSeleccionado)
        {
            try
            {
                // Asignar el auto a la persona
                ViewController.AsignarAutoAPersona(personaSeleccionada, autoSeleccionado);

                // Guardar los cambios en la base de datos
                _viewController.ActualizarPersona(personaSeleccionada);
                _viewController.ActualizarAuto(autoSeleccionado);

                // Actualizar los BindingSource
                _autosDePersonaBindingSource.DataSource = personaSeleccionada.Autos;
                _autosDePersonaBindingSource.ResetBindings(false); // Notificar a los controles enlazados

                _autosDisponiblesBindingSource.Remove(autoSeleccionado); // Eliminar el auto de la lista de disponibles
                _autosDisponiblesBindingSource.ResetBindings(false); // Notificar a los controles enlazados

                // Actualizar la lista de autos asignados
                CargarAutosAsignados();
                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void QuitarAutoButton_Click(object sender, EventArgs e)
    {
        if (_personaBindingSource.Current is Persona personaSeleccionada
            && _autosDePersonaBindingSource.Current is Auto autoSeleccionado)
        {
            try
            {
                // Desasignar el auto de la persona
                ViewController.DesasignarAutoDePersona(personaSeleccionada, autoSeleccionado);

                // Guardar los cambios en la base de datos
                _viewController.ActualizarPersona(personaSeleccionada);
                _viewController.ActualizarAuto(autoSeleccionado);

                // Actualizar los BindingSource
                _autosDePersonaBindingSource.DataSource = personaSeleccionada.Autos;
                _autosDePersonaBindingSource.ResetBindings(false); // Notificar a los controles enlazados

                _autosDisponiblesBindingSource.Add(autoSeleccionado); // Agregar el auto a la lista de disponibles
                _autosDisponiblesBindingSource.ResetBindings(false); // Notificar a los controles enlazados

                // Actualizar la lista de autos asignados
                CargarAutosAsignados();
                ValorTotalAutosLabel.Text = ViewController.ObtenerValorTotalAutosDePersona(personaSeleccionada).ToString("C");
                CantidadAutosTextBox.Text = ViewController.ObtenerCantidadAutosDePersona(personaSeleccionada).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }


    // Métodos para los autos asignados.----------------------------------------
    private void CargarAutosAsignados()
    {
        // Obtener todos los autos asignados a personas
        var autosAsignados = _viewController.ObtenerPersonas()
        .SelectMany(p => p.Autos.Select(a => new
        {
            a.Marca,
            a.Año,
            a.Modelo,
            a.Patente,
            DniDueño = p.DNI,
            NombreCompletoDueño = $"{p.Apellido}, {p.Nombre}"
        }))
        .ToList();

        // Desactivar la generación automática de columnas
        AutosAsignadosDataGridView.AutoGenerateColumns = false;

        // Asignar los datos al BindingSource
        _autosAsignadosBindingSource.DataSource = autosAsignados;

        // Configurar las columnas del DataGridView
        ConfigurarColumnasAutosAsignados();
    }

    private void ConfigurarColumnasAutosAsignados()
    {
        // Limpiar las columnas existentes (por si acaso)
        AutosAsignadosDataGridView.Columns.Clear();

        // Agregar las columnas manualmente
        AutosAsignadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Marca", // Nombre de la propiedad en el objeto anónimo
            HeaderText = "Marca" // Encabezado de la columna
        });

        AutosAsignadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Año",
            HeaderText = "Año"
        });

        AutosAsignadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Modelo",
            HeaderText = "Modelo"
        });

        AutosAsignadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "Patente",
            HeaderText = "Patente"
        });

        AutosAsignadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "DniDueño",
            HeaderText = "DNI"
        });

        AutosAsignadosDataGridView.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = "NombreCompletoDueño",
            HeaderText = "Dueño"
        });
    }
}
