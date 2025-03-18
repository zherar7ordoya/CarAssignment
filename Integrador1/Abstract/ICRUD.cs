namespace Integrador1.Abstract;

public interface ICRUD<T> where T : IEntity
{
    T Create(T entity);
    List<T> Read();
    bool Update(T entity);
    bool Delete(T entity);
}
