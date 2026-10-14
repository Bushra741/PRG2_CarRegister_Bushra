namespace PRG2_CarRegister_Bushra.Model
{
    internal class MC : Vehicle
    {
        public string category = string.Empty;
        public MC(string registrationNumber, string manufacturer, string model, int year, string category)
    : base(registrationNumber, manufacturer, model, year)
        {
            Category = category;
        }

        public string Category
        {
            get { return category; }

            set { category = value; }
        }
        public override string GetDescription()
        {
            return $"{base.RegistrationNumber}\t{base.Manufacturer}\t{base.Model}\t{base.Year}\t{category}";
        }
    }
}