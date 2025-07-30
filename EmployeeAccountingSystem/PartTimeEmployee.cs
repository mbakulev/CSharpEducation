namespace EmployeeAccountingSystem;

public class PartTimeEmployee : Employee
{
    /// <summary>
    /// Количество рабочих часов работника
    /// </summary>
    public int HoursWorked { get; set; }
    /// <summary>
    /// Часовая ставка работника
    /// </summary>
    public decimal HourlyRate { get; set; }

    /// <summary>
    /// Переопределенный метод подсчета зарплаты работника
    /// </summary>
    public override decimal CalculateSalary()
    {
        return HoursWorked * HourlyRate;
    }
}
