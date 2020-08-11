using NetheusLibrary.Helper;
using NetheusLibrary.ViewModel;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static NetheusLibrary.Model.LibraryModel;

namespace NetheusLibrary.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryView : ContentPage
    {
        LibraryViewModel _LibraryViewModel;
        public LibraryView()
        {
            InitializeComponent();
            EventsList.OnUpdateRecieved += OnUpdateed;


        }

        private void OnUpdateed(LibraryList obj)
        {
        
          foreach (var item in _LibraryViewModel.LibraryListCollection)
            {
                if (item.ImageId == obj.ImageId)
                {
                    _LibraryViewModel.LibraryListCollection.Remove(item);
                    break;
                }
            }

        
             
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _LibraryViewModel = new LibraryViewModel();
            this.BindingContext = _LibraryViewModel; 
            //CollView.ScrollTo(_LibraryViewModel.LibraryListCollection.Count - 1, _LibraryViewModel.LibraryListCollection.Count - 1, ScrollToPosition.End, true);

        }
     


    }
}