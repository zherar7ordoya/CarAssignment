using Integrador.Application.Interfaces.Exceptions;
using Integrador.Infrastructure.Logging;
using Integrador.Infrastructure.Logging.Shared;
using Integrador.Presentation.Localization;

using System.Data;

namespace Integrador.Presentation.Views;

public partial class LogViewerForm : Form
{
    private readonly ILogReader _logReader;
    private List<LogEntry> _logEntries = [];
    private readonly IExceptionHandler _exceptionHandler;

    public LogViewerForm(ILogReader logReader, IExceptionHandler exceptionHandler)
    {
        InitializeComponent();
        _exceptionHandler = exceptionHandler;

        ApplyLocalization();
        LoadComboBoxLevels();

        _logReader = logReader;
        LoadLogs();
    }


    private void ApplyLocalization()
    {
        this.Text = Resources.TitleLog;
        lblSelect.Text = Resources.Select;
        lblText.Text = Resources.Text;
        lblLevel.Text = Resources.Level;
        lblDate.Text = Resources.Date;
        btnFilter.Text = Resources.Filter;
    }

    private void LoadComboBoxLevels()
    {
        cmbLevel.Items.Clear();

        cmbLevel.Items.Add(Resources.All);
        cmbLevel.Items.Add(Resources.Information);
        cmbLevel.Items.Add(Resources.Warning);
        cmbLevel.Items.Add(Resources.Error);
        cmbLevel.Items.Add(Resources.Critical);
        cmbLevel.Items.Add(Resources.Debug);

        cmbLevel.SelectedIndex = 0;
    }

    private void LoadLogs()
    {
        try
        {
            _logEntries = [.. _logReader.Read()];
            ApplyFilters();
        }
        catch (Exception ex)
        {
            _exceptionHandler.Handle(ex, $"Error loading logs.");
        }
    }

    private void ApplyFilters()
    {
        var text = txtText.Text?.ToLower() ?? "";
        var level = cmbLevel.SelectedItem?.ToString();
        var date = dtpDate.Value.Date;

        var filtered = _logEntries
        .Where(log =>
            // Nivel
            (level == Resources.All || log.Level.ToString() == level) &&

            // Texto en el mensaje
            (string.IsNullOrEmpty(text) || log.Message.Contains(text, StringComparison.CurrentCultureIgnoreCase)) &&

            // Fecha
            log.Timestamp.Date == date
        )
        .ToList();

        dgvLogEntries.DataSource = filtered;
    }


    private void TextBoxText_TextChanged(object sender, EventArgs e) => ApplyFilters();
    private void ComboBoxLevel_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();
    private void DateTimePickerDate_ValueChanged(object sender, EventArgs e) => ApplyFilters();
}
