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
    T Get(int userId);
    
    /// <summary>
    /// Обновление данных работника
    /// </summary>
    void Update(T employee);

    /// <summary>
    /// Удаление работника
    /// </summary>
    void Delete(int userId);
}
