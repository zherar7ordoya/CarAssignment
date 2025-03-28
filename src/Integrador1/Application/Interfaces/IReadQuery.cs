namespace Integrador.Application.Interfaces;

public interface IReadQuery<T>
{
    (bool Success, T? Result, Exception Error) Execute();
    void Undo();
}
