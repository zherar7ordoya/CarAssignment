namespace Integrador.Domain.Interfaces;

public interface IMessageBus
{
    void PublishError(string message);
    void PublishInfo(string message);
}
