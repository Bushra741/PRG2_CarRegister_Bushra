
using PRG2_CarRegister_Bushra.Model;
using System.Collections.ObjectModel;

namespace PRG2_CarRegister_Bushra.View;

public partial class MainPage : ContentPage
{
    private readonly ObservableCollection<Vehicle> vehicleList = new  ObservableCollection<Vehicle>() ;

    public MainPage()
    {
        InitializeComponent();

        pickerType.SelectedIndex = 0;

        entryModelYear.ItemsSource =
        Enumerable.Range(1895, DateTime.Today.Year - 1895 + 1).ToList();

        entryModelYear.SelectedItem = DateTime.Today.Year;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {

        try
        {

            // Safely parse the year from the Entry text field
            if (entryModelYear.SelectedItem is not int year)
            {
                await DisplayAlert("Fel", "Välj ett giltigt årstal.", "OK");
                return;

            }


            string registrationNumber = entryRegistrationNumber.Text ?? "";
            string model = entryModel.Text ?? "";
            string manufacturer = entryManufacturer.Text ?? "";


            Vehicle vehicle;

            switch (pickerType.SelectedItem?.ToString())
            {
                case "Bil":

                    if (!int.TryParse(entryDoors.Text, out int doors))
                    {
                        await DisplayAlert(
                            "Fel",
                            "Ange ett giltigt antal dörrar.",
                            "OK");
                        return;
                    }

                    vehicle = new Car(
                        registrationNumber,
                        manufacturer,
                        model,
                        year,
                        doors);

                    break;
           
    

                case "MC":
                    vehicle = new MC(
                        registrationNumber,
                        manufacturer,
                        model,
                        year,
                        "standard");
                    break;

                case "Truck":
                    vehicle = new Truck(
                        registrationNumber,
                        manufacturer,
                        model,
                        year,
                        10000);
                    break;

                default: await DisplayAlert("Fel", "Välj en fordontyp", "OK");
                    return; 
            }

            vehicleList.Add(vehicle);

            listViewVehicles.ItemsSource = null;
            listViewVehicles.ItemsSource = vehicleList;

            ClearTextFields();
        }


        catch (ArgumentException ex)
        {
          await DisplayAlert("Fel", ex.Message, "OK");
        }
    }
    private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value)
            return;

        IEnumerable<Vehicle> filteredList = vehicleList;

        if(radioCar.IsChecked)
        {
            filteredList = vehicleList.OfType<Car>();
        }
        else if (radioMC.IsChecked)
        {

            filteredList = vehicleList.OfType<MC>();
        }
        else if (radioTruck.IsChecked)
        {

            filteredList = vehicleList.OfType<Truck>();
        }
        else
        {
            // Om "Alla" är vald, visa hela listan
            filteredList = vehicleList;
        }

        listViewVehicles.ItemsSource = filteredList;
    }

    private void OnSearchClicked(object sender, EventArgs e)
    {
        string searchTerm = entrySearchRegistrationNumber.Text?.Trim().ToUpper() ?? "";

        if (string.IsNullOrEmpty(searchTerm))
        {
            entrySearchRegistrationNumber.Text = "Ange ett registreringsnummer för att söka.";
            return;
        }

        var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber == searchTerm);

        if (foundVehicle != null)
        {
            labelSearchResult.Text = $"Fordon hittat:\n" +
                                     $"Registreringsnummer: {foundVehicle.RegistrationNumber}\n" +
                                     $"Tillverkare: {foundVehicle.Manufacturer}\n" +
                                     $"Modell: {foundVehicle.Model}\n";
        }
        else
        {
            labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
        }
    }

    private void ClearTextFields()
    {
        entryRegistrationNumber.Text = string.Empty;
        entryManufacturer.Text = string.Empty;
        entryModel.Text = string.Empty;
    }
}
