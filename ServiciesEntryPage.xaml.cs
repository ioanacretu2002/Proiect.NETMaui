using ProiectMedii.Models;
namespace ProiectMedii;

public partial class ServiciesEntryPage : ContentPage
{
	public ServiciesEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetServiceModelsAsync();
    }
    async void OnServiceAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ServicesPage
        {
            BindingContext = new ServiceModel()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ServicesPage
            {
                BindingContext = e.SelectedItem as ServiceModel
            });
        }
    }

}