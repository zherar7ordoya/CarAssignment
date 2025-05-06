using CarAssignment.Application.Security.Contracts;
using CarAssignment.Application.Security.Core;
using CarAssignment.Presentation.Composition;

using System.Data;

namespace Integrador.Presentation.Views.Forms;

public partial class RoleManagementForm : Form
{
    private readonly IRoleManagerService _roleManagerService = AppServiceProvider.GetService<IRoleManagerService>();

    public RoleManagementForm()
    {
        InitializeComponent();
        LoadRoles();
        LoadPermissions();
    }

    private void LoadRoles()
    {
        lstRoles.Items.Clear();
        var roles = _roleManagerService.GetRoles();
        foreach (var role in roles)
            lstRoles.Items.Add(role.Name);
    }

    private void LoadPermissions()
    {
        clbPermissions.Items.Clear();
        var permissions = _roleManagerService.GetPermissions();

        foreach (var permission in permissions)
        {
            clbPermissions.Items.Add(permission);
        }
    }

    private void ButtonCreateRole_Click(object sender, EventArgs e)
    {
        var roleName = txtRoleName.Text.Trim();
        if (string.IsNullOrEmpty(roleName))
        {
            MessageBox.Show("Debe ingresar un nombre de rol.");
            return;
        }

        try
        {
            _roleManagerService.CreateRole(roleName);
            LoadRoles();
            txtRoleName.Clear();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al crear el rol: {ex.Message}");
        }
    }

    private void ButtonDeleteRole_Click(object sender, EventArgs e)
    {
        if (lstRoles.SelectedItem is not string roleName)
        {
            MessageBox.Show("Debe seleccionar un rol para eliminar.");
            return;
        }

        var confirm = MessageBox.Show(
            $"¿Está seguro que desea eliminar el rol '{roleName}'?",
            "Confirmar eliminación",
            MessageBoxButtons.YesNo);

        if (confirm == DialogResult.Yes)
        {
            try
            {
                _roleManagerService.DeleteRole(roleName);
                LoadRoles();
                clbPermissions.ClearSelected();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el rol: {ex.Message}");
            }
        }
    }

    private void ListBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstRoles.SelectedItem is not string roleName)
            return;

        var rolePermissions = _roleManagerService.GetPermissionsForRole(roleName);

        // Limpiar selección actual
        for (int i = 0; i < clbPermissions.Items.Count; i++)
        {
            var permission = (Permission)clbPermissions.Items[i];
            clbPermissions.SetItemChecked(i, rolePermissions.Contains(permission));
        }
    }

    private void ButtonSavePermissions_Click(object sender, EventArgs e)
    {
        if (lstRoles.SelectedItem is not string roleName)
        {
            MessageBox.Show("Debe seleccionar un rol para modificar sus permisos.");
            return;
        }

        // Obtener permisos seleccionados
        var selectedPermissions = clbPermissions.CheckedItems.Cast<Permission>().ToList();

        // Obtener copia de los permisos actuales
        var currentPermissions = _roleManagerService.GetPermissionsForRole(roleName).ToList();

        // Eliminar todos los permisos actuales
        foreach (var permission in currentPermissions)
            _roleManagerService.RemovePermissionFromRole(roleName, permission);

        // Agregar los seleccionados
        foreach (var permission in selectedPermissions)
            _roleManagerService.AddPermissionToRole(roleName, permission);

        MessageBox.Show("Permisos actualizados.");
    }

}
