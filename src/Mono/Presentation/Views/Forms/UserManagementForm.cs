using Integrador.Application.Authorization;

namespace Integrador.Presentation.Views;

public partial class UserManagementForm : Form
{
    private readonly IUserManagerService _userManagerService;
    private readonly IRoleManagerService _roleManagerService;

    public UserManagementForm
    (
        IUserManagerService userManagerService,
        IRoleManagerService roleManagerService
    )
    {
        InitializeComponent();
        _userManagerService = userManagerService;
        _roleManagerService = roleManagerService;
        LoadUsers();
        LoadRoles();
        LoadPermissions();
    }

    private void LoadUsers()
    {
        lstUsers.Items.Clear();
        var users = _userManagerService.GetAllUsers();
        foreach (var user in users)
            lstUsers.Items.Add(user.Username);
    }

    private void LoadRoles()
    {
        clbRoles.Items.Clear();
        var roles = _roleManagerService.GetRoles();
        foreach (var role in roles)
            clbRoles.Items.Add(role.Name);
    }

    private void LoadPermissions()
    {
        clbSpecialPermissions.Items.Clear();
        var permissions = _roleManagerService.GetPermissions();

        foreach (var permission in permissions)
        {
            clbSpecialPermissions.Items.Add(permission);
        }
    }

    private void ListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstUsers.SelectedItem is not string username)
            return;

        var user = _userManagerService.GetUserByUsername(username);

        if (user == null)
        {
            MessageBox.Show("El usuario seleccionado no existe.");
            return;
        }

        // Roles
        if (user.RoleNames != null)
        {
            for (int i = 0; i < clbRoles.Items.Count; i++)
            {
                var roleName = clbRoles.Items[i]?.ToString();
                clbRoles.SetItemChecked(i, roleName != null && user.RoleNames.Contains(roleName));
            }
        }

        // Permisos especiales
        if (user.SpecialPermissions != null)
        {
            for (int i = 0; i < clbSpecialPermissions.Items.Count; i++)
            {
                if (clbSpecialPermissions.Items[i] is Permission permission)
                {
                    clbSpecialPermissions.SetItemChecked(i, user.SpecialPermissions.Contains(permission));
                }
            }
        }

        txtUsername.Text = user.Username;
    }

    private void ButtonCreateUser_Click(object sender, EventArgs e)
    {
        var username = txtUsername.Text.Trim();
        if (string.IsNullOrEmpty(username))
        {
            MessageBox.Show("Debe ingresar un nombre de usuario.");
            return;
        }

        try
        {
            _userManagerService.CreateUser(username, password: "1234"); // Por defecto
            LoadUsers();
            txtUsername.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al crear el usuario: {ex.Message}");
        }
    }

    private void ButtonDeleteUser_Click(object sender, EventArgs e)
    {
        if (lstUsers.SelectedItem is not string username)
        {
            MessageBox.Show("Debe seleccionar un usuario para eliminar.");
            return;
        }

        var confirm = MessageBox.Show(
            $"¿Está seguro que desea eliminar al usuario '{username}'?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo);

        if (confirm == DialogResult.Yes)
        {
            try
            {
                _userManagerService.DeleteUser(username);
                LoadUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el usuario: {ex.Message}");
            }
        }
    }

    private void ButtonSaveChanges_Click(object sender, EventArgs e)
    {
        if (lstUsers.SelectedItem is not string username)
        {
            MessageBox.Show("Debe seleccionar un usuario para guardar cambios.");
            return;
        }

        var selectedRoles = clbRoles.CheckedItems.Cast<string>().ToList();
        var selectedPermissions = clbSpecialPermissions.CheckedItems.Cast<Permission>().ToList();

        try
        {
            _userManagerService.SetUserRoles(username, selectedRoles);
            _userManagerService.SetUserSpecialPermissions(username, selectedPermissions);
            MessageBox.Show("Cambios guardados.");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al guardar cambios: {ex.Message}");
        }
    }
}
