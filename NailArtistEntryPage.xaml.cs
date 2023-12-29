using ProiectMedii.Models;
namespace ProiectMedii;

public partial class NailArtistEntryPage : ContentPage
{
	public NailArtistEntryPage()
	{
		InitializeComponent();
	}
	protected override async void OnAppearing()
	{
        base.OnAppearing();
        listArtistView.ItemsSource = await App.Database.GetNailArtistModelsAsync();
    }
    async void OnNailArtistAddedClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new NailArtistPage
		{
            BindingContext = new NailArtistModel()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new NailArtistPage
            {
                BindingContext = e.SelectedItem as NailArtistModel
            });
        }
    }
}