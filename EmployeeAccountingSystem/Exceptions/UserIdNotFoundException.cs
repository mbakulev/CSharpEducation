namespace EmployeeAccountingSystem.Exceptions;

public class UserIdNotFoundException : Exception
{
    public UserIdNotFoundException(int id)
        : base($"Сотрудник с Id {id} не найден.") { }
}