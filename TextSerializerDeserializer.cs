using System.Collections.Generic;
using System.IO;

namespace Lab12
{
    public class TextSerializerDeserializer : SerializerDeserializer
    {
        public List<Phone> Deserialize(string fileName)
        {
            string[] fileLines = File.ReadAllLines(fileName);
            List<Phone> result = new List<Phone>();
            for (int i = 0; i < fileLines.Length; i += 3)
            {
                result.Add(new Phone(fileLines[i], fileLines[i + 1], fileLines[i + 2]));
            }
            return result;
        }

        public void Serialize(string fileName, List<Phone> phones)
        {
            StreamWriter fileStream = new StreamWriter(fileName);
            foreach (Phone phone in phones)
            {
                fileStream.WriteLine(phone.IMEI);
                fileStream.WriteLine(phone.Model);
                fileStream.WriteLine(phone.Manufacturer);
            }
            fileStream.Flush();
            fileStream.Close();
        }
    }
}
