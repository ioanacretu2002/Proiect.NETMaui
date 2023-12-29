using ProiectMedii.Models;
namespace ProiectMedii;

public partial class MySalonsPage : ContentPage
{
	public MySalonsPage()
	{
		InitializeComponent();
	}
    async void SaveNailBar(object sender, EventArgs e)
    {
        var salon = (SalonModel)BindingContext;
        await App.Database.SaveSalonModelAsync(salon);
        await Navigation.PopAsync();
    }
    async void DeleteNailBar(object sender, EventArgs e)
    {
        var salon = (SalonModel)BindingContext;
        await App.Database.DeleteSalonModelAsync(salon);
        await Navigation.PopAsync();
    }
    async void ShowOnMapClicked(object sender, EventArgs e)
    {
        var salon = (SalonModel)BindingContext;
        var adresa = salon.Address;
        var locations = await Geocoding.GetLocationsAsync(adresa);
        var options = new MapLaunchOptions { Name = salon.Name };
        var location = locations?.FirstOrDefault();
        var myLocation = await Geolocation.GetLocationAsync();
        //var myLocation = new Location(46.7731796289, 23.6213886738);
        await Map.OpenAsync(location, options);
    }
}