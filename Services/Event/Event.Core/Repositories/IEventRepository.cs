using Event.Core.Entities;


namespace Event.Core.Repositories
{
    public interface IEventRepository:IAsyncRepository<EventDetails>
    {
      //  Task<int> CountAsync();
       // Task<IEnumerable<EventDetails>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    }
}