namespace PRG2_CarRegister_Bushra.Model
{
    internal class Truck : Vehicle
    {
        private double loadCapacity;

        public Truck(
    string registrationNumber,
    string manufacturer,
    string model,
    int year,
    double loadCapacity)
    :   base( registrationNumber, manufacturer, model, year)
        {
            LoadCapacity = loadCapacity;
        }
        public double LoadCapacity
        {
            get { return loadCapacity; }

            set { loadCapacity = value; }
        }
        public override string GetDescription()
        {
            return $"{base.RegistrationNumber}\t{base.Manufacturer}\t{base.Model}\t{base.Year}\t{loadCapacity}";
        }
    }
}