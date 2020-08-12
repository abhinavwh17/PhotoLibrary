using NetheusLibrary.ViewModel;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NetheusLibrary.Model.LibraryModel;

namespace NetheusLibrary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePopup : PopupPage
    {
        LibraryPopUpViewModel _LibraryPopUpViewModel;
        public ImagePopup(int index)
        {
            InitializeComponent();
            _LibraryPopUpViewModel = new LibraryPopUpViewModel(index);
            this.BindingContext = _LibraryPopUpViewModel;
         

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Foooter.Opacity < 1) { 
           await Foooter.FadeTo(1, 500);
            await Task.Delay(5000);
            await Foooter.FadeTo(0, 500);
            }
            else if(Foooter.Opacity == 1)
            {
                await Foooter.FadeTo(0, 500);
            }
        }
    }
}