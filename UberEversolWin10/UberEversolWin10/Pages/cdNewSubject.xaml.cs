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
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UberEversol.Pages
{
    public enum cdResult
    {
        AddSuccess,
        AddFail,
        AddCancel
    }

    public sealed partial class cdNewSubject : ContentDialog
    {

        public Subject newSub;
        public cdResult result { get; set; }
        byte[] imgTemp;

        public cdNewSubject()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Content Dialog Save Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            newSub = new Subject(txtFirstName.Text, txtLastName.Text);

            using (var db = new UberEversolContext())
            {
                db.Subjects.Add(newSub);
                db.SaveChanges();
            }

            result = cdResult.AddSuccess;

            FlyoutBase.SetAttachedFlyout(this, (FlyoutBase)this.Resources["notifyFlyout"]);
            FlyoutBase.ShowAttachedFlyout(this);

            FlyoutBase.GetAttachedFlyout(this).Hide();
        }

        /// <summary>
        /// Content Dialog Cancel Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            result = cdResult.AddCancel;
            this.Hide();
            //FlyoutBase.GetAttachedFlyout(this).Hide();
        }

        // When the flyout closes, hide the sign in dialog, too.
        private void Flyout_Closed(object sender, object e)
        {
            this.Hide();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            newSub = new Subject(txtFirstName.Text, txtLastName.Text);
            newSub.image = imgTemp;
        }

        /// <summary>
        /// Choose image click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            int decodePixelHeight = 200;
            int decodePixelWidth = 200;

            FileOpenPicker open = new FileOpenPicker();
            open.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            open.ViewMode = PickerViewMode.Thumbnail;

            // Filter to include a sample subset of file types
            open.FileTypeFilter.Clear();
            open.FileTypeFilter.Add(".bmp");
            open.FileTypeFilter.Add(".png");
            open.FileTypeFilter.Add(".jpeg");
            open.FileTypeFilter.Add(".jpg");

            // Open a stream for the selected file
            StorageFile file = await open.PickSingleFileAsync();

            // Ensure a file was selected
            if (file != null)
            {
                // Ensure the stream is disposed once the image is loaded
                using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Set the image source to the selected bitmap
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.DecodePixelHeight = decodePixelHeight;
                    bitmapImage.DecodePixelWidth = decodePixelWidth;

                    await bitmapImage.SetSourceAsync(fileStream);
                    imgPerson.Source = bitmapImage;

                    ImageTools img = new ImageTools();

                    imgTemp = await img.ConvertToBytes(fileStream);  // Convert the image to bytes
                    
                }
            }
        }
    }
}
