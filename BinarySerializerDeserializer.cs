using System.Collections.Generic;
using System.IO;

namespace Lab12
{
    public class BinarySerializerDeserializer : SerializerDeserializer
    {
        public List<Phone> Deserialize(string fileName)
        {
            BinaryReader file = new BinaryReader(File.OpenRead(fileName));
            List<Phone> result = new List<Phone>();
            while (file.BaseStream.Position != file.BaseStream.Length)
            {
                result.Add(new Phone(file.ReadString(), file.ReadString(), file.ReadString()));
            }
            file.Close();
            return result;
        }

        public void Serialize(string fileName, List<Phone> phones)
        {
            BinaryWriter file = new BinaryWriter(File.OpenWrite(fileName));
            foreach (Phone phone in phones)
            {
                file.Write(phone.IMEI);
                file.Write(phone.Model);
                file.Write(phone.Manufacturer);
            }
            file.Flush();
            file.Close();
        }
    }
}
