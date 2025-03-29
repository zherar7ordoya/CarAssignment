using Integrador.Domain.Interfaces;

namespace Integrador.Infrastructure.Messaging;

public class Messenger : IMessenger
{
    public void ShowInformation(string mensaje, string titulo) => MessageBox.Show(mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
    public void ShowError(Exception ex, string mensaje) => MessageBox.Show(ex.Message, mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
    public bool AskConfirmation(string mensaje, string titulo) => MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
}
