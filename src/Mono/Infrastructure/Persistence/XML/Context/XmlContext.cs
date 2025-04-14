using System.Reflection;
using System.Xml.Serialization;

using Integrador.Application.Interfaces.Exceptions;
using Integrador.Domain.Interfaces;
using Integrador.Infrastructure.Interfaces.Persistence;

namespace Integrador.Infrastructure.Persistence.XML.Context;

public class XmlContext<T>(IExceptionHandler exceptionHandler)
           : IXmlContext<T> where T : IEntity
{
    private static readonly string _directory = "LocalData";
    private readonly string _filePath = Path.Combine
                                        (
                                            EnsureDirectoryExists(_directory),
                                            $"{typeof(T).Name}.xml"
                                        );

    private static string EnsureDirectoryExists(string directory)
    {
        string fullPath = Path.Combine(Environment.CurrentDirectory, directory);
        if (!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);
        return fullPath;
    }

    public List<T> Read()
    {
        if (!File.Exists(_filePath))
        {
            CreateEmptyFile();
            return [];
        }

        try
        {
            using var stream = new FileStream(_filePath,
                                              FileMode.Open,
                                              FileAccess.Read,
                                              FileShare.Read);
            var serializer = new XmlSerializer(typeof(List<T>));
            return serializer.Deserialize(stream) as List<T> ?? [];
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle
            (
                ex,
                $"Error in {MethodBase.GetCurrentMethod()?.Name} (File: {_filePath})"
            );
            return [];
        }
    }

    public void Write(List<T> data)
    {
        try
        {
            using var stream = new FileStream(_filePath,
                                              FileMode.Create,
                                              FileAccess.Write,
                                              FileShare.None);
            var serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(stream, data);
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle
            (
                ex,
                $"Error in {MethodBase.GetCurrentMethod()?.Name} (File: {_filePath})"
            );
        }
    }

    private void CreateEmptyFile()
    {
        try
        {
            using var stream = new FileStream(_filePath,
                                              FileMode.Create,
                                              FileAccess.Write,
                                              FileShare.None);
            var serializer = new XmlSerializer(typeof(List<T>));
            serializer.Serialize(stream, new List<T>());
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle
            (
                ex,
                $"Error in {MethodBase.GetCurrentMethod()?.Name} (File: {_filePath})"
            );
        }
    }
}
