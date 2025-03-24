namespace Integrador.BusinessLogic.Commands;

public interface IWriteCommand
{
    (bool Success, string ErrorMessage) Execute();
    void Undo();
}
