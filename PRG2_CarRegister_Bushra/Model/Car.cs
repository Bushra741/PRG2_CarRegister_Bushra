namespace PRG2_CarRegister_Bushra.Model
{
    public class StandardCar : Vehicle
    {
        private int doors;

        public StandardCar(string registrationNumber, string manufacturer, string model, int year, int doors)
    : base(registrationNumber, manufacturer, model, year)
        {
            
                Doors = doors;
            
        }
        public int Doors
        {
             get { return doors; }

            set {
                if (value < 1 || value > 6)
                {
                    throw new ArgumentException("Antal dörrar måste vara mellan 1 och 6.");
                }

                doors = value; }
        }

        public override string GetDescription()
{
    return $"{base.RegistrationNumber}\t{base.Manufacturer}\t{base.Model}\t{base.Year}\t{Doors}";
}
    }
}