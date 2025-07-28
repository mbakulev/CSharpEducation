namespace EmployeeAccountingSystem;

public abstract class Employee
{
    public string Name { get; set; }
    public decimal BaseSalary { get; set; }

    public abstract decimal CalculateSalary();
}