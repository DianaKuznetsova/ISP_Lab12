using System;

namespace Lab12
{
    class Phone
    {
        public string Manufacturer { get; }
        public string Model { get; }

        public string IMEI { get; } // id

        public Phone(string IMEI, string model, string manufacturer)
        {
            this.IMEI = IMEI;
            this.Model = model;
            this.Manufacturer = manufacturer;
        }

        public override bool Equals(object obj)
        {
            return obj is Phone phone &&
                   Manufacturer == phone.Manufacturer &&
                   Model == phone.Model &&
                   IMEI == phone.IMEI;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Manufacturer, Model, IMEI);
        }

        public override string ToString()
        {
            return "Phone(IMEI=" + IMEI + ";Model=" + Model + ";Manufacturer=" + Manufacturer + ";)";
        }
    }
}
