using NetheusLibrary.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace NetheusLibrary.Model
{
   public class LibraryModel : ModelBase
    {
        private ObservableCollection<LibraryList> _LibraryListCollection;
        public ObservableCollection<LibraryList> LibraryListCollection
        {
            get { return _LibraryListCollection; }
            set { SetProperty(ref _LibraryListCollection, value); }
        }
        private bool _HeaderVisibility = true;
        public bool HeaderVisibility
        {
            get { return _HeaderVisibility; }
            set { SetProperty(ref _HeaderVisibility, value); }
        }
        private bool _FooterVisibility = false;
        public bool FooterVisibility
        {
            get { return _FooterVisibility; }
            set { SetProperty(ref _FooterVisibility, value); }
        }

        private bool _IsBusy = false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetProperty(ref _IsBusy, value); }
        }

        public DelegateCommand<int> ImageClicked { get; set; }
        public DelegateCommand Cancel { get; set; }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand<int> ImageLongPressed { get; set; }
        public DelegateCommand AddClicked { get; set; }
        public class LibraryList : ModelBase
        {
            private bool _IsSelected = false;
            public bool IsSelected
            {
                get { return _IsSelected; }
                set { SetProperty(ref _IsSelected, value); }
            }
         
            public int ImageId { get; set; }
            public string imagePath { get; set; }

            private bool _ImageIsVisible = true;
            public bool ImageIsVisible
            {
                get { return _ImageIsVisible; }
                set { SetProperty(ref _ImageIsVisible, value); }
            }
        }
       
    }
}
