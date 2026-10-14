namespace PRG2_CarRegister_Bushra.Model
{
    public class Car : Vehicle
    {
        private int doors;

        public Car(string registrationNumber, string manufacturer, string model, int year, int doors)
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
   return $"Car\t{RegistrationNumber}\t{Manufacturer}\t{Model}\t{Year}\t{Doors}";
}
    }
}