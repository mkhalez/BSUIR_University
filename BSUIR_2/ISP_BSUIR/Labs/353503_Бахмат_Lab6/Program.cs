using _353503_Бахмат_Lab6;
using System.Reflection;
class Program
{
    static void Main()
    {
        var employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Анна", Age = 28, IsActive = true, IsManager = false },
            new Employee { Id = 2, Name = "Владимир", Age = 34, IsActive = true, IsManager = true },
            new Employee { Id = 3, Name = "Николай", Age = 26, IsActive = false, IsManager = false },
            new Employee { Id = 4, Name = "Екатерина", Age = 40, IsActive = true, IsManager = true },
            new Employee { Id = 5, Name = "Геннадий", Age = 22, IsActive = true, IsManager = false }
        };

        string fileName = "employees.json";

        string libraryPath = Path.Combine(Directory.GetCurrentDirectory(), "FileLibrary.dll");
        Assembly assembly = Assembly.LoadFrom(libraryPath);

        Type fileServiceType = assembly.GetType("FileLibrary.FileService`1").MakeGenericType(typeof(Employee));
        dynamic fileService = Activator.CreateInstance(fileServiceType);

        fileService.SaveData(employees, fileName);

        IEnumerable<Employee> loadedEmployees = fileService.ReadFile(fileName);
        foreach (var emp in loadedEmployees)
        {
            Console.WriteLine($"{emp.Id}: {emp.Name}, Возраст: {emp.Age}, Активность: {emp.IsActive}, Менеджер: {emp.IsManager}");
        }
    }
}
