using ProiectMedii.Models;
namespace ProiectMedii;

public partial class MyBookingsEntryPage : ContentPage
{
	public MyBookingsEntryPage()
	{
		InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Fetch the bookings from the database
        var bookings = await App.Database.GetBookingModelsAsync();

        // Populate the ServiceType, NailArtistName, and SalonDetails properties
        foreach (var booking in bookings)
        {
            var service = await App.Database.GetServiceModelAsync(booking.ServiceID);
            if (service != null)
            {
                booking.ServiceType = service.Type;
            }

            var nailArtist = await App.Database.GetNailArtistModelAsync(booking.NailArtistID);
            if (nailArtist != null)
            {
                booking.NailArtistName = nailArtist.Name;
            }

            var salon = await App.Database.GetSalonModelAsync(booking.SalonID);
            if (salon != null)
            {
                booking.SalonDetails = salon.Details;
            }
        }

        // Bind the bookings to the ListView
        listView.ItemsSource = bookings;
    }
    async void AddBookingClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MyBookingsPage
        {
            BindingContext = new BookingModel()
        });
    }
    async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new MyBookingsPage
            {
                BindingContext = e.SelectedItem as BookingModel
            });
        }
    }
}