using System;

namespace Lab12
{
    //Factory for SerializerDeserializer creation
    class PhoneSerialzierDeserializerFactory
    {
        public SerializerDeserializer CreateSerializerDeserializerForFile(String fileName)
        {
            string[] nameElements = fileName.Split('.');
            string fileExtension = nameElements[nameElements.Length - 1];
            switch (fileExtension.ToLower())
            {
                case "bin": return new BinarySerializerDeserializer();
                case "txt": return new TextSerializerDeserializer();
                case "xml": return new XmlSerializerDeserializer();
                default: throw new Exception("Unsupported file type");
            }
        }
    }
}
