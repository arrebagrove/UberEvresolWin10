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
    public enum cdClicked
    {
        Save,
        Cancel
    }

    public sealed partial class cdNewTrack : ContentDialog
    {
        public Track newTrack; // The new track object
        public cdClicked usrClicked;  // The result of what the user clicked

        public cdNewTrack()
        {
            this.InitializeComponent();

            //List<Subject> subject_list;
            //using (var db = new UberEversolContext())
            //{
            //    // Get the list of subject names and ids
            //    subject_list = db.Subjects.OrderBy(t => t.last_name).ToList();
            //}

            //foreach (Subject s in subject_list.Where(s => s.image != null))
            //    s.imageObj = await s.loadImage();

            //foreach (Subject s in subject_list)
            //    cboSubjects.Items.Add(s);
        }

        /// <summary>
        /// Event when the content dialog is opened
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void ContentDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {
            List<Subject> subject_list;
            using (var db = new UberEversolContext())
            {
                // Get the list of subject names and ids
                subject_list = db.Subjects.OrderBy(t => t.last_name).ToList();
            }

            foreach (Subject s in subject_list)
            {
                if (s.image != null)
                        s.imageObj = await s.loadImage();
                cboSubjects.Items.Add(s);
            }
        }

        /// <summary>
        /// Save button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            newTrack = new Track(DateTime.Now.Date, txtTitle.Text, txtDesc.Text);
            newTrack.keywords = txtKeywords.Text;

            if (cboSubjects.SelectedIndex >= 0)
            {
                newTrack.subject = (Subject)cboSubjects.SelectedItem;
            }

            usrClicked = cdClicked.Save; // Set the usrClicked value to save
        }

        /// <summary>
        /// Cancel button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.Hide();
            usrClicked = cdClicked.Cancel; // Set the usrClicked value to cancel
        }
    }
}
