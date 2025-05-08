namespace InterviewTest.Infrastructure.Entities;

public class Employee
{
    public int ID { get; set; }
    public string Name { get; set; }
    public int? ManagerID { get; set; }
    public bool Enable { get; set; }
    public List<Employee> Employees { get; set; }

    public Employee(int id, string name, int? managerID, bool enable)
    {
        ID = id;
        Name = name;
        ManagerID = managerID;
        Enable = enable;
    }
}