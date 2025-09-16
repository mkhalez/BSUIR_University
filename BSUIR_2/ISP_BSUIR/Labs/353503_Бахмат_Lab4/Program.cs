using _353503_Бахмат_Lab4.Entities;
using _353503_Бахмат_Lab4.Services;

class Program
{
    static void Main(string[] args)
    {
        string projectDirectory = Directory.GetCurrentDirectory();
        string folderPath = Path.Combine(projectDirectory, "Бахмат_Lab4");

        if (Directory.Exists(folderPath))
        {
            Directory.Delete(folderPath, true);
            Console.WriteLine($"Папка {folderPath} удалена.");
        }
        Directory.CreateDirectory(folderPath);
        Console.WriteLine($"Папка {folderPath} успешно создана.");


        Random random = new Random();
        List<string> extensions = new List<string>{ ".txt", ".rtf", ".dat", ".inf" };
        for (int i = 0; i < 10; i++)
        {
            string randomFileName = Path.Combine(folderPath, Path.GetRandomFileName().Replace(".", "") + extensions[random.Next(extensions.Count)]);
            File.Create(randomFileName).Dispose();
        }


        string[] files = Directory.GetFiles(folderPath);
        foreach (var file in files)
        {
            Console.WriteLine($"Файл: {Path.GetFileName(file)} имеет расширение {Path.GetExtension(file)}");
        }


        List<Baggage> baggageList = new List<Baggage>
            {
                new Baggage("Алексей", 25, false),
                new Baggage("Всеволод", 30, true),
                new Baggage("Добрыня", 15, false),
                new Baggage("Валера", 40, true),
                new Baggage("Илья", 10, false)
            };

        FileService fileService = new FileService();
        string dataFileName = Path.Combine(folderPath, "baggageData.dat");
        fileService.SaveData(baggageList, dataFileName);
        string newDataFileName = Path.Combine(folderPath, "renamedBaggageData.dat");
        File.Move(dataFileName, newDataFileName);

        IEnumerable<Baggage> loadedBaggage = fileService.ReadFile(newDataFileName).ToList();
        Console.WriteLine("\nИсходная коллекция:");
        foreach (var baggage in baggageList)
        {
            Console.WriteLine(baggage);
        }

        var sortedByName = loadedBaggage.OrderBy(b => b, new MyCustomComparer()).ToList();
        Console.WriteLine("\nОтсортированная коллекция по имени:");
        foreach (var baggage in sortedByName)
        {
            Console.WriteLine(baggage);
        }

        var sortedByWeight = loadedBaggage.OrderBy(b => b.Weight).ToList();
        Console.WriteLine("\nОтсортированная коллекция по весу:");
        foreach (var baggage in sortedByWeight)
        {
            Console.WriteLine(baggage);
        }
    }
}