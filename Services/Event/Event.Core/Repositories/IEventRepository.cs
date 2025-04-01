using Event.Core.Entities;


namespace Event.Core.Repositories
{
    public interface IEventRepository:IAsyncRepository<EventDetails, int>
    {
        public Task<EventDetails> GetEventByIdAsync(int id);
        public Task<IEnumerable<EventDetails>> GetAllEventsAsync();
        public Task<EventDetails> AddEventAsync(EventDetails eventDetails);
        public Task<EventDetails> UpdateEventAsync(EventDetails eventDetails);
        public Task<bool> DeleteEventAsync(int id);
        public Task<bool> EventExistsAsync(int id);
    }
}