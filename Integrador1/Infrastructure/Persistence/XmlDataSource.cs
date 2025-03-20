using System.Text;
using System.Xml.Serialization;

using Integrador.Abstract;
using Integrador.CrossCutting;

namespace Integrador.Infrastructure.Persistence;

public class XmlDataSource<T> : IDataSource<T> where T : IEntity
{
    public List<T> Read()
    {
        string file = $"{typeof(T).Name}.xml";

        if (!File.Exists(file))
        {
            XmlDataSource<T>.CreateEmptyFile(file);
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
        catch (FileNotFoundException ex) { ExceptionHandler.HandleException($"Archivo no encontrado: {file}", ex); }
        catch (UnauthorizedAccessException ex) { ExceptionHandler.HandleException($"Acceso no autorizado al archivo: {file}", ex); }
        catch (Exception ex) { ExceptionHandler.HandleException($"Error desconocido al leer {file}", ex); }
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
        string file = $"{typeof(T).Name}.xml";

        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using StreamWriter writer = new(file, false, Encoding.Unicode);
            serializer.Serialize(writer, data);
            return true;
        }
        catch (FileNotFoundException ex) { ExceptionHandler.HandleException($"Archivo no encontrado: {file}", ex); }
        catch (UnauthorizedAccessException ex) { ExceptionHandler.HandleException($"Acceso no autorizado al archivo: {file}", ex); }
        catch (Exception ex) { ExceptionHandler.HandleException($"Error desconocido al leer {file}", ex); }

        return false; // Ensure all code paths return a value
    }

    private static void CreateEmptyFile(string file)
    {
        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using StreamWriter writer = new(file, false, Encoding.Unicode);
            serializer.Serialize(writer, new List<T>());
        }
        catch (FileNotFoundException ex) { ExceptionHandler.HandleException($"Archivo no encontrado: {file}", ex); }
        catch (UnauthorizedAccessException ex) { ExceptionHandler.HandleException($"Acceso no autorizado al archivo: {file}", ex); }
        catch (Exception ex) { ExceptionHandler.HandleException($"Error desconocido al leer {file}", ex); }
    }
}
