namespace Integrador.UseCases.Commands;

public interface ICommand
{
    (bool Success, Exception Error) Execute();
    void Undo();
}
