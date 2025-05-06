using CarAssignment.Application.Interfaces.Exceptions;
using CarAssignment.Application.Security.Contracts;
using CarAssignment.Application.Security.Core;
using CarAssignment.Infrastructure.Interfaces;
using CarAssignment.Presentation.Composition;

namespace Integrador.Presentation.Views;

public partial class UserManagementForm : Form
{
    private readonly IUserManagerService _userManagerService = AppServiceProvider.GetService<IUserManagerService>();
    private readonly IRoleManagerService _roleManagerService = AppServiceProvider.GetService<IRoleManagerService>();
    private readonly IMessenger _messenger = AppServiceProvider.GetService<IMessenger>();
    private readonly IExceptionHandler _exceptionHandler = AppServiceProvider.GetService<IExceptionHandler>();

    public UserManagementForm()
    {
        InitializeComponent();
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
        if (lstUsers.SelectedItem is not string username) return;

        var user = _userManagerService.GetUserByUsername(username);

        if (user == null)
        {
            _messenger.ShowError("User not found", "Error");
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
        var password = txtPassword.Text.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            _messenger.ShowError("Username and password cannot be empty.", "Error");
            return;
        }

        try
        {
            _userManagerService.CreateUser(username, password);
            LoadUsers();
            txtUsername.Clear();
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, "Error creating user");
        }
    }

    private void ButtonDeleteUser_Click(object sender, EventArgs e)
    {
        if (lstUsers.SelectedItem is not string username)
        {
            _messenger.ShowError("User not selected", "Error");
            return;
        }

        var confirm = _messenger.ShowQuestion("Are you sure you want to delete this user?", "Confirm deletion");

        if (confirm)
        {
            try
            {
                _userManagerService.DeleteUser(username);
                LoadUsers();
            }
            catch (Exception ex)
            {
                _exceptionHandler.Handle(ex, "Error deleting user");
            }
        }
    }

    private void ButtonSaveChanges_Click(object sender, EventArgs e)
    {
        if (lstUsers.SelectedItem is not string username)
        {
            _messenger.ShowError("User not selected", "Error");
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
            _exceptionHandler.Handle(ex, "Error saving changes");
        }
    }
}
