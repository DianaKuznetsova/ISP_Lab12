using System.Collections.Generic;

namespace Lab12
{
    //Abstract factory
    public interface SerializerDeserializer
    {
        public List<Phone> Deserialize(string fileName);
        public void Serialize(string fileName, List<Phone> phones);
    }
}
