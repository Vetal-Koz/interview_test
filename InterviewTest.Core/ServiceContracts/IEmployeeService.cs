using InterviewTest.Core.DTO;

namespace InterviewTest.Core.ServiceContracts;

public interface IEmployeeService
{
    Task<EmployeeWrapper> GetEmployeeByID(int id);

    Task EnableEmployee(int id, bool enable);
}