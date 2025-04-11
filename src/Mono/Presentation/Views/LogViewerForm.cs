using Integrador.Application.Exceptions;
using Integrador.Application.Interfaces.Exceptions;
using Integrador.Domain.Interfaces;
using Integrador.Infrastructure.Logging;
using Integrador.Infrastructure.Logging.Shared;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integrador.Presentation.Views;

public partial class LogViewerForm : Form
{
    private readonly ILogReader _logReader;
    private List<LogEntry> _todos = [];
    private IExceptionHandler _exceptionHandler;

    public LogViewerForm(ILogReader logReader, IExceptionHandler exceptionHandler)
    {
        InitializeComponent();
        _logReader = logReader;
        CargarLogs();
        _exceptionHandler = exceptionHandler;
    }

    private void CargarLogs()
    {
        try
        {
            _todos = [.. _logReader.Read()];
            AplicarFiltro();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al cargar los logs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //_exceptionHandler.Handle(ex, $"Error in {MethodBase.GetCurrentMethod()?.Name}");
        }
        finally
        {
            //logger.TryLog($"Create completed for {entity}");
        }



    }

    private void AplicarFiltro()
    {
        var texto = txtBuscar.Text?.ToLower() ?? "";
        var nivel = cmbNivel.SelectedItem?.ToString() ?? "Todos";

        var filtrados = _todos
        .Where(l => (nivel == "Todos" || l.Level.ToString() == nivel) &&
                    (string.IsNullOrEmpty(texto) || l.Message.Contains(texto, StringComparison.CurrentCultureIgnoreCase)))
        .ToList();

        dgvLogs.DataSource = filtrados;
    }

    private void TextBoxBuscar_TextChanged(object sender, EventArgs e)
    {
        AplicarFiltro();
    }

    private void ComboBoxNivel_SelectedIndexChanged(object sender, EventArgs e)
    {
        AplicarFiltro();
    }
}
