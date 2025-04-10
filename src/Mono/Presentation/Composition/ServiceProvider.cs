namespace Integrador.Presentation.Composition;

[Obsolete("Use Microsoft.Extensions.DependencyInjection instead.")]
public sealed class ServiceProvider
{
    private readonly Dictionary<Type, Type> _registrations = [];

    public void Register<TInterface, TImplementation>()
    {
        _registrations[typeof(TInterface)] = typeof(TImplementation);
    }

    public void Register(Type serviceType, Type implementationType)
    {
        _registrations[serviceType] = implementationType;
    }

    public T Resolve<T>() => (T)Resolve(typeof(T));

    private object Resolve(Type type)
    {
        if (_registrations.TryGetValue(type, out var implementationType))
        {
            return CreateInstance(implementationType);
        }

        if (
            type.IsGenericType && _registrations
            .TryGetValue(type.GetGenericTypeDefinition(), out var genericType)
            )
        {
            var constructed = genericType.MakeGenericType(type.GetGenericArguments());
            return CreateInstance(constructed);
        }

        throw new InvalidOperationException($"Service not registered: {type.FullName}");
    }

    private object CreateInstance(Type type)
    {
        var constructor = type.GetConstructors()
                              .FirstOrDefault()
                              ?? throw new InvalidOperationException
                              ($"No public constructor found for {type.Name}");

        var parameters = constructor.GetParameters()
                                    .Select(p => Resolve(p.ParameterType))
                                    .ToArray();

        return constructor.Invoke(parameters);
    }
}
