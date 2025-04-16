﻿using Integrador.Application.Authorization;

using System.Data;

namespace Integrador.Presentation.Views.Forms;

public partial class RoleManagementForm : Form
{
    private readonly IRoleManagerService _roleManagerService;

    public RoleManagementForm(IRoleManagerService roleManagerService)
    {
        InitializeComponent();
        _roleManagerService = roleManagerService;
        LoadRoles();
        LoadPermissions();
    }

    private void LoadRoles()
    {
        lstRoles.Items.Clear();
        var roles = _roleManagerService.GetAllRoles();
        foreach (var role in roles)
            lstRoles.Items.Add(role.Name);
    }

    private void LoadPermissions()
    {
        chkPermissions.Items.Clear();
        foreach (var permission in Enum.GetValues(typeof(Permission)))
            chkPermissions.Items.Add(permission);
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
                chkPermissions.ClearSelected();
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
        for (int i = 0; i < chkPermissions.Items.Count; i++)
        {
            var permission = (Permission)chkPermissions.Items[i];
            chkPermissions.SetItemChecked(i, rolePermissions.Contains(permission));
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
        var selectedPermissions = chkPermissions.CheckedItems.Cast<Permission>().ToList();

        // Primero, eliminar todos los permisos del rol
        var currentPermissions = _roleManagerService.GetPermissionsForRole(roleName);
        foreach (var permission in currentPermissions)
            _roleManagerService.RemovePermissionFromRole(roleName, permission);

        // Luego, agregar los seleccionados
        foreach (var permission in selectedPermissions)
            _roleManagerService.AddPermissionToRole(roleName, permission);

        MessageBox.Show("Permisos actualizados.");
    }
}
