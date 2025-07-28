namespace EmployeeAccountingSystem;

public interface IEmployeeManager<T> where T : Employee
{
    void Add(T employee);
    T Get(string name);
    void Update(T employee);
}
