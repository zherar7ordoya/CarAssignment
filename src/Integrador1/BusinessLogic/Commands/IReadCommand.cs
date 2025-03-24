namespace Integrador.BusinessLogic.Commands
{
    public interface IReadCommand<T>
    {
        (bool Success, T? Result, string ErrorMessage) Execute();
        void Undo();
    }
}
