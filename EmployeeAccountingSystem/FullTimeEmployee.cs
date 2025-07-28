namespace EmployeeAccountingSystem;

public class FullTimeEmployee : Employee
{
    public override decimal CalculateSalary()
    {
        return BaseSalary;
    }
} 
