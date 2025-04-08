using Integrador.Application.Interfaces.Infrastructure;

namespace Integrador.Infrastructure.Messaging;

public class Messenger : IMessenger
{
    public void ShowInformation(string message, string title = "Information")
    {
        MessageBox.Show(message,
                        title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
    }

    public void ShowError(string message, string title = "Error")
    {
        MessageBox.Show(message,
                        title,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
    }

    public void ShowError(Exception ex, string message)
    {
        var errorMessage = $"{message}\n\n{ex.Message}";
        if (ex.InnerException != null)
        {
            errorMessage += $"\n\nInner Exception: {ex.InnerException.Message}";
        }
        MessageBox.Show(errorMessage,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
    }

    public bool ShowQuestion(string message, string title = "Question")
    {
        return MessageBox.Show(message,
                               title,
                               MessageBoxButtons.YesNo,
                               MessageBoxIcon.Question) == DialogResult.Yes;
    }
}
