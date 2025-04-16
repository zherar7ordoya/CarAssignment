using Integrador.Application.Authorization;
using Integrador.Application.DTOs;
using Integrador.Application.Interfaces.Exceptions;
using Integrador.Application.Interfaces.Presentation;
using Integrador.Application.Interfaces.Utilities;
using Integrador.Infrastructure.Configuration;
using Integrador.Infrastructure.Interfaces;
using Integrador.Presentation.Composition;
using Integrador.Presentation.Localization;
using Integrador.Presentation.Views;

using System.Globalization;

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
        IAuthorizationService authorizationService,
        IUserRepository userRepository
    )
    {
        _messenger = messenger;
        _carFactory = carFactory;
        _personFactory = personFactory;
        _viewPresenter = viewPresenter;
        _exceptionHandler = exceptionHandler;



        _authorizationService = authorizationService;
        _userRepository = userRepository;

        try
        {
            InitializeComponent();
            ConfigureCulture();
            ConfigurePersistence();
            ConfigureBindings();
            LoadData();

            ApplyLocalization();
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error durante la inicialización del formulario.");
        }
    }

    private void ConfigureCulture()
    {
        var culture = AppConfigReader.GetSetting("DefaultCulture") ?? "es";
        if (culture == "es") cmbLanguages.SelectedIndex = 0; // Español
        else if (culture == "en") cmbLanguages.SelectedIndex = 1; // Inglés
        else cmbLanguages.SelectedIndex = 0; // Predeterminado a Español
    }

    private void ApplyLocalization()
    {
        this.Text = Resources.TitleMain;
        lblPersons.Text = Resources.Persons;
        lblIdentityNumber.Text = Resources.IdentityNumber;
        lblFirstname.Text = Resources.FirstName;
        lblLastname.Text = Resources.LastName;
        btnNewPerson.Text = Resources.New;
        btnSavePerson.Text = Resources.Save;
        btnDeletePerson.Text = Resources.Delete;

        lblPersonCars.Text = Resources.PersonCars;
        lblQuantity.Text = Resources.Quantity;

        btnAssignCar.Text = Resources.AssignCar;
        btnRemoveCar.Text = Resources.RemoveCar;

        lblAvailableCars.Text = Resources.AvailableCars;
        lblLicensePlate.Text = Resources.LicensePlate;
        lblBrand.Text = Resources.Brand;
        lblModel.Text = Resources.Model;
        lblYear.Text = Resources.Year;
        lblPrice.Text = Resources.Price;
        btnNewCar.Text = Resources.New;
        btnSaveCar.Text = Resources.Save;
        btnDeleteCar.Text = Resources.Delete;

        lblAssignedCars.Text = Resources.AssignedCars;

        lblLanguage.Text = Resources.Language;
        btnLogViewer.Text = Resources.ViewLog;
        btnUserManagement.Text = Resources.UserManagement;
    }

    private void ConfigurePersistence()
    {
        var options = new List<string> { "XML", "SQLite", "LiteDB" };
        cmbPersistence.DataSource = options;

        string persistence = AppConfigReader.GetSetting("PersistenceTechnology") ?? "XML";
        cmbPersistence.SelectedItem = persistence;

        _isInitializing = false;
    }

    private readonly IMessenger _messenger;
    private readonly ICarFactory _carFactory;
    private readonly IPersonFactory _personFactory;
    private readonly IViewPresenter _viewPresenter;
    private readonly IExceptionHandler _exceptionHandler;


    private readonly IAuthorizationService _authorizationService;
    private readonly IUserRepository _userRepository;

    private bool _isInitializing = true;

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
                _personCars.DataSource = person.CarIds;
                _personCars.ResetBindings(false);
                lblCarsPrice.Text = person.GetCarsPrice.ToString("C2", new CultureInfo("en-US"));
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
            (txtPersonId, nameof(PersonDTO.Id),             _persons),
            (txtDNI,      nameof(PersonDTO.IdentityNumber), _persons),
            (txtNombre,   nameof(PersonDTO.FirstName),      _persons),
            (txtApellido, nameof(PersonDTO.LastName),       _persons),
            // Cars
            (txtCarId,   nameof(CarDTO.Id),           _availableCars),
            (txtPatente, nameof(CarDTO.LicensePlate), _availableCars),
            (txtMarca,   nameof(CarDTO.Brand),        _availableCars),
            (txtModelo,  nameof(CarDTO.Model),        _availableCars),
            (txtAño,     nameof(CarDTO.Year),         _availableCars),
            (txtPrecio,  nameof(CarDTO.Price),        _availableCars)
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
            ("Id", Resources.Id),
            ("IdentityNumber", Resources.IdentityNumber),
            ("FirstName", Resources.FirstName),
            ("LastName", Resources.LastName)
        ]);

        ConfigureDataGridView(dgvPersonCars, _personCars,
        [
            ("Id", Resources.Id),
            ("LicensePlate", Resources.LicensePlate),
            ("Brand", Resources.Brand),
            ("Model", Resources.Brand),
            ("Year", Resources.Year),
            ("Price", Resources.Price)
        ]);

        ConfigureDataGridView(dgvAvailableCars, _availableCars,
        [
            ("Id", Resources.Id),
            ("LicensePlate", Resources.LicensePlate),
            ("Brand", Resources.Brand),
            ("Model", Resources.Model),
            ("Year", Resources.Year),
            ("Price", Resources.Price)
        ]);

        ConfigureDataGridView(dgvAssignedCars, _assignedCars,
        [
            ("Brand", Resources.Brand),
            ("Year", Resources.Year),
            ("Model", Resources.Model),
            ("LicensePlate", Resources.LicensePlate),
            ("IdentityNumber", Resources.IdentityNumber),
            ("Person", Resources.Person)
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

    private void ButtonViewLog_Click(object sender, EventArgs e)
    {
        var child = AppServices.Get<LogViewerForm>();
        child.ShowDialog(this);
    }

    private void ComboBoxLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        string cultureCode = "es"; // Predeterminado
        if (cmbLanguages.SelectedIndex == 1) // Inglés
        {
            cultureCode = "en";
        }
        AppConfigWriter.SetSetting("DefaultCulture", cultureCode);
        ChangeCulture(cultureCode);
    }

    private void ChangeCulture(string cultureCode)
    {
        // Cambiar la cultura
        Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);

        // Actualizar los controles
        ApplyLocalization();
        ConfigureDataGridView();
    }

    private void ComboBoxPersistence_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_isInitializing) return; // Evitar el evento al cargar el formulario

        string selected = cmbPersistence.SelectedItem?.ToString() ?? "XML";
        AppConfigWriter.SetSetting("PersistenceTechnology", selected);

        var result = _messenger.ShowQuestion
       (
           "The change in persistence requires restarting the application.\n" +
           "Do you want to restart now?", "Restart Required"
       );

        if (result)
        {
            System.Windows.Forms.Application.Restart(); // Use the correct namespace for Application.Restart  
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        var loginForm = new LoginForm((IAuthorizationService)_authorizationService, _userRepository);

        if (loginForm.ShowDialog() == DialogResult.OK)
        {
            var user = loginForm.LoggedUser;

            if (user != null) // Ensure user is not null
            {
                var permissions = _authorizationService.GetPermissions(user.Username);
                // Guardar usuario en Session, habilitar controles, etc.
            }
            else
            {
                _exceptionHandler.Handle(new NullReferenceException("LoggedUser is null"), "Error during login.");
                System.Windows.Forms.Application.Exit(); // Corrected namespace for Application.Exit
            }
        }
        else
        {
            System.Windows.Forms.Application.Exit(); // Corrected namespace for Application.Exit
        }
    }

    private void ButtonUserManagement_Click(object sender, EventArgs e)
    {
        var child = AppServices.Get<UserManagementForm>();
        child.ShowDialog(this);
    }
}
