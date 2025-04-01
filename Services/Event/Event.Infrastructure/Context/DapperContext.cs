using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Event.Infrastructure.Context;
/// <summary>
/// DapperContext class for managing database connections.
/// </summary>
/// <remarks>
/// This class is responsible for creating and managing database connections using Dapper.
/// </remarks>
public class DapperContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _connectionString = _configuration.GetConnectionString("DBConnection") ?? throw new ArgumentNullException("Connection string not found.");
    }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}