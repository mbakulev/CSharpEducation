namespace PhoneBook;

/// <summary>
/// Синглтон класс телефонной книги
/// </summary>
public class PhoneBook
{
    private static PhoneBook instance;

    private PhoneBook()
    {
        
    }

    public static PhoneBook getInstance()
    {
        if (instance == null)
            instance = new PhoneBook();
        return instance;
    }
}