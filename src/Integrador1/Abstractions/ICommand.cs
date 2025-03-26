namespace Integrador.Abstractions;

public interface ICommand
{
    (bool Success, Exception Error) Execute();
    void Undo();
}
