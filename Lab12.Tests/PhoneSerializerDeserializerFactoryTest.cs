using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Lab12.Tests
{
    public class PhoneSerializerDeserializerFactoryTest
    {
        [Fact]
        public void TestTextSerializerDeserializer()
        {
            SerializerDeserializer serializer = new PhoneSerialzierDeserializerFactory().CreateSerializerDeserializerForFile("test.txt");
            Assert.IsType<TextSerializerDeserializer>(serializer);
        }

        [Fact]
        public void TestBinSerializerDeserializer()
        {
            SerializerDeserializer serializer = new PhoneSerialzierDeserializerFactory().CreateSerializerDeserializerForFile("test.bin");
            Assert.IsType<BinarySerializerDeserializer>(serializer);
        }

        [Fact]
        public void TestXmlSerializerDeserializer()
        {
            SerializerDeserializer serializer = new PhoneSerialzierDeserializerFactory().CreateSerializerDeserializerForFile("test.xml");
            Assert.IsType<XmlSerializerDeserializer>(serializer);
        }

        [Fact]
        public void TestUnsupportedFileExtension()
        {
            Assert.Throws<Exception>(() =>
            {
                new PhoneSerialzierDeserializerFactory().CreateSerializerDeserializerForFile("test.csv");
            });
        }
    }
}
