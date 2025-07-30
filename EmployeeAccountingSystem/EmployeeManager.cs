using EmployeeAccountingSystem.Exceptions;

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
        Employee findedEmployee = employees.Find(e => e.Id == employee.Id);
        if (findedEmployee != null) throw new UserIdAlreadyExistsException(employee.Id);
        employees.Add(employee);
    }

    /// <summary>
    /// Чтение работника из списка
    /// </summary>
    public T Get(int userId)
    {
        T findedEmployee = employees.FirstOrDefault(e => e.Id == userId);
        if (findedEmployee == null) throw new UserIdNotFoundException(userId);
        return findedEmployee;
        // return employees.FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Обновление данных работника в списке
    /// </summary>
    public void Update(T employee)
    {
        var existing = Get(employee.Id);
        if (existing != null)
        {
            employees.Remove(existing);
            employees.Add(employee);
        }
    }

    public void Delete(int userId)
    {
        T findedEmployee = employees.FirstOrDefault(e => e.Id == userId);
        if (findedEmployee == null) throw new UserIdNotFoundException(userId);
        employees.Remove(findedEmployee);
    }
}

