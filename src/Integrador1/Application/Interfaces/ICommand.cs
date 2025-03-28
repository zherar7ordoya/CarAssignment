namespace Integrador.Application.Interfaces;

public interface ICommand
{
    (bool Success, Exception Error) Execute();
    void Undo();
}
