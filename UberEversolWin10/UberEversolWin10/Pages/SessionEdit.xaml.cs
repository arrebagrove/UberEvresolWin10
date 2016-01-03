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
using UberEversol.Models;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UberEversol.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SessionEdit : Page
    {
        private Session selSession = new Session();
        private int sessionId = 0;

        public SessionEdit()
        {
            this.InitializeComponent();
            // Load the given session
        }

        /// <summary>
        /// When navigated to from another frame
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
                sessionId = int.Parse(e.Parameter.ToString());

            selSession = selSession.DBGet(sessionId);    // Load the session object
            lblTitle.Text = lblTitle.Text + " - " + sessionId.ToString();

            if (selSession != null)
            {
                dtDate.Date = selSession.Date;
                txtTitle.Text = selSession.Title.ToString();
                txtDescription.Text = selSession.Description.ToString();
                txtFolder.Text = selSession.FolderDirectory != null ? selSession.FolderDirectory.ToString() : "";
            }
        }

        /// <summary>
        /// Cancels the Editing of the Session
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            // Close the form
        }

        /// <summary>
        /// Saves the session 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Save the session
            selSession.DBSave();
        }
    }
}
