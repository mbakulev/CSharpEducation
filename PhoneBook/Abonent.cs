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
    
    public string ToDataString()
    {
        return $"{Id}|{FullName}|{PhoneNumber}";
    }
    
    public static Abonent FromDataString(string data)
    {
        var splittedStrings = data.Split('|');
        return new Abonent
        {
            Id = int.Parse(splittedStrings[0]),
            FullName = splittedStrings[1],
            PhoneNumber = splittedStrings[2],
        };
    }
}