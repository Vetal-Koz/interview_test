using System.Data;
using InterviewTest.Core.RepositoryContracts;
using InterviewTest.Infrastructure.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace InterviewTest.Infrastructure.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;

    public EmployeeRepository(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = configuration.GetConnectionString("MSSQL")!;
    }

    public async Task<Employee?> GetEmployeeByID(int id)
    {
        string query = "SELECT ID, Name, ManagerID, Enable FROM Employee WHERE ID = @id";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter idParameter = new SqlParameter("@id", SqlDbType.Int);
            idParameter.Value = id;

            command.Parameters.Add(idParameter);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                Employee? employee = null;
                if (reader.HasRows)
                {
                    if (await reader.ReadAsync())
                    {
                        employee = new Employee(
                            reader.GetInt32(0),
                            reader.GetString(1),
                            reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2),
                            reader.GetBoolean(3)
                        );
                        employee.Employees = await GetEmployeesByManagerID(employee.ID);
                    }
                }

                return employee;
            }
        }
    }

    public async Task EnableEmployee(int id, bool enable)
    {
        string query = "UPDATE Employee SET Enable = @enable WHERE ID = @id";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter enableParameter = new SqlParameter("@enable", SqlDbType.Bit);
            enableParameter.Value = enable;

            SqlParameter parameter = new SqlParameter("@id", SqlDbType.Int);
            parameter.Value = id;

            command.Parameters.Add(enableParameter);
            command.Parameters.Add(parameter);

            await command.ExecuteNonQueryAsync();
        }
    }


    private async Task<List<Employee>> GetEmployeesByManagerID(int managerID)
    {
        string query = "SELECT ID, Name, ManagerID, Enable FROM Employee WHERE ManagerID = @managerID";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();

            SqlCommand command = new SqlCommand(query, connection);

            SqlParameter idParameter = new SqlParameter("@managerID", SqlDbType.Int);
            idParameter.Value = managerID;

            command.Parameters.Add(idParameter);

            using (SqlDataReader reader = await command.ExecuteReaderAsync())
            {
                List<Employee> employees = new List<Employee>();
                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        employees.Add(new Employee(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetInt32(2),
                                reader.GetBoolean(3)
                            )
                        );
                    }
                }

                return employees;
            }
        }
    }
}