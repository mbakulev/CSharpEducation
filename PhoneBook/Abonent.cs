namespace PhoneBook;

/// <summary>
/// Класс абонентов
/// </summary>
public class Abonent
{
    private int Id { get; set; }
    private string FullName { get; set; }
    private string PhoneNumber { get; set; }
    
    private static int AbonentCount = 0;

    private void IncrementAbonentCount()
    {
        AbonentCount++;
    }

    public int GetAbonentCount()
    {
        return AbonentCount;
    }
}