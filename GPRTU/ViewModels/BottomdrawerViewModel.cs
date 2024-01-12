using System;
using System.Collections.ObjectModel;
using GPRTU.Models;


namespace GPRTU.ViewModels
{

    public class BottomdrawerViewModel : BaseViewModel
    {
        public ObservableCollection<Pickuploc> locSource { get; set; }

        public Command NavToDetailCommand { get; set; }
        public BottomdrawerViewModel()
        {
            NavToDetailCommand = new Command<Pickuploc>(OnNav);
        }

        private async void OnNav(Pickuploc control)
        {
           if(control == null)
                return;

            await Shell.Current.GoToAsync(state:$"//control?control={control.latitude},{control.longitude}");

            // await Shell.Current.GoToAsync($"//{nameof(MainPage)}?Content={piclocation.longitude.ToString()},{piclocation.latitude.ToString()}");  &templates={control.ControlTemplate}
        }
    }
}