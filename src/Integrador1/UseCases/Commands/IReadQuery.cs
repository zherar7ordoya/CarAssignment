namespace Integrador.UseCases.Commands
{
    public interface IReadQuery<T>
    {
        (bool Success, T? Result, Exception Error) Execute();
        void Undo();
    }
}
