namespace EmployeeAccountingSystem.Exceptions;

public class UserIdAlreadyExistsException : Exception
{
    public UserIdAlreadyExistsException(int id)
        : base($"Сотрудник с Id {id} уже существует.") { }
}