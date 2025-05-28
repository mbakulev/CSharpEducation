namespace PhoneBook;

/// <summary>
/// Синглтон класс телефонной книги
/// </summary>
public class PhoneBook
{
    private static PhoneBook instance;
    private const string FilePath = "phonebook.txt";
    private List<Abonent> abonents;
    private PhoneBook()
    {
        CreateIfNotExistsFile();
        LoadAbonentsFromFile();
    }

    public static PhoneBook getInstance()
    {
        if (instance == null)
            instance = new PhoneBook();
        return instance;
    }
    
    public void LoadAbonentsFromFile()
    {
        abonents = ReadFromTxt();
    }

    public void CreateIfNotExistsFile()
    {
        if (!File.Exists(FilePath))
        {
            File.Create(FilePath).Close();
        }
    }
    
    public List<Abonent> ReadFromTxt()
    {
        if (!File.Exists(FilePath)) return new List<Abonent>();

        return File.ReadAllLines(FilePath)
            .Where(line => !string.IsNullOrWhiteSpace(line))
            .Select(Abonent.FromDataString)
            .ToList();
    }
    
    public void Create(Abonent abonent)
    {
        if (IsPhoneNumberUsed(abonent.PhoneNumber)) return;
        abonent.Id = GetNextId();
        File.AppendAllText(FilePath, abonent.ToDataString() + Environment.NewLine);
    }
    
    public bool IsPhoneNumberUsed(string phoneNumber)
    {
        return abonents.Any(a => a.PhoneNumber == phoneNumber);
    }

    public Abonent FindByFullNAmeAbonent(string fullName)
    {
        var index = abonents.FindIndex(a => a.FullName == fullName);
        if (index != -1)
        {
            return abonents[index];
        }
        else
        {
            return null;
        }
    }
    
    public Abonent FindByNumberAbonent(string number)
    {
        var index = abonents.FindIndex(a => a.PhoneNumber == number);
        if (index != -1)
        {
            return abonents[index];
        }
        else
        {
            return null;
        }
    }
    
    public void Update(Abonent updated)
    {
        var index = abonents.FindIndex(a => a.Id == updated.Id);
        Console.WriteLine("index " + index);
        if (index != -1)
        {
            abonents[index] = updated;
            SaveAllToTxt();
        }
    }
    
    public void Delete(int id)
    {
        abonents = abonents.Where(a => a.Id != id).ToList();
        SaveAllToTxt();
    }
    
    private void SaveAllToTxt()
    {
        File.WriteAllLines(FilePath, abonents.Select(a => a.ToDataString()));
    }
    
    private int GetNextId()
    {
        var abonents = ReadFromTxt();
        return abonents.Count == 0 ? 1 : abonents.Max(a => a.Id) + 1;
    }
}