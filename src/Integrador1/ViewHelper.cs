using Integrador.Core;
using Integrador.CrossCutting;

namespace Integrador;

public static class ViewHelper
{
    public static void ConfigurarBindingsDeControles((Control Control, string Property, BindingSource Source)[] bindings)
    {
        foreach (var (control, property, source) in bindings)
        {
            control.DataBindings.Add("Text", source, property);
        }
    }

    public static void ConfigurarDataGridView(DataGridView dataGridView, BindingSource bindingSource, (string Property, string Header)[] columns)
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

    public static void ConfigurarDelegados()
    {
        Auto.AutoEliminado += static mensaje => Messenger.MostrarMensaje(mensaje, "Auto eliminado");
        Persona.PersonaEliminada += static mensaje => Messenger.MostrarMensaje(mensaje, "Persona eliminada");
    }
}
