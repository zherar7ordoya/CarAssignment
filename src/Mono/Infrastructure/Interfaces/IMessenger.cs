namespace Integrador.Infrastructure.Interfaces;

public interface IMessenger
{
    void ShowInformation(string mensaje, string titulo);
    void ShowError(Exception ex, string mensaje);
    bool ShowQuestion(string mensaje, string titulo);
}
