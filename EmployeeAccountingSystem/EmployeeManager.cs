namespace EmployeeAccountingSystem;

public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
{
    /// <summary>
    /// Список работников
    /// </summary>
    private List<T> employees = new List<T>();

    /// <summary>
    /// Добавление работника в список
    /// </summary>
    public void Add(T employee)
    {
        employees.Add(employee);
    }

    /// <summary>
    /// Чтение работника из списка
    /// </summary>
    public T Get(string name)
    {
        return employees.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Обновление данных работника в списке
    /// </summary>
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

