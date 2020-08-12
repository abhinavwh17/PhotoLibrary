using NetheusLibrary.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static NetheusLibrary.Model.LibraryModel;

namespace NetheusLibrary.Model
{
   public class LibraryPopUpModel : ModelBase
    {
        private ObservableCollection<LibraryList> _LibraryListCollection;
        public ObservableCollection<LibraryList> LibraryListCollection
        {
            get { return _LibraryListCollection; }
            set { SetProperty(ref _LibraryListCollection, value); }
        }
        public DelegateCommand DeleteCommand { get; set; }
        public DelegateCommand ImageTabbed { get; set; }
        private int _Index;
        public int Index
        {
            get { return _Index; }
            set { SetProperty(ref _Index, value); }
        }
    }
}
