using InterviewTest.Infrastructure.Entities;

namespace InterviewTest.Core.RepositoryContracts;

public interface IEmployeeRepository
{
    Task<Employee?> GetEmployeeByID(int id);

    Task EnableEmployee(int id, bool enable);
}