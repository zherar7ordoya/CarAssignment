using Integrador.Application.Authorization;
using Integrador.Application.Interfaces;
using Integrador.Domain.Enums.Authorization;
using Integrador.Presentation.Composition;
using Integrador.Presentation.Localization;

using System.Diagnostics.CodeAnalysis;

namespace Integrador.Presentation.Views;

public partial class UserManagementForm : Form
{
    private readonly IAuthService _authService = AppServices.Get<IAuthService>();
    private readonly BindingSource _bindingSource = [];
    private List<User> _users = []; // tu lista en memoria

    public UserManagementForm()
    {
        InitializeComponent();
        ApplyLocalization();
        LoadComboBox();
    }

    private void ApplyLocalization()
    {
        Text = Resources.UserManagement;
        lblId.Text = Resources.Id;
        lblUsername.Text = Resources.Username;
        lblPassword.Text = Resources.Password;
        lblRole.Text = Resources.Role;
        btnNew.Text = Resources.New;
        btnSave.Text = Resources.Save;
        btnDelete.Text = Resources.Delete;
    }

    private void UserManagementForm_Load(object sender, EventArgs e)
    {
        // Cargar los usuarios desde el repositorio  
        _users = _authService.GetAllUsers()?.ToList() ?? []; // Ensure null safety  
        _bindingSource.DataSource = _users;

        dgvUsers.DataSource = _bindingSource;

        dgvUsers.Columns[0].HeaderText = Resources.Username;
        dgvUsers.Columns[1].HeaderText = Resources.Password;
        dgvUsers.Columns[2].HeaderText = Resources.Role;
        dgvUsers.Columns[3].HeaderText = Resources.Id;

        // Opcional: ocultar columnas sensibles  
        if (dgvUsers.Columns != null) // Check for null before accessing  
        {
            var passwordColumn = dgvUsers.Columns["Password"];
            if (passwordColumn != null)
            {
                passwordColumn.Visible = false;
            }
        }

        // Configurar evento para detectar selección  
        dgvUsers.SelectionChanged += DgvUsers_SelectionChanged;
    }

    private void LoadComboBox()
    {
        cmbRole.DataSource = Enum.GetValues<Role>().Cast<Role>().ToList();
        cmbRole.SelectedIndex = -1; // Desmarcar selección inicial
    }

    private void DgvUsers_SelectionChanged([NotNull] object? sender, EventArgs e)
    {
        ArgumentNullException.ThrowIfNull(sender);

        if (dgvUsers.SelectedRows.Count > 0)
        {
            if (dgvUsers.SelectedRows[0].DataBoundItem is User selected)
            {
                txtId.Text = selected.Id.ToString();
                txtUsername.Text = selected.Username ?? string.Empty;
                txtPassword.Text = selected.PasswordHash ?? string.Empty;
                cmbRole.SelectedItem = selected.Role;
            }
        }
    }

    private void ButtonNew_Click(object sender, EventArgs e)
    {
        _bindingSource.AddNew(); // Agrega un nuevo user vacío si el BindingSource apunta a List<User>
    }

    private void ButtonSave_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is User user) // Ensure null safety  
        {
            user.Id = int.TryParse(txtId.Text, out var id) ? id : 0; // Parse Id  
            user.Username = txtUsername.Text; // Get username  
            user.PasswordHash = txtPassword.Text; // Get password  

            // Ensure Role is selected before assigning  
            if (cmbRole.SelectedItem is Role selectedRole)
            {
                user.Role = selectedRole;
                _authService.SaveUser(user); // Save the user  
                _bindingSource.ResetBindings(false);
            }
            else
            {
                MessageBox.Show("Please select a valid role.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        else
        {
            MessageBox.Show("No user is selected to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ButtonDelete_Click(object sender, EventArgs e)
    {
        if (_bindingSource.Current is User user) // Ensure null safety
        {
            _authService.DeleteUser(user.Id); // Delete by Id
            _bindingSource.RemoveCurrent(); // Remove from view
        }
        else
        {
            MessageBox.Show("No user is selected to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
