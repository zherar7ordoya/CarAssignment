namespace Integrador.BusinessLogic.Commands;

public interface ICommand
{
    (bool Success, string ErrorMessage) Execute();
    void Undo();
}
