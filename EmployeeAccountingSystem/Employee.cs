namespace EmployeeAccountingSystem;

public abstract class Employee
{
    /// <summary>
    /// Имя работника
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Базовая зарплата работника
    /// </summary>
    public decimal BaseSalary { get; set; }

    /// <summary>
    /// Абстрактный метод подсчета зарплаты работника
    /// </summary>
    public abstract decimal CalculateSalary();
}