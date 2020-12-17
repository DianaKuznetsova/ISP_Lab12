using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Lab12.Tests
{
    public class TextSerializerDeserializerTests
    {
        private const string FILE_CONTENT = "120\r\nRedmi 4\r\nXiaomi\r\n";
        private List<Phone> PHONES_LIST = new List<Phone>() {
            new Phone("120", "Redmi 4", "Xiaomi")
        };

        [Fact]
        public void SerializerTest()
        {
            string fileName = "test_text.txt";
            TextSerializerDeserializer textSerializer = new TextSerializerDeserializer();
            textSerializer.Serialize(fileName, PHONES_LIST);

            string result = File.ReadAllText(fileName);

            Assert.Equal(FILE_CONTENT, result);
        }

        [Fact]
        public void DeserializerTest()
        {
            string fileName = "test_deserialize.txt";

            File.WriteAllText(fileName, FILE_CONTENT);

            TextSerializerDeserializer textDeserializer = new TextSerializerDeserializer();
            List<Phone> result = textDeserializer.Deserialize(fileName);

            Assert.Equal(PHONES_LIST, result);
        }
    }
}
