using Integrador.Abstract;
using System.Text;
using System.Xml.Serialization;

namespace Integrador.Persistence;

public class XmlPersister<T> : IPersister<T> where T : IEntity
{
    public List<T> Read()
    {
        string file = $"{typeof(T).Name}.xml";

        if (!File.Exists(file))
        {
            XmlPersister<T>.CreateEmptyFile(file);
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
        catch (FileNotFoundException ex)
        {
            Service.LogError($"Archivo no encontrado: {file}", ex);
            throw new PersisterException($"El archivo {file} no fue encontrado.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            Service.LogError($"Acceso no autorizado al archivo: {file}", ex);
            throw new PersisterException($"No tiene permisos para acceder al archivo {file}.", ex);
        }
        catch (Exception ex)
        {
            Service.LogError($"Error desconocido al leer {file}", ex);
            throw new PersisterException($"Error al leer {file}.", ex);
        }
        finally
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
        }
    }

    public bool Write(List<T> datos)
    {
        string file = $"{typeof(T).Name}.xml";

        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using StreamWriter writer = new(file, false, Encoding.Unicode);
            serializer.Serialize(writer, datos);
            return true;
        }
        catch (FileNotFoundException ex)
        {
            Service.LogError($"Archivo no encontrado: {file}", ex);
            throw new PersisterException($"El archivo {file} no fue encontrado.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            Service.LogError($"Acceso no autorizado al archivo: {file}", ex);
            throw new PersisterException($"No tiene permisos para acceder al archivo {file}.", ex);
        }
        catch (Exception ex)
        {
            Service.LogError($"Error desconocido al leer {file}", ex);
            throw new PersisterException($"Error al leer {file}.", ex);
        }
    }

    private static void CreateEmptyFile(string file)
    {
        try
        {
            XmlSerializer serializer = new(typeof(List<T>));
            using StreamWriter writer = new(file, false, Encoding.Unicode);
            serializer.Serialize(writer, new List<T>());
        }
        catch (FileNotFoundException ex)
        {
            Service.LogError($"Archivo no encontrado: {file}", ex);
            throw new PersisterException($"El archivo {file} no fue encontrado.", ex);
        }
        catch (UnauthorizedAccessException ex)
        {
            Service.LogError($"Acceso no autorizado al archivo: {file}", ex);
            throw new PersisterException($"No tiene permisos para acceder al archivo {file}.", ex);
        }
        catch (Exception ex)
        {
            Service.LogError($"Error desconocido al leer {file}", ex);
            throw new PersisterException($"Error al leer {file}.", ex);
        }
    }
}
