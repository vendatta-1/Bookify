using Bookify.Application.Abstractions.Data;
using Microsoft.Extensions.Logging;
using Npgsql;
using System.Data;

namespace Bookify.Infrastructure.Data
{
    internal sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _connectionString;
        private readonly ILogger<SqlConnectionFactory> _logger;
        public SqlConnectionFactory(string connectionString, ILogger<SqlConnectionFactory> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }
        public IDbConnection CreateConnection()
        {
            try
            {
                var connection = new NpgsqlConnection(_connectionString);

                connection.Open();

                return connection;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);

                throw;
            }

        }
    }
}
