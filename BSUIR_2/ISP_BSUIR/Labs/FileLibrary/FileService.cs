using System.Text.Json;
using _353503_Бахмат_Lab6;

namespace FileLibrary
{
    public class FileService<T> : IFileService<T> where T : class
    {
        public IEnumerable<T> ReadFile(string fileName)
        {
            if (!File.Exists(fileName)) return new List<T>();

            var json = File.ReadAllText(fileName);
            return JsonSerializer.Deserialize<IEnumerable<T>>(json);
        }

        public void SaveData(IEnumerable<T> data, string fileName)
        {
            var json = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, json);
        }
    }
}
