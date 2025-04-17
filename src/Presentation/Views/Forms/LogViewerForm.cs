using Integrador.Application.Interfaces.Exceptions;
using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Logging.Shared;
using Integrador.Presentation.Localization;
using Integrador.Presentation.UI.Components;

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
        this.Text = Resources.TitleLogViewer;
        lblSelect.Text = Resources.Select;
        lblText.Text = Resources.Text;
        lblLevel.Text = Resources.Level;
        lblDate.Text = Resources.Date;
        btnFilter.Text = Resources.Filter;
    }

    private void LoadComboBoxLevels()
    {
        cmbLevel.Items.Clear();

        cmbLevel.Items.Add(new ComboBoxItem { Text = Resources.All, Value = null });
        cmbLevel.Items.Add(new ComboBoxItem { Text = Resources.Information, Value = LogLevel.Information });
        cmbLevel.Items.Add(new ComboBoxItem { Text = Resources.Warning, Value = LogLevel.Warning });
        cmbLevel.Items.Add(new ComboBoxItem { Text = Resources.Error, Value = LogLevel.Error });
        cmbLevel.Items.Add(new ComboBoxItem { Text = Resources.Critical, Value = LogLevel.Critical });
        cmbLevel.Items.Add(new ComboBoxItem { Text = Resources.Debug, Value = LogLevel.Debug });

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
        var selectedItem = cmbLevel.SelectedItem as ComboBoxItem;

        var text = txtText.Text?.ToLower() ?? "";
        var level = selectedItem?.Value;
        var date = dtpDate.Value.Date;

        var filtered = _logEntries
        .Where(log =>
            // Nivel
            (level == null || log.Level == level) &&

            // Texto en el mensaje
            (string.IsNullOrEmpty(text) || log.Message.Contains(text, StringComparison.CurrentCultureIgnoreCase)) &&

            // Fecha
            log.Timestamp.Date == date
        )
        .ToList();

        dgvLogEntries.DataSource = filtered;

        dgvLogEntries.Columns[0].HeaderText = Resources.Timestamp;
        dgvLogEntries.Columns[1].HeaderText = Resources.Level;
        dgvLogEntries.Columns[2].HeaderText = Resources.Message;
        dgvLogEntries.Columns[3].HeaderText = Resources.StackTrace;
        dgvLogEntries.Columns[4].HeaderText = Resources.Source;
    }


    private void TextBoxText_TextChanged(object sender, EventArgs e) => ApplyFilters();
    private void ComboBoxLevel_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilters();
    private void DateTimePickerDate_ValueChanged(object sender, EventArgs e) => ApplyFilters();
}
