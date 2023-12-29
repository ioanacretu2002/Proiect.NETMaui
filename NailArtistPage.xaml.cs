using ProiectMedii.Models;
namespace ProiectMedii;

public partial class NailArtistPage : ContentPage
{
	public NailArtistPage()
	{
		InitializeComponent();
	}
	public async void SaveNailArtistClicked(object sender, EventArgs e)
	{
        var nailArtistModel = (NailArtistModel)BindingContext;
        await App.Database.SaveNailArtistModelAsync(nailArtistModel);
        await Navigation.PopAsync();
    }
    public async void DeleteNailArtistClicked(object sender, EventArgs e)
    {
        var nailArtistModel = (NailArtistModel)BindingContext;
        await App.Database.DeleteNailArtistModelAsync(nailArtistModel);
        await Navigation.PopAsync();
    }
}