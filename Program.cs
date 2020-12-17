using System;
using System.Collections.Generic;

namespace Lab12
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phones = new List<Phone>() {
                CreatePhone("Redmi 4", "Xiaomi"),
                CreatePhone("S20", "Samsung"),
                CreatePhone("Pixel 4", "Google"),
                CreatePhone("Mi A1", "Xiaomi"),
                CreatePhone("iPhone 12 Mini", "Apple")
            };

            Console.WriteLine("Checking binary fomat");
            TestSerializerDeserializer(phones, "test_binary.bin");
            Console.WriteLine("Binary check success");

            Console.WriteLine("Checking text fomat");
            TestSerializerDeserializer(phones, "test_text.txt");
            Console.WriteLine("Text check success");

            Console.WriteLine("Checking xml fomat");
            TestSerializerDeserializer(phones, "test_xml.xml");
            Console.WriteLine("Xml check success");

            Console.ReadLine();
        }


        private static void TestSerializerDeserializer(List<Phone> phones, string fileName)
        {
            SerializerDeserializer serializerDeserializer =
                new PhoneSerialzierDeserializerFactory().CreateSerializerDeserializerForFile(fileName);
            serializerDeserializer.Serialize(fileName, phones);
            List<Phone> deserializedPhones = serializerDeserializer.Deserialize(fileName);
            CheckEquals(phones, deserializedPhones);
        }

        private static void CheckEquals(List<Phone> expected, List<Phone> actual)
        {
            if (expected.Count != actual.Count)
            {
                throw new Exception("Expected size " + expected.Count + " but was " + actual.Count);
            }
            for (int i = 0; i < expected.Count; i++)
            {
                if (!expected[i].Equals(actual[i]))
                {
                    throw new Exception("Phone is different with index = " + i +
                        "\nExpected " + expected[i] + " but was" + actual[i]);
                }
            }
        }

        //Factory method for Phone creation
        private static Phone CreatePhone(string model, string manufacturer)
        {
            return new Phone(IMEIGenerator.getInstance().GenerateNewIMEI(), model, manufacturer);
        }
    }
}
