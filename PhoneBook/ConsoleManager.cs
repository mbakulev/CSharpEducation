namespace PhoneBook;

public class ConsoleManager
{
    private PhoneBook phoneBook;
    public ConsoleManager(PhoneBook phoneBook)
    {
        this.phoneBook = phoneBook;
    }
    public void CreateAbonent()
    {
        Console.Write("Полное имя: ");
        string name = Console.ReadLine();

        Console.Write("Номер телефона: ");
        string phone = Console.ReadLine();

        if (phoneBook.IsPhoneNumberUsed(phone))
        {
            Console.WriteLine("Номер телефона уже есть в телефонной книге");
            Console.ReadKey();
            return;
        }

        Abonent abonent = new Abonent
        {
            FullName = name,
            PhoneNumber = phone,
        };
        phoneBook.Create(abonent);

        Console.WriteLine("Абонент добавлен");
        Console.ReadKey();
    }

    public void ViewAbonents()
    {
        var abonents = phoneBook.ReadAll();

        Console.WriteLine("\n=== Все абоененты ===");
        foreach (var a in abonents)
        {
            Console.WriteLine($"ID: {a.Id}, Имя: {a.FullName}, Номер: {a.PhoneNumber}");
        }
        
        Console.ReadKey();
    }

    public void FindAbonentByName()
    {
        Console.Write("Введи имя: ");
        string name = Console.ReadLine();
        var results = phoneBook.FindByFullNAmeAbonent(name);

        if (results.Count == 0)
        {
            Console.WriteLine("Абоененты не найдены");
        }
        else
        {
            foreach (var a in results)
            {
                Console.WriteLine($"ID: {a.Id}, Имя: {a.FullName}, Номер: {a.PhoneNumber}");
            }
        }

        Console.ReadKey();
    }
    
    public void FindAbonentByPhone()
    {
        Console.Write("Введи номер: ");
        string phone = Console.ReadLine();
        Abonent abonent = phoneBook.FindByNumberAbonent(phone);

        if (abonent == null)
        {
            Console.WriteLine("Абонент не найден");
        }
        else
        {
            Console.WriteLine($"ID: {abonent.Id}, Имя: {abonent.FullName}, Номер: {abonent.PhoneNumber}");
        }
        
        Console.ReadKey();
    }

    public void DeleteAbonent()
    {
        Console.Write("Введите ID удаляемого пользователя: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Неправильный ID");
            Console.ReadKey();
            return;
        }

        phoneBook.Delete(id);
        Console.WriteLine("Абонент удален");
        Console.ReadKey();
    }
}