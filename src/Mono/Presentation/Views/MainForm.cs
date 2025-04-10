using Integrador.Application.DTOs;
using Integrador.Application.Interfaces.Infrastructure;
using Integrador.Application.Interfaces.Presentation;
using Integrador.Application.Interfaces.Utilities;
using Integrador.Presentation.Localization;

namespace Integrador;

public partial class MainForm : Form
{
    public MainForm
    (
        IMessenger messenger,
        ICarFactory carFactory,
        IPersonFactory personFactory,
        IViewPresenter viewPresenter,
        IExceptionHandler exceptionHandler,
        ILocalizationService localization
    )
    {
        _messenger = messenger;
        _carFactory = carFactory;
        _personFactory = personFactory;
        _viewPresenter = viewPresenter;
        _exceptionHandler = exceptionHandler;

        _localization = localization;

        try
        {
            InitializeComponent();
            ConfigureBindings();
            LoadData();

            ApplyLocalization();
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error durante la inicialización del formulario.");
        }
    }

    private void ApplyLocalization()
    {
        this.Text = _localization["MainForm"];
        lblPersons.Text = _localization["lblPersons"];
        lblIdentityCard.Text = _localization["lblIdentityCard"];
        lblFirstname.Text = _localization["lblFirstname"];
        lblLastname.Text = _localization["lblLastname"];
        btnNewPerson.Text = _localization["btnNewPerson"];
        btnSavePerson.Text = _localization["btnSavePerson"];
        btnDeletePerson.Text = _localization["btnDeletePerson"];

        lblPersonCars.Text = _localization["lblPersonCars"];
        lblQuantity.Text = _localization["lblQuantity"];

        btnAssignCar.Text = _localization["btnAssignCar"];
        btnRemoveCar.Text = _localization["btnRemoveCar"];

        lblAvailableCars.Text = _localization["lblAvailableCars"];
        lblLicensePlate.Text = _localization["lblLicensePlate"];
        lblBrand.Text = _localization["lblBrand"];
        lblModel.Text = _localization["lblModel"];
        lblYear.Text = _localization["lblYear"];
        lblPrice.Text = _localization["lblPrice"];
        btnNewCar.Text = _localization["btnNewCar"];
        btnSaveCar.Text = _localization["btnSaveCar"];
        btnDeleteCar.Text = _localization["btnDeleteCar"];

        lblAssignedCars.Text = _localization["lblAssignedCars"];
    }

    private readonly IMessenger _messenger;
    private readonly ICarFactory _carFactory;
    private readonly IPersonFactory _personFactory;
    private readonly IViewPresenter _viewPresenter;
    private readonly IExceptionHandler _exceptionHandler;

    private readonly ILocalizationService _localization;

    private readonly BindingSource _persons = [];
    private readonly BindingSource _personCars = [];
    private readonly BindingSource _assignedCars = [];
    private readonly BindingSource _availableCars = [];

    ////////////////////////////////////////////////////////////////////////////

    private void PersonsDataGridView_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            if (_persons.Current is PersonDTO person)
            {
                _personCars.DataSource = person.Autos;
                _personCars.ResetBindings(false);
                lblCarsPrice.Text = person.GetCarsPrice.ToString("C");
                txtCarsCount.Text = person.GetCarsCount.ToString();
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al seleccionar persona.");
        }
    }

    private void NewPersonButton_Click(object sender, EventArgs e)
    {
        try
        {
            PersonDTO person = _personFactory.CreateDefault();
            _persons.Add(person);
            _persons.MoveLast();
            btnNewPerson.Enabled = false;
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error con persona nueva.");
        }
    }

    private void SavePersonButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_persons.Current is PersonDTO person)
            {
                _viewPresenter.SavePerson(person);
                LoadData();
                btnNewPerson.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al guardar persona.");
        }
    }

    private void DeletePersonButton_Click(object sender, EventArgs e)
    {
        try
        {
            var confirmacion = _messenger.ShowQuestion("¿Está seguro que desea eliminar la persona seleccionada?", "Eliminar persona");

            if (_persons.Current is PersonDTO persona && confirmacion)
            {
                _viewPresenter.DeletePerson(persona.Id);
                LoadData();
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al eliminar persona.");
        }
    }

    private void AssignCarButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_persons.Current is PersonDTO persona && _availableCars.Current is CarDTO auto)
            {
                _viewPresenter.AssignCar(persona.Id, auto.Id);
                LoadData();
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al asignar auto.");
        }
    }

    private void RemoveCarButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_persons.Current is PersonDTO persona && _personCars.Current is CarDTO auto)
            {
                _viewPresenter.RemoveCar(persona.Id, auto.Id);
                LoadData();
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al desasignar auto.");
        }

    }

    private void NewCarButton_Click(object sender, EventArgs e)
    {
        try
        {
            var newCar = _carFactory.CreateDefault(); // Datos por defecto
            _availableCars.Add(newCar);
            _availableCars.MoveLast();
            btnNewCar.Enabled = false;
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error con auto nuevo.");
        }
    }

    private void SaveCarButton_Click(object sender, EventArgs e)
    {
        try
        {
            if (_availableCars.Current is CarDTO car)
            {
                _viewPresenter.SaveCar(car);
                LoadData();
                btnNewCar.Enabled = true;
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al guardar auto.");
        }
    }

    private void DeleteCarButton_Click(object sender, EventArgs e)
    {
        try
        {
            var confirmation = _messenger.ShowQuestion("¿Está seguro que desea eliminar el auto seleccionado?", "Eliminar auto");

            if (_availableCars.Current is CarDTO car && confirmation)
            {
                _viewPresenter.DeleteCar(car.Id);
                LoadData();
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al eliminar auto.");
        }

    }

    ////////////////////////////////////////////////////////////////////////////

    private void ConfigureBindings()
    {
        ConfigureBindingSources();
        ConfigureDataGridView();
    }

    private void ConfigureBindingSources()
    {
        var bindings = new (Control Control, string Property, BindingSource Source)[]
        {
            // Persons
            (txtPersonId, nameof(PersonDTO.Id),       _persons),
            (txtDNI,      nameof(PersonDTO.DNI),      _persons),
            (txtNombre,   nameof(PersonDTO.Nombre),   _persons),
            (txtApellido, nameof(PersonDTO.Apellido), _persons),
            // Cars
            (txtCarId,   nameof(CarDTO.Id),      _availableCars),
            (txtPatente, nameof(CarDTO.Patente), _availableCars),
            (txtMarca,   nameof(CarDTO.Marca),   _availableCars),
            (txtModelo,  nameof(CarDTO.Modelo),  _availableCars),
            (txtAño,     nameof(CarDTO.Año),     _availableCars),
            (txtPrecio,  nameof(CarDTO.Precio),  _availableCars)
        };

        ConfigureBindingSources(bindings);
    }

    private static void ConfigureBindingSources
    (
        (Control Control, string Property, BindingSource Source)[] bindings
    )
    {
        foreach (var (control, property, source) in bindings)
        {
            control.DataBindings.Add("Text", source, property); // ORIGINAL
        }
    }

    private void ConfigureDataGridView()
    {
        ConfigureDataGridView(dgvPersons, _persons,
        [
            ("Id", "ID"),
            ("DNI", "DNI"),
            ("Nombre", "Nombre"),
            ("Apellido", "Apellido")
        ]);

        ConfigureDataGridView(dgvPersonCars, _personCars,
        [
            ("Id", "ID"),
            ("Patente", "Patente"),
            ("Marca", "Marca"),
            ("Modelo", "Modelo"),
            ("Año", "Año"),
            ("Precio", "Precio")
        ]);

        ConfigureDataGridView(dgvAvailableCars, _availableCars,
        [
            ("Id", "ID"),
            ("Patente", "Patente"),
            ("Marca", "Marca"),
            ("Modelo", "Modelo"),
            ("Año", "Año"),
            ("Precio", "Precio")
        ]);

        ConfigureDataGridView(dgvAssignedCars, _assignedCars,
        [
            ("Marca", "Marca"),
            ("Año", "Año"),
            ("Modelo", "Modelo"),
            ("Patente", "Patente"),
            ("Documento", "Documento"),
            ("Dueño", "Dueño")
        ]);
    }

    private static void ConfigureDataGridView(DataGridView dataGridView,
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

    private void LoadData()
    {
        try
        {
            var currentPerson = _persons.Current as PersonDTO;
            var currentCar = _availableCars.Current as CarDTO;

            int personId = currentPerson?.Id ?? -1;
            int carId = currentCar?.Id ?? -1;

            _persons.DataSource = new List<PersonDTO>();
            _availableCars.DataSource = new List<CarDTO>();
            _assignedCars.DataSource = new List<AssignedCarDTO>();

            var persons = _viewPresenter.ReadPersons();
            var cars = _viewPresenter.ReadAvailableCars();
            var assigned = _viewPresenter.ReadAssignedCars();

            _persons.DataSource = persons;
            _availableCars.DataSource = cars;
            _assignedCars.DataSource = assigned;

            if (personId != -1)
            {
                int newPersonIndex = persons.FindIndex(p => p.Id == personId);
                if (newPersonIndex >= 0) _persons.Position = newPersonIndex;
            }

            if (carId != -1)
            {
                int newCarIndex = cars.FindIndex(c => c.Id == carId);
                if (newCarIndex >= 0) _availableCars.Position = newCarIndex;
            }
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error al cargar datos.");
        }
    }

}
