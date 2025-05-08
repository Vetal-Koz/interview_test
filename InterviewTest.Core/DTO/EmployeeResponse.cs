namespace InterviewTest.Core.DTO;

public class EmployeeResponse
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int? ManagerID { get; set; }
    public List<EmployeeWrapper> Employees { get; set; } = new List<EmployeeWrapper>();
}