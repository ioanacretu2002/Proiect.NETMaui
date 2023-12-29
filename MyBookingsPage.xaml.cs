using ProiectMedii.Models;
using Plugin.LocalNotification;
namespace ProiectMedii;

public partial class MyBookingsPage : ContentPage
{
	public MyBookingsPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var services = await App.Database.GetServiceModelsAsync();
        ServicePicker.ItemsSource = (System.Collections.IList)services;
        ServicePicker.ItemDisplayBinding = new Binding("Type");

        var artist = await App.Database.GetNailArtistModelsAsync();
        NailArtistPicker.ItemsSource = (System.Collections.IList)artist;
        NailArtistPicker.ItemDisplayBinding = new Binding("Name");

        var items = await App.Database.GetSalonModelsAsync(); 
        NailBarPicker.ItemsSource = (System.Collections.IList)items;
        NailBarPicker.ItemDisplayBinding = new Binding("Details");
    }

    async void SaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (BookingModel)BindingContext;
        slist.Date = slist.Date + slist.Time;

        // Set the ServiceType, NailArtistName, and SalonDetails properties
        slist.ServiceType = ((ServiceModel)ServicePicker.SelectedItem).Type;
        slist.NailArtistName = ((NailArtistModel)NailArtistPicker.SelectedItem).Name;
        slist.SalonDetails = ((SalonModel)NailBarPicker.SelectedItem).Details;

        await App.Database.SaveBookingModelAsync(slist);
        await Navigation.PopAsync();

        if (DateTime.Now.AddDays(1) >= slist.Date)
        {
            var request = new NotificationRequest
            {
                Title = "You have an appointment tomorrow! " + slist.ID,
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = DateTime.Now.AddSeconds(1)
                }
            };
            await LocalNotificationCenter.Current.Show(request);
        }
    }
    async void DeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (BookingModel)BindingContext;
        await App.Database.DeleteBookingModelAsync(slist);
        await Navigation.PopAsync();
    }

}