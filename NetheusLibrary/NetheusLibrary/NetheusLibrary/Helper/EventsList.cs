using System;
using System.Collections.Generic;
using System.Text;
using static NetheusLibrary.Model.LibraryModel;

namespace NetheusLibrary.Helper
{
    public static class EventsList
    {
        public static event Action<LibraryList> OnUpdateRecieved;
        public static void MessageRecived(LibraryList _msg)
        {
            if (OnUpdateRecieved != null)
                OnUpdateRecieved(_msg);
        }
        public static event Action<string> OnFadeAnmiationRecieved;
        public static void FadeAnmiation(string _msg)
        {
            if (OnFadeAnmiationRecieved != null)
                OnFadeAnmiationRecieved(_msg);
        }
    }
}
