namespace PhoneBook;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        PhoneBook phoneBook = PhoneBook.getInstance();
        ConsoleManager consoleManager = new ConsoleManager(phoneBook);
        
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Меню ===");
            Console.WriteLine("1. Добавить пользователя");
            Console.WriteLine("2. Просмтор всех порльзователей");
            Console.WriteLine("3. Удаление пользователя");
            Console.WriteLine("4. Поиск по имени");
            Console.WriteLine("5. Поиск по номеру");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            switch (Console.ReadLine())
            {
                case "1":
                    consoleManager.CreateAbonent();
                    break;
                case "2":
                    consoleManager.ViewAbonents();
                    break;
                case "3":
                    consoleManager.DeleteAbonent();
                    break;
                case "4":
                    consoleManager.FindAbonentByName();
                    break;
                case "5":
                    consoleManager.FindAbonentByPhone();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Нет такого варианта действия");
                    Console.ReadKey();
                    break;
            }
        }
    }
}