using _353503_Бахмат_Lab4.Contracts;
using _353503_Бахмат_Lab4.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _353503_Бахмат_Lab4.Services
{
    public class FileService : IFileService<Baggage>
    {
        public IEnumerable<Baggage> ReadFile(string fileName)
        {
             var reader = new BinaryReader(File.Open(fileName, FileMode.Open));
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    string name = reader.ReadString();
                    int weight = reader.ReadInt32();
                    bool isOverweight = reader.ReadBoolean();
                    yield return new Baggage(name, weight, isOverweight);
                }
            }

           
        }

        public void SaveData(IEnumerable<Baggage> data, string fileName)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var writer = new BinaryWriter(File.Open(fileName, FileMode.Create));
            {
                foreach (var item in data)
                {
                    writer.Write(item.Name);
                    writer.Write(item.Weight);
                    writer.Write(item.IsOverweight);
                }
            }
        }
    }
}
