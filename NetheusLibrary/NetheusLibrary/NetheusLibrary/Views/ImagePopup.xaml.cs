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
    }
}