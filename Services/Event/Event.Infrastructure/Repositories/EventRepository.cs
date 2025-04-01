using System.Data;
using Dapper;
using Event.Core.Entities;
using Event.Core.Repositories;
using Event.Infrastructure.Context;
namespace Event.Infrastructure.Repositories;
public class EventRepository :  IEventRepository
{
    private readonly DapperContext _applicationContext;
    private readonly string _storedProcedureName;
    public EventRepository(DapperContext applicationContext)
    {
        _applicationContext = applicationContext ?? throw new ArgumentNullException(nameof(applicationContext));
        _storedProcedureName = "USP_MANAGEEVENT";
    }

    public async Task<bool> AddAsync(EventDetails eventDetails)
    {
        using (var connection = _applicationContext.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Operation", "CREATE");
            parameters.Add("@Name", eventDetails.Name);
            parameters.Add("@Description", eventDetails.Description);
            parameters.Add("@StartDate", eventDetails.StartDate);
            parameters.Add("@EndDate", eventDetails.EndDate);
            parameters.Add("@Location", eventDetails.Location);

            var result = await connection.ExecuteAsync(_storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using (var connection = _applicationContext.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Operation", "DELETE");
            parameters.Add("@Id", id);

            var result = await connection.ExecuteAsync(_storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }


    public async Task<IEnumerable<EventDetails>> GetAllAsync()
    {
        using (var connection = _applicationContext.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Operation", "READ_ALL");

            var events = await connection.QueryAsync<EventDetails>(_storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            return events;
        }
    }

    public async Task<EventDetails> GetByIdAsync(int id)
    {
        using (var connection = _applicationContext.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Operation", "READ_SINGLE");
            parameters.Add("@Id", id);

            var eventDetails = await connection.QuerySingleOrDefaultAsync<EventDetails>(_storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            return eventDetails?? new EventDetails();
        }
    }

    public async Task<bool> UpdateAsync(EventDetails eventDetails)
    {
        using (var connection = _applicationContext.CreateConnection())
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Operation", "UPDATE");
            parameters.Add("@Id", eventDetails.Id);
            parameters.Add("@Name", eventDetails.Name);
            parameters.Add("@Description", eventDetails.Description);
            parameters.Add("@StartDate", eventDetails.StartDate);
            parameters.Add("@EndDate", eventDetails.EndDate);
            parameters.Add("@Location", eventDetails.Location);

            var result=await connection.ExecuteAsync(_storedProcedureName, parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }
    }

}