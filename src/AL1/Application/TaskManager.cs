using Domain;

using Infrastructure;

namespace Application;

public class TaskManager
{
    private readonly XmlTaskRepository _repository;

    public TaskManager()
    {
        _repository = new XmlTaskRepository();
    }

    public IEnumerable<TaskItem> GetTasks() => _repository.GetAll();

    public void AddTask(string description)
    {
        var newTask = new TaskItem { Description = description };
        _repository.Add(newTask);
    }

    public void CompleteTask(int id)
    {
        var task = _repository.GetAll().FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            task.IsCompleted = true;
            _repository.Update(task);
        }
    }

    public void DeleteTask(int id) => _repository.Delete(id);
}
