using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SearchModule.Contacts;
using SearchModule.Models;
using System.Data.SqlClient;

namespace SearchModule.Data
{
    public class SqlHandler : ISqlHandler
    {
        private readonly string _connectionString;

        public SqlHandler(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IReadOnlyList<User>> SearchInfo(string serchText, CancellationToken cancellationToken = default)
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.OpenAsync(cancellationToken);
            string sqlQuery = "SELECT * FROM Users WHERE CONTAINS((first_name, last_name, email, phone), @SearchTerm)";
            using var command = new SqlCommand(sqlQuery,connection);
            command.Parameters.AddWithValue("@SearchTerm", $"\"*{serchText}*\"");
            using var reader = await command.ExecuteReaderAsync(cancellationToken);

            List<User> data = new List<User>();

            while (await reader.ReadAsync(cancellationToken))
            {
                var item = MapData(reader);
                data.Add(item);
            }
            return data;
        }

        private User MapData(SqlDataReader reader)
        {
            User user = new User{
                Id = (int)reader["id"],
                FirstName = (string)reader["first_name"],
                LastName = (string)reader["last_name"],
                Email = (string)reader["email"],
                Phone = (string)reader["phone"]
            };
            return user;
        }
    }
}