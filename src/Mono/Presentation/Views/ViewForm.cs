//using Integrador.Domain.Entities;
using Integrador.Presentation.Presenters;
using Integrador.Shared.Exceptions;
using Integrador.Shared.Extensions;
using Integrador.Shared.Interfaces;

using MediatR;

namespace Integrador;

public partial class ViewForm : Form
{
    public ViewForm
    (
        IMediator mediator,
        IMessenger messenger,
        ICarFactory carFactory,
        IPersonFactory personFactory,
        IExceptionHandler exceptionHandler
    )
    {
        _mediator = mediator;
        _messenger = messenger;
        _carFactory = carFactory;
        _personFactory = personFactory;
        _exceptionHandler = exceptionHandler;
        _presenter = new ViewPresenter(_mediator);

        System.Windows.Forms.Application.ThreadException += (sender, e) => _exceptionHandler.Handle(e.Exception);
        AppDomain.CurrentDomain.UnhandledException += (sender, e) => _exceptionHandler.Handle(e.ExceptionObject as Exception ?? new Exception("Excepción al cargar el Form."));

        try
        {
            InitializeComponent();
            ConfigurarEnlaces();
            LoadData();
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error durante la inicialización del formulario.");
        }
    }

    private readonly IMediator _mediator;
    private readonly IMessenger _messenger;
    private readonly ICarFactory _carFactory;
    private readonly IPersonFactory _personFactory;
    private readonly IExceptionHandler _exceptionHandler;

    private readonly ViewPresenter _presenter;

    //private readonly BindingSource _personasBS = [];
    //private readonly BindingSource _autosPersonaBS = [];
    //private readonly BindingSource _autosDisponiblesBS = [];
    //private readonly BindingSource _autosAsignadosBS = [];

    ////////////////////////////////////////////////////////////////////////////

    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (_personasBS.Current is person)
            {
                _autosPersonaBS.DataSource = persona.Autos;
                _autosPersonaBS.ResetBindings(false); // Forzar actualización
                ValorTotalAutosLabel.Text = persona.GetValorAutos().ToString("C");
                CantidadAutosTextBox.Text = persona.GetCantidadAutos().ToString();
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al seleccionar persona.");
        }
    }

    private void NuevoPersonaButton_Click(object sender, EventArgs e)
    {
        try
        {
            var nuevaPersona = _personFactory.CreateDefault(); // Datos por defecto
            _personasBS.Add(nuevaPersona);
            _personasBS.MoveLast();
            NuevoPersonaButton.Enabled = false;
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error con persona nueva.");
        }
    }

    private void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_personasBS.Current is Person persona)
            {
                _presenter.GuardarPersona(persona);
                LoadData();
                NuevoAutoButton.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al guardar persona.");
        }
    }

    private void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        try
        {
            var confirmacion = _messenger.ShowQuestion("¿Está seguro que desea eliminar la persona seleccionada?", "Eliminar persona");

            if (_personasBS.Current is Person persona && confirmacion)
            {
                _presenter.EliminarPersona(persona);
                LoadData();
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al eliminar persona.");
        }
    }

    private void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_personasBS.Current is Person persona && _autosDisponiblesBS.Current is Car auto)
            {
                _presenter.AsignarAuto(persona, auto);
                LoadData(); // Recargar todo
                _messenger.ShowInformation("Auto asignado correctamente.", "Asignación de auto");
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al asignar auto.");
        }
    }

    private void DesasignarAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_personasBS.Current is Person persona && _autosPersonaBS.Current is Car auto)
            {
                _presenter.DesasignarAuto(persona, auto);
                LoadData(); // Recargar todo
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al desasignar auto.");
        }

    }

    private void NuevoAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            var nuevoAuto = _carFactory.CreateDefault(); // Datos por defecto
            _autosDisponiblesBS.Add(nuevoAuto);
            _autosDisponiblesBS.MoveLast();
            NuevoAutoButton.Enabled = false;
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error con auto nuevo.");
        }
    }

    private void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_autosDisponiblesBS.Current is Car auto)
            {
                _presenter.GuardarAuto(auto);
                LoadData();
                NuevoAutoButton.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al guardar auto.");
        }
    }

    private void EliminarAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            var confirmacion = _messenger.ShowQuestion("¿Está seguro que desea eliminar el auto seleccionado?", "Eliminar auto");

            if (_autosDisponiblesBS.Current is Car auto && confirmacion)
            {
                _presenter.EliminarAuto(auto);
                LoadData();
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al eliminar auto.");
        }

    }

    ////////////////////////////////////////////////////////////////////////////

    private void ConfigurarEnlaces()
    {
        ConfigurarBindingSources();
        ConfigurarDataGridView();
    }

    private void ConfigurarBindingSources()
    {
        var bindings = new (Control Control, string Property, BindingSource Source)[]
        {
            (IdPersonaTextBox, nameof(Person.Id), _personasBS),
            (DniTextBox, nameof(Person.DNI), _personasBS),
            (NombreTextBox, nameof(Person.Nombre), _personasBS),
            (ApellidoTextBox, nameof(Person.Apellido), _personasBS),
            (IdAutoTextBox, nameof(Car.Id), _autosDisponiblesBS),
            (PatenteTextBox, nameof(Car.Patente), _autosDisponiblesBS),
            (MarcaTextBox, nameof(Car.Marca), _autosDisponiblesBS),
            (ModeloTextBox, nameof(Car.Modelo), _autosDisponiblesBS),
            (AñoTextBox, nameof(Car.Año), _autosDisponiblesBS),
            (PrecioTextBox, nameof(Car.Precio), _autosDisponiblesBS)
        };

        ConfigurarBindingSources(bindings);
    }

    private static void ConfigurarBindingSources((Control Control, string Property, BindingSource Source)[] bindings)
    {
        foreach (var (control, property, source) in bindings)
        {
            control.DataBindings.Add("Text", source, property);
        }
    }

    private void ConfigurarDataGridView()
    {
        ConfigurarDataGridView(PersonasDGV, _personasBS,
        [
            ("Id", "ID"),
            ("DNI", "DNI"),
            ("Nombre", "Nombre"),
            ("Apellido", "Apellido")
        ]);

        ConfigurarDataGridView(AutosPersonaDGV, _autosPersonaBS,
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

        ConfigurarDataGridView(AutosAsignadosDGV, _autosAsignadosBS,
        [
            ("Marca", "Marca"),
            ("Año", "Año"),
            ("Modelo", "Modelo"),
            ("Patente", "Patente"),
            ("Documento", "Documento"),
            ("Dueño", "Dueño")
        ]);
    }

    private static void ConfigurarDataGridView(DataGridView dataGridView, BindingSource bindingSource, (string Property, string Header)[] columns)
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

    private void LoadData()
    {
        _personasBS.DataSource = _presenter.ListarPersonas();
        _autosDisponiblesBS.DataSource = _presenter.ListarAutosDisponibles();
        _autosAsignadosBS.DataSource = _presenter.ListarAutosAsignados();
    }
}
