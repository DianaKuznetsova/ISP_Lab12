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

    }
}
