using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Lab12.Tests
{
    public class TextSerializerDeserializerTests
    {
        [Fact]
        public void SerializerTest()
        {
            List<Phone> phones = new List<Phone>() {
               new Phone("120", "Redmi 4", "Xiaomi")

            };

            string s = "120Redmi 4Xiaomi";

            string fileName = "test_text.txt";
            TextSerializerDeserializer textSerializer = new TextSerializerDeserializer();
            textSerializer.Serialize(fileName, phones);

            StreamReader reader = new StreamReader("test_text.txt");
            string line;
            string result = "";
            while ((line = reader.ReadLine()) != null)
            {
                result = result + line;

            }
            Assert.Equal(s, result);
        }

        [Fact]
        public void DeserializerTest()
        {
            string fileName = "test_deserializer.txt";
            List<Phone> phones = new List<Phone>() {
               new Phone("120", "Redmi 4", "Xiaomi")

            };

            StreamWriter fileStream = new StreamWriter(fileName);
            foreach (Phone phone in phones)
            {
                fileStream.WriteLine(phone.IMEI);
                fileStream.WriteLine(phone.Model);
                fileStream.WriteLine(phone.Manufacturer);
            }
            fileStream.Flush();
            fileStream.Close();

            TextSerializerDeserializer textDeserializer = new TextSerializerDeserializer();
            List<Phone> result = textDeserializer.Deserialize(fileName);

            Assert.Equal(phones, result);
        }
    }
}
