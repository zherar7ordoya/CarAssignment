using System.Xml.Serialization;

using Integrador.Application.Exceptions;
using Integrador.Application.Interfaces;

namespace Integrador.Infrastructure.Persistence;

public class DataSource<T>
(
    IExceptionHandler exceptionHandler,
    string dataDirectory = "Data"
) : IDataSource<T> where T : IEntity
{
    private readonly string _filePath = Path.Combine(Environment.CurrentDirectory,
                                                     dataDirectory,
                                                     $"{typeof(T).Name}.xml");

    public async Task<List<T>> ReadAsync(CancellationToken ct)
    {
        if (!File.Exists(_filePath))
        {
            await CreateEmptyFileAsync(ct);
            return [];
        }

        try
        {
            await using var stream = new FileStream(_filePath,
                                                    FileMode.Open,
                                                    FileAccess.Read,
                                                    FileShare.Read,
                                                    bufferSize: 4096,
                                                    useAsync: true);

            var serializer = new XmlSerializer(typeof(List<T>));
            var result = await Task.Run(() => serializer.Deserialize(stream) as List<T>, ct);
            return result ?? [];
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error leyendo {_filePath}");
            return [];
        }
    }

    public async Task<bool> WriteAsync(List<T> data, CancellationToken ct)
    {
        try
        {
            await using var stream = new FileStream(_filePath,
                                                    FileMode.Create,
                                                    FileAccess.Write,
                                                    FileShare.None,
                                                    bufferSize: 4096,
                                                    useAsync: true);

            var serializer = new XmlSerializer(typeof(List<T>));
            await Task.Run(() => serializer.Serialize(stream, data), ct);
            return true;
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error escribiendo {_filePath}");
            return false;
        }
    }

    private async Task CreateEmptyFileAsync(CancellationToken ct)
    {
        try
        {
            var emptyList = new List<T>();
            await using var stream = new FileStream(_filePath,
                                                    FileMode.CreateNew,
                                                    FileAccess.Write,
                                                    FileShare.None,
                                                    bufferSize: 4096,
                                                    useAsync: true);

            var serializer = new XmlSerializer(typeof(List<T>));
            await Task.Run(() => serializer.Serialize(stream, emptyList), ct);
        }
        catch (Exception ex)
        {
            exceptionHandler.Handle(ex, $"Error creando {_filePath}");
        }
    }
}
