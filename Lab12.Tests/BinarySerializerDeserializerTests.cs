using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Lab12.Tests
{
    public class BinarySerializerDeserializerTests
    {
        private byte[] FILE_CONTENT = { 0x03, 0x31, 0x32, 0x30, 0x07, 0x52, 0x65, 0x64, 0x6D, 0x69, 0x20, 0x34, 0x06, 0x58, 0x69, 0x61, 0x6F, 0x6D, 0x69 };
        private List<Phone> PHONES_LIST = new List<Phone>() {
               new Phone("120", "Redmi 4", "Xiaomi")
        };


        [Fact]
        public void SerializerTest()
        {

            string fileName = "test_binary.bin";

            BinarySerializerDeserializer binarySerializer = new BinarySerializerDeserializer();
            binarySerializer.Serialize(fileName, PHONES_LIST);

            byte[] result = File.ReadAllBytes(fileName);
            Assert.Equal(FILE_CONTENT, result);
        }
        [Fact]
        public void DeserializerTest()
        {
            string fileName = "test_deserialize.bin";

            File.WriteAllBytes(fileName, FILE_CONTENT);

            BinarySerializerDeserializer binaryDeserializer = new BinarySerializerDeserializer();
            List<Phone> result = binaryDeserializer.Deserialize(fileName);

            Assert.Equal(PHONES_LIST, result);

        }
    }
}
