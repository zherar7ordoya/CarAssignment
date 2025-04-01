using Integrador.Application.Interfaces;

namespace Integrador.Infrastructure.Messaging;

public class Messenger : IMessenger
{
    public void ShowInformation(string message, string title = "Información")
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void ShowError(string message, string title = "Error")
    {
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void ShowError(Exception ex, string message)
    {
        var detailedMessage = $"{message}\n\nDetalles técnicos:\n{ex}";
        MessageBox.Show(detailedMessage, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public bool ShowQuestion(string message, string title = "Confirmación")
    {
        return MessageBox.Show(message,
                               title,
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) == DialogResult.Yes;
    }
}
