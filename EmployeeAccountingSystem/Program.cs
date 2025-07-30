using EmployeeAccountingSystem.Exceptions;

namespace EmployeeAccountingSystem;

class Program
{
    static EmployeeManager<Employee> manager = new EmployeeManager<Employee>();
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\n");
            Console.WriteLine("1. Добавить сотрудника, работающего полный день");
            Console.WriteLine("2. Добавить сотрудника, работающего по часам");
            Console.WriteLine("3. Получить информацию о сотруднике");
            Console.WriteLine("4. Обновить данные сотрудника");
            Console.WriteLine("5. Удалить сотрудника");
            Console.WriteLine("6. Выйти");
            Console.Write("Выберите действие: ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    AddFullTimeEmployee();
                    break;
                case "2":
                    AddPartTimeEmployee();
                    break;
                case "3":
                    GetEmployeeInfo();
                    break;
                case "4":
                    UpdateEmployee();
                    break;
                case "5":
                    DeleteEmployee();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
        }
    }

    static void AddFullTimeEmployee()
    {
        Console.Write("Введите ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();
        Console.Write("Введите базовую зарплату: ");
        decimal salary = decimal.Parse(Console.ReadLine());

        var employee = new FullTimeEmployee { Name = name, BaseSalary = salary };
        try
        {
            manager.Add(employee);
            Console.WriteLine("Сотрудник на полный рабочий день добавлен.");
        }
        catch (UserIdAlreadyExistsException ex)
        {
            Console.WriteLine("Ошибка добавления сотрудника с Id: " + id);
        }
    }

    static void AddPartTimeEmployee()
    {
        Console.Write("Введите ID: ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("Введите имя: ");
        string name = Console.ReadLine();
        Console.Write("Введите количество часов: ");
        int hours = int.Parse(Console.ReadLine());
        Console.Write("Введите ставку за час: ");
        decimal rate = decimal.Parse(Console.ReadLine());

        var employee = new PartTimeEmployee
        {
            Name = name,
            HoursWorked = hours,
            HourlyRate = rate,
            BaseSalary = 0
        };

        try
        {
            manager.Add(employee);
        }
        catch (UserIdAlreadyExistsException ex)
        {
            Console.WriteLine("Ошибка добавления сотрудника c ID: " + id);
        }
        Console.WriteLine("Почасовой сотрудник добавлен.");
    }

    static void GetEmployeeInfo()
    {
        // Console.Write("Введите имя сотрудника: ");
        // string name = Console.ReadLine();
        Console.Write("Введите ID: ");
        int id = int.Parse(Console.ReadLine());
        try
        {
            var employee = manager.Get(id);
            if (employee != null)
            {
                Console.WriteLine($"Имя: {employee.Name}");
                Console.WriteLine($"Тип: {(employee is FullTimeEmployee ? "Полный рабочий день" : "Почасовой")}");
                Console.WriteLine($"Зарплата: {employee.CalculateSalary()}");
            }
        }
        catch (UserIdNotFoundException ex)
        {
            Console.WriteLine("Сотрудник не найден: " + id);
        }
    }

    static void UpdateEmployee()
    {
        // Console.Write("Введите имя сотрудника: ");
        // string name = Console.ReadLine();
        Console.Write("Введите ID: ");
        int id = int.Parse(Console.ReadLine());
        try
        {
            var existing = manager.Get(id);
            if (existing is FullTimeEmployee)
            {
                Console.Write("Введите новую базовую зарплату: ");
                decimal newSalary = decimal.Parse(Console.ReadLine());

                var updated = new FullTimeEmployee { Name = existing.Name, BaseSalary = newSalary };
                manager.Update(updated);
                Console.WriteLine("Данные обновлены.");
            }
            else if (existing is PartTimeEmployee)
            {
                Console.Write("Введите количество часов: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write("Введите новую ставку: ");
                decimal rate = decimal.Parse(Console.ReadLine());

                var updated = new PartTimeEmployee
                {
                    Name = existing.Name,
                    HoursWorked = hours,
                    HourlyRate = rate
                };
                manager.Update(updated);
                Console.WriteLine("Данные обновлены.");
            }
        }
        catch (UserIdNotFoundException ex)
        {
            Console.WriteLine("Сотрудник не найден:" + id);
        }
    }

    static void DeleteEmployee()
    {
        Console.Write("Введите ID: ");
        int id = int.Parse(Console.ReadLine());

        try
        {
            manager.Delete(id);
            Console.WriteLine("Сотрудник удален ID: " + id);
        }
        catch (UserIdNotFoundException ex)
        {
            Console.WriteLine("Сотрудник не найден:" + id);
        }
    }
}