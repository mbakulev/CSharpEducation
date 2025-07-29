namespace EmployeeAccountingSystem;

public class FullTimeEmployee : Employee
{
    /// <summary>
    /// Переопределенный метод подсчета зарплаты работника
    /// </summary>
    public override decimal CalculateSalary()
    {
        return BaseSalary;
    }
} 
