using ProiectMedii.Models;

namespace ProiectMedii;

public partial class MySalonsEntryPage : ContentPage
{
	public MySalonsEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetSalonModelsAsync();
    }
    async void AddNailBarClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MySalonsPage
        {
            BindingContext = new SalonModel()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null) { await Navigation.PushAsync(new MySalonsPage { BindingContext = e.SelectedItem as SalonModel }); }
    }
}