namespace EmployeeAccountingSystem;

public class PartTimeEmployee : Employee
{
    public int HoursWorked { get; set; }
    public decimal HourlyRate { get; set; }

    public override decimal CalculateSalary()
    {
        return HoursWorked * HourlyRate;
    }
}
