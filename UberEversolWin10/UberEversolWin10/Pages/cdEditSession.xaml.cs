using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UberEversol.DataModel;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UberEversol.Pages
{
    public sealed partial class cdEditSession : ContentDialog
    {
        public cdResult result { get; set; }
        public Session selSession;

        public cdEditSession(Session aSession)
        {
            this.InitializeComponent();
            this.DataContext = aSession;
            selSession = aSession;
        }

        // Click event for the save button
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            //Copy the values entered
            selSession.title = txtTitle.Text;
            selSession.description = txtDescription.Text;
            selSession.folderDir = txtFolder.Text;

            DateTime dtTemp = new DateTime(dtDate.Date.Year, dtDate.Date.Month, dtDate.Date.Day,
                dtSessionTime.Time.Hours, dtSessionTime.Time.Minutes, 0);
            selSession.created = dtTemp;

            int res = selSession.DBUpdate(); // Update the data

            if (res == 0)
                result = cdResult.UpdateSuccess;
            else
                result = cdResult.UpdateFail;
        }

        // Click event for the cancel button
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            result = cdResult.UpdateCancel;
        }

        // When the dialog is opened
        private void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            dtDate.Date = selSession.created.Date;
            dtSessionTime.Time = selSession.created.TimeOfDay;
        }
    }
}
