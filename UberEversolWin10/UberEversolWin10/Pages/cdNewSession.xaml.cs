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
using UberEversol.Model;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UberEversol.Pages
{
    public sealed partial class cdNewSession : ContentDialog
    {
        public cdResult result { get; set; }

        public cdNewSession()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Save button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Session newSes = new Session(txtTitle.Text,txtDescription.Text);
            newSes.created = dtCreatedDate.Date.Date;

            using (var db = new UberEversolContext())
            {
                db.Sessions.Add(newSes);
                db.SaveChanges();
            }

            result = cdResult.AddSuccess;

            FlyoutBase.SetAttachedFlyout(this, (FlyoutBase)this.Resources["notifyFlyout"]);
            FlyoutBase.ShowAttachedFlyout(this);

            FlyoutBase.GetAttachedFlyout(this).Hide();
        }

        /// <summary>
        /// Cancel button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            result = cdResult.AddCancel;
            this.Hide();
        }
    }
}
