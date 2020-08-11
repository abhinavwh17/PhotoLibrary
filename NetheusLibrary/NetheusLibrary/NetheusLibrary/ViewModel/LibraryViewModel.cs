using NetheusLibrary.Helper;
using NetheusLibrary.Model;
using NetheusLibrary.Service;
using NetheusLibrary.Views;
using Newtonsoft.Json;
using Plugin.Media;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Linq;
using Xamarin.Forms.Internals;

namespace NetheusLibrary.ViewModel
{
   public class LibraryViewModel : LibraryModel
    {


        public LibraryViewModel()
        {
            IsBusy = true;
            LibraryListCollection = new System.Collections.ObjectModel.ObservableCollection<LibraryList>();

            string LoaclListData = LocalStorageHelper.RetriveFromLocalSetting(AppConstant.ListKey);
            if (!String.IsNullOrEmpty(LoaclListData))
            {
                var DesrilizedData = JsonConvert.DeserializeObject<ObservableCollection<LibraryList>>(LoaclListData);
                foreach (var item in DesrilizedData)
                {
                    if(item.ImageIsVisible==true)
                    LibraryListCollection.Add(item);
                }
               // LibraryListCollection=DesrilizedData;
            }

          else { 

            for (int i = 0; i < 5; i++)
            {
                    int id = i + 1;
                LibraryListCollection.Add(new LibraryList { imagePath = "Image.jpg" ,ImageIsVisible = true, ImageId = id });
            }

                var SerilizedData = JsonConvert.SerializeObject(LibraryListCollection);

                LocalStorageHelper.StoreInLocalSetting(AppConstant.ListKey, SerilizedData);
            }

            ImageClicked = new Commands.DelegateCommand<int>(ImageClicked_function);
            AddClicked = new Commands.DelegateCommand(AddClicked_function);
            ImageLongPressed = new Commands.DelegateCommand<int>(ImageLongPressed_Function);
            Cancel = new Commands.DelegateCommand(Cancel_Function);
            DeleteCommand = new Commands.DelegateCommand(DeleteCommand_Function);
            IsBusy = false;
        }

        private void DeleteCommand_Function()
        {
            IsBusy = true;
            var data = (from a in LibraryListCollection where a.IsSelected == true select a).FirstOrDefault();
            data.ImageIsVisible = false;
           
          LibraryListCollection.Remove(data);
            var SerilizedData = JsonConvert.SerializeObject(LibraryListCollection);
            LocalStorageHelper.StoreInLocalSetting(AppConstant.ListKey, SerilizedData);
            HeaderVisibility = true;
            FooterVisibility = false;
            IsBusy = false  ;
        }

        private void Cancel_Function()
        {
            HeaderVisibility = true;
            FooterVisibility = false;
        }

        private void ImageLongPressed_Function(int obj)
        {
            var data = (from a in LibraryListCollection where a.ImageId == obj select a).FirstOrDefault();
            data.IsSelected = true;
            HeaderVisibility = false;
            FooterVisibility = true;
        }

        private async void AddClicked_function()
        {
            IsBusy = true;
            int LastImageId = 0;
            var status = await Permissions.RequestAsync<Permissions.Photos>();
            if (LibraryListCollection.Count > 0) { 
             LastImageId = LibraryListCollection.Last().ImageId;
            }


            if (status == PermissionStatus.Granted)
            {
              var file =await  CrossMedia.Current.PickPhotosAsync();

              
                if (file != null)
                {
                    foreach (var item in file)
                    {
                       
                        LibraryListCollection.Add(new LibraryList { imagePath = item.Path , ImageIsVisible=true,ImageId= LastImageId+1 });
                        LastImageId++;
                    }
                  

                }

                var SerilizedData = JsonConvert.SerializeObject(LibraryListCollection);

                LocalStorageHelper.StoreInLocalSetting(AppConstant.ListKey, SerilizedData);


            }
            IsBusy = false;
        }
    
        private async void ImageClicked_function(int obj)
        {

           // var data = (from a in LibraryListCollection where a.ImageId == obj select a).IndexOf(a)
             int index= LibraryListCollection.IndexOf(a => a.ImageId == obj);
           // index++;
            await PopupNavigation.PushAsync(new ImagePopup(index));
        }
    }
}
