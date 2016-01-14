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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UberEversol.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SessionLive : Page
    {
        private int sessionId = 0;
        private Session selSession = new Session();
        


        public SessionLive()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// After Page frame has been initialized
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            

            using (var db = new UberEversolContext())
            {
                var ses = from s in db.Sessions
                          where s.id == sessionId
                          select s;
                //selSession = ses;
                txtTitle.Text = ses.Select(s => s.title).ToString();
                txtDescription.Text = ses.Select(s => s.description).ToString();
                txtFolder.Text = ses.Select(s => s.folderDir).ToString();
                //db.Sessions.Where(s => s.id == sessionId);
                // Load the Track list
                //lstTrack.ItemsSource = ses.tracks;
            }
        }

        /// <summary>
        /// When navigated to from another frame
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if(e.Parameter != null)
                sessionId = int.Parse(e.Parameter.ToString());

            selSession = selSession.DBGet(sessionId);    // Load the session object

            lblTitle.Text = lblTitle.Text + " - " + sessionId.ToString();

            if (selSession != null)
            {
                txtDate.Text = selSession.created.ToString();
                txtTitle.Text = selSession.title.ToString();
                txtDescription.Text = selSession.description.ToString();
                txtFolder.Text = selSession.folderDir != null? selSession.folderDir.ToString():"";
                //db.Sessions.Where(s => s.id == sessionId);
                // Load the Track list
                track_list.ItemsSource = selSession.tracks;
            }
        }

        /// <summary>
        /// Add a new track to the current session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void appBtnNewTrack_Click(object sender, RoutedEventArgs e)
        {
            // Open a Track content dialog
            cdNewTrack newTrackDialog = new cdNewTrack();
            await newTrackDialog.ShowAsync();
            if (newTrackDialog.usrClicked == cdClicked.Save)
            {
                using (var db = new UberEversolContext())
                {
                    newTrackDialog.newTrack.session = selSession;
                    db.Tracks.Add(newTrackDialog.newTrack);
                    await db.SaveChangesAsync();
                }
            }

           // Refresh the listview
           track_list.ItemsSource = selSession.tracks.ToList();
        }

        /// <summary>
        /// Delete a track from the session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void appBtnDeleteTrack_Click(object sender, RoutedEventArgs e)
        {
            Track selTrack = (Track)track_list.SelectedItem;
            int selItem = selTrack.id;

            // Need to prompt confirm

            if (selItem >= 0)
            {
                selTrack.DBRemove();
            }

            // Refresh the list
            track_list.ItemsSource = selSession.tracks;
        }

        /// <summary>
        /// Edit a track in a live session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void appBtnEditTrack_Click(object sender, RoutedEventArgs e)
        {
            // Open a Track content dialog
            cdNewTrack newTrackDialog = new cdNewTrack();
            await newTrackDialog.ShowAsync();

            // Refresh the listview
            track_list.ItemsSource = selSession.tracks.ToList();
        }
    }
}
