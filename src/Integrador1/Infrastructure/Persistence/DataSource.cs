using System.Text;
using System.Xml.Serialization;

using Integrador.Domain.Interfaces;
using Integrador.Infrastructure.Exceptions;
using Integrador.Infrastructure.Interfaces;
using Integrador.Infrastructure.Logging;
using Integrador.Infrastructure.Messaging;

namespace Integrador.Infrastructure.Persistence;

public class DataSource<T> : IDataSource<T> where T : IEntity
{
    readonly ILogger _logger = new Logger();
    readonly IMessenger _messenger = new Messenger();

    public List<T> Read()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Data");
        string file = $"{typeof(T).Name}.xml";
        file = Path.Combine(path, file);

        if (!File.Exists(file))
        {
            CreateEmptyFile(file);
            return [];
        }

        StreamReader? reader = null;

        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            reader = new StreamReader(file, Encoding.Unicode);
            var result = serializer.Deserialize(reader) as List<T>;
            return result ?? [];
        }
        catch (Exception ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, $"Error en la lectura de {file}");
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
        }

        return []; // Ensure all code paths return a value
    }

    public bool Write(List<T> data)
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Data");
        string file = $"{typeof(T).Name}.xml";
        file = Path.Combine(path, file);

        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using StreamWriter writer = new(file, false, Encoding.Unicode);
            serializer.Serialize(writer, data);
            return true;
        }
        catch (Exception ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, $"Error en la escritura de {file}");
        }

        return false; // Ensure all code paths return a value
    }

    private void CreateEmptyFile(string file)
    {
        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using StreamWriter writer = new(file, false, Encoding.Unicode);
            serializer.Serialize(writer, new List<T>());
        }
        catch (Exception ex)
        {
            new ExceptionHandler(_logger, _messenger).Handle(ex, $"Error desconocido para {file}");
        }
    }
}
