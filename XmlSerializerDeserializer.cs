using System.Collections.Generic;
using System.Xml;

namespace Lab12
{
    class XmlSerializerDeserializer : SerializerDeserializer
    {
        public List<Phone> Deserialize(string fileName)
        {
            XmlDocument file = new XmlDocument();
            file.Load(fileName);
            XmlNode phonesNode = file.DocumentElement;
            List<Phone> result = new List<Phone>();
            foreach (XmlNode phoneNode in phonesNode.ChildNodes)
            {
                result.Add(new Phone(phoneNode.Attributes["IMEI"].Value,
                    phoneNode.Attributes["Model"].Value,
                    phoneNode.Attributes["Manufacturer"].Value));
            }
            return result;
        }

        public void Serialize(string fileName, List<Phone> phones)
        {
            XmlDocument file = new XmlDocument();
            XmlNode phonesNode = file.CreateElement("phones");
            file.AppendChild(phonesNode);
            foreach (Phone phone in phones)
            {
                XmlElement phoneNode = file.CreateElement("phone");
                phoneNode.SetAttribute("IMEI", phone.IMEI);
                phoneNode.SetAttribute("Model", phone.Model);
                phoneNode.SetAttribute("Manufacturer", phone.Manufacturer);
                phonesNode.AppendChild(phoneNode);
            }
            file.Save(fileName);
        }
    }
}
