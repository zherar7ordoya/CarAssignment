using System.Xml.Serialization;

using Domain;

namespace Infrastructure;

public class XmlTaskRepository
{
    private readonly string _filePath = "tasks.xml";

    public List<TaskItem> GetAll()
    {
        if (!File.Exists(_filePath))
        {
            return [];
        }

        using var reader = new StreamReader(_filePath);
        var serializer = new XmlSerializer(typeof(List<TaskItem>));
        var result = serializer.Deserialize(reader) as List<TaskItem>;
        return result ?? [];
    }

    public void Add(TaskItem task)
    {
        var tasks = GetAll();
        task.Id = tasks.Count != 0 ? tasks.Max(t => t.Id) + 1 : 1;
        tasks.Add(task);
        Save(tasks);
    }

    public void Update(TaskItem updatedTask)
    {
        var tasks = GetAll();
        var index = tasks.FindIndex(t => t.Id == updatedTask.Id);
        if (index != -1)
        {
            tasks[index] = updatedTask;
            Save(tasks);
        }
    }

    public void Delete(int id)
    {
        var tasks = GetAll();
        tasks.RemoveAll(t => t.Id == id);
        Save(tasks);
    }

    private void Save(List<TaskItem> tasks)
    {
        using var writer = new StreamWriter(_filePath);
        var serializer = new XmlSerializer(typeof(List<TaskItem>));
        serializer.Serialize(writer, tasks);
    }
}
