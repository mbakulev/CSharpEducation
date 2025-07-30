namespace EmployeeAccountingSystem;

public interface IEmployeeManager<T> where T : Employee
{
    /// <summary>
    /// Добавление работника
    /// </summary>
    void Add(T employee);
    
    /// <summary>
    /// Чтение работника
    /// </summary>
    T Get(string name);
    
    /// <summary>
    /// Обновление данных работника
    /// </summary>
    void Update(T employee);
}
