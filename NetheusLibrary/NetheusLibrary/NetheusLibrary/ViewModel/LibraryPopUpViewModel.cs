using NetheusLibrary.Helper;
using NetheusLibrary.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using static NetheusLibrary.Model.LibraryModel;

namespace NetheusLibrary.ViewModel
{
    public class LibraryPopUpViewModel : LibraryPopUpModel
    {
        public LibraryPopUpViewModel( int index)
        {
            Index = index;
            string LoaclListData = LocalStorageHelper.RetriveFromLocalSetting(AppConstant.ListKey);
            if (!String.IsNullOrEmpty(LoaclListData))
            {
                var DesrilizedData = JsonConvert.DeserializeObject<ObservableCollection<LibraryList>>(LoaclListData);
                LibraryListCollection = DesrilizedData;
                DeleteCommand = new Commands.DelegateCommand(DeleteCommand_Function);
                ImageTabbed = new Commands.DelegateCommand(ImageTabbed_function);
            }
           
        }

        private void ImageTabbed_function()
        {
          
        }

        private void DeleteCommand_Function()
        {
            var data = LibraryListCollection[Index];
          //  Index
            //   var data = (from a in LibraryListCollection where a.IsSelected == true select a).FirstOrDefault();
            data.ImageIsVisible = false;
            LibraryListCollection.Remove(data);
            EventsList.MessageRecived(data);
            var SerilizedData = JsonConvert.SerializeObject(LibraryListCollection);
            
            LocalStorageHelper.StoreInLocalSetting(AppConstant.ListKey, SerilizedData);
           


        }
    }
}
