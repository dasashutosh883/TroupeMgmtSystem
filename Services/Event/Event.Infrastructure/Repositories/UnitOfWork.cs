using Event.Core.Repositories;
namespace Event.Infrastructure.Repositories;

/// <summary>
/// Unit of Work implementation for the Event module.
/// </summary>
/// <remarks>
/// This class implements the IUnitOfWork interface and provides access to the repositories used in the Event module.
/// </remarks>
internal class UnitOfWork : IUnitOfWork
{

    public IEventRepository Event { get; }

    public UnitOfWork(IEventRepository events)
    {
        Event = events ?? throw new ArgumentNullException(nameof(events));
    }

    public void Dispose()
    {
        System.GC.SuppressFinalize(this);
    }
}