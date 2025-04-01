namespace Event.Core.Repositories;
public interface IUnitOfWork : IDisposable
{
    IEventRepository Event { get; }
}