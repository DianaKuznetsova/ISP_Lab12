using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using Xunit;

namespace Lab12.Tests
{
    public class XmlSerializerDeserializerTests
    {

        private const string FILE_CONTENT = "<phones>\r\n  <phone IMEI=\"120\" Model=\"Redmi 4\" Manufacturer=\"Xiaomi\" />\r\n</phones>";
        private List<Phone> PHONES_LIST = new List<Phone>() {
               new Phone("120", "Redmi 4", "Xiaomi")
        };

        [Fact]
        public void SerializerTest()
        {
            string fileName = "test_xml.xml";
            XmlSerializerDeserializer xmlSerializer = new XmlSerializerDeserializer();
            xmlSerializer.Serialize(fileName, PHONES_LIST);
            string result = File.ReadAllText(fileName);
            Assert.Equal(FILE_CONTENT, result);
        }

        [Fact]
        public void DeserializerTest()
        {
            string fileName = "test_deserialize.xml";
            File.WriteAllText(fileName, FILE_CONTENT);


            XmlSerializerDeserializer xmlDeserializer = new XmlSerializerDeserializer();
            List<Phone> result = xmlDeserializer.Deserialize(fileName);

            Assert.Equal(PHONES_LIST, result);
        }
    }
}
