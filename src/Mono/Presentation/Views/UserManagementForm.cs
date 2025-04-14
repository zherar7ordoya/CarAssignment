using Integrador.Application.Interfaces;
using Integrador.Domain.Entities;
using Integrador.Presentation.Composition;

using System.Diagnostics.CodeAnalysis;

namespace Integrador.Presentation.Views;

public partial class UserManagementForm : Form
{
    private readonly IAuthService _authService = AppServices.Get<IAuthService>();
    private readonly BindingSource _bindingSource = [];
    private List<User> _users = []; // tu lista en memoria

    private void UserManagementForm_Load(object sender, EventArgs e)
    {
        // Cargar los usuarios desde el repositorio  
        _users = _authService.GetAllUsers()?.ToList() ?? []; // Ensure null safety  
        _bindingSource.DataSource = _users;

        dgvUsers.DataSource = _bindingSource;

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

    private void DgvUsers_SelectionChanged([NotNull] object? sender, EventArgs e)
    {
        ArgumentNullException.ThrowIfNull(sender);

        if (dgvUsers.SelectedRows.Count > 0)
        {
            if (dgvUsers.SelectedRows[0].DataBoundItem is User selectedUser)
            {
                txtId.Text = selectedUser.Id.ToString();
                txtUsername.Text = selectedUser.Username ?? string.Empty;
                txtPassword.Text = selectedUser.PasswordHash ?? string.Empty;
                cmbRole.SelectedItem = selectedUser.Role;
            }
        }
    }
}
