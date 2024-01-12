using GPRTU.ViewModels;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;

namespace GPRTU;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent();
       
        BindingContext = viewModel;
        MainPageViewModel.map = UrbanMap;
       
    }
   protected void OnAppearing()
    {
       // SearchDest.Text = longitude;
    }
}