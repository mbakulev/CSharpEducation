namespace EmployeeAccountingSystem;

public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
{
    private List<T> employees = new List<T>();

    public void Add(T employee)
    {
        employees.Add(employee);
    }

    public T Get(string name)
    {
        return employees.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public void Update(T employee)
    {
        var existing = Get(employee.Name);
        if (existing != null)
        {
            employees.Remove(existing);
            employees.Add(employee);
        }
    }
}

