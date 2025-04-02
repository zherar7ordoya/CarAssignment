using Integrador.Application.Factories;
using Integrador.Application.Interfaces;
using Integrador.Presentation.Exceptions;
using Integrador.Presentation.Presenters;

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

        //_presenter = GenericFactory.Create<IViewPresenter>(_mediator) ?? throw new InvalidOperationException("Failed to create IViewPresenter instance.");
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

    private readonly IViewPresenter _presenter;

    private readonly BindingSource _persons = [];
    private readonly BindingSource _personCars = [];
    private readonly BindingSource _assignedCars = [];
    private readonly BindingSource _availableCars = [];

    ////////////////////////////////////////////////////////////////////////////

    private void PersonasDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (_persons.Current is IPerson person)
            {
                _personCars.DataSource = person.Autos;
                _personCars.ResetBindings(false);
                ValorTotalAutosLabel.Text = person.GetValorAutos().ToString("C");
                CantidadAutosTextBox.Text = person.GetCantidadAutos().ToString();
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
            IPerson person = _personFactory.CreateDefault();
            _persons.Add(person);
            _persons.MoveLast();
            NewPersonButton.Enabled = false;
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error con persona nueva.");
        }
    }

    private async void GuardarPersonaButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_persons.Current is IPerson person)
            {
                await _presenter.SavePerson(person);
                LoadData();
                NewCarButton.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al guardar persona.");
        }
    }

    private async void EliminarPersonaButton_Click(object sender, EventArgs e)
    {
        try
        {
            var confirmacion = _messenger.ShowQuestion("¿Está seguro que desea eliminar la persona seleccionada?", "Eliminar persona");

            if (_persons.Current is IPerson persona && confirmacion)
            {
                await _presenter.DeletePerson(persona.Id);
                LoadData();
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al eliminar persona.");
        }
    }

    private async void AsignarAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_persons.Current is IPerson persona && _availableCars.Current is ICar auto)
            {
                await _presenter.AssignCar(persona.Id, auto.Id);
                LoadData();
                _messenger.ShowInformation("Auto asignado correctamente.", "Asignación de auto");
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al asignar auto.");
        }
    }

    private async void DesasignarAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_persons.Current is IPerson persona && _personCars.Current is ICar auto)
            {
                await _presenter.RemoveCar(persona.Id, auto.Id);
                LoadData();
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
            var newCar = _carFactory.CreateDefault(); // Datos por defecto
            _availableCars.Add(newCar);
            _availableCars.MoveLast();
            NewCarButton.Enabled = false;
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error con auto nuevo.");
        }
    }

    private async void GuardarAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_availableCars.Current is ICar car)
            {
                await _presenter.SaveCar(car);
                LoadData();
                NewCarButton.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al guardar auto.");
        }
    }

    private async void EliminarAutoButton_Click(object sender, EventArgs e)
    {
        try
        {
            var confirmation = _messenger.ShowQuestion("¿Está seguro que desea eliminar el auto seleccionado?", "Eliminar auto");

            if (_availableCars.Current is ICar car && confirmation)
            {
                await _presenter.DeleteCar(car.Id);
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
            (IdPersonaTextBox, nameof(IPerson.Id), _persons),
            (DniTextBox, nameof(IPerson.DNI), _persons),
            (NombreTextBox, nameof(IPerson.Nombre), _persons),
            (ApellidoTextBox, nameof(IPerson.Apellido), _persons),
            (IdAutoTextBox, nameof(ICar.Id), _availableCars),
            (PatenteTextBox, nameof(ICar.Patente), _availableCars),
            (MarcaTextBox, nameof(ICar.Marca), _availableCars),
            (ModeloTextBox, nameof(ICar.Modelo), _availableCars),
            (AñoTextBox, nameof(ICar.Año), _availableCars),
            (PrecioTextBox, nameof(ICar.Precio), _availableCars)
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
        ConfigurarDataGridView(PersonasDGV, _persons,
        [
            ("Id", "ID"),
            ("DNI", "DNI"),
            ("Nombre", "Nombre"),
            ("Apellido", "Apellido")
        ]);

        ConfigurarDataGridView(AutosPersonaDGV, _personCars,
        [
            ("Id", "ID"),
            ("Patente", "Patente"),
            ("Marca", "Marca"),
            ("Modelo", "Modelo"),
            ("Año", "Año"),
            ("Precio", "Precio")
        ]);

        ConfigurarDataGridView(AutosDisponiblesDGV, _availableCars,
        [
            ("Id", "ID"),
            ("Patente", "Patente"),
            ("Marca", "Marca"),
            ("Modelo", "Modelo"),
            ("Año", "Año"),
            ("Precio", "Precio")
        ]);

        ConfigurarDataGridView(AutosAsignadosDGV, _assignedCars,
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
        _persons.DataSource = _presenter.ReadPersons();
        _availableCars.DataSource = _presenter.ReadAvailableCars();
        _assignedCars.DataSource = _presenter.ReadAssignedCars();
    }
}
