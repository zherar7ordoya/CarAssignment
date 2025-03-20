namespace Integrador.BusinessLogic.Commands;

public interface ICommand
{
    void Execute();
    void Undo(); // Opcional, para deshacer la acción
}
