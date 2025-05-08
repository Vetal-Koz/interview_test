using AutoMapper;
using InterviewTest.Core.DTO;
using InterviewTest.Core.Exceptions;
using InterviewTest.Core.RepositoryContracts;
using InterviewTest.Core.ServiceContracts;
using InterviewTest.Infrastructure.Entities;

namespace InterviewTest.Core.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }

    public async Task<EmployeeWrapper> GetEmplyeeByID(int id)
    {
        Employee? employee = await _employeeRepository.GetEmployeeByID(id);

        if (employee != null)
        {
            EmployeeWrapper response = _mapper.Map<Employee, EmployeeWrapper>(employee);

            return response;
        }

        throw new EntityNotFoundException($"Employee with Id: {id} not found");
    }

    public async Task EnableEmployee(int id, bool enable)
    {
        await _employeeRepository.EnableEmployee(id, enable);
    }
}