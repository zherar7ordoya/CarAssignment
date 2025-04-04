namespace Integrador.Application.Interfaces
{
    public interface IMessenger
    {
        void ShowError(string message, string title = "Error");
        void ShowError(Exception ex, string message);
        void ShowInformation(string message, string title = "Information");
        bool ShowQuestion(string message, string title = "Question");
    }
}