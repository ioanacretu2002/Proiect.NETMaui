using ProiectMedii.Models;   
namespace ProiectMedii;

public partial class ServicesPage : ContentPage
{
	public ServicesPage()
	{
		InitializeComponent();
	}
    public async void SaveServiceClicked(object sender, EventArgs e)
    {
        var serviceModel = (ServiceModel)BindingContext;
        await App.Database.SaveServiceModelAsync(serviceModel);
        await Navigation.PopAsync();
    }
    public async void DeleteServiceClicked(object sender, EventArgs e)
    {
        var serviceModel = (ServiceModel)BindingContext;
        await App.Database.DeleteServiceModelAsync(serviceModel);
        await Navigation.PopAsync();
    }
}