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
            if (e.Parameter != null) // Check for param
            {
                sessionId = int.Parse(e.Parameter.ToString()); // Get the Parameter

                if (sessionId > 0)  // Check if the session id is valid
                {
                    selSession = selSession.DBGet(sessionId);    // Load the session object

                    if (selSession != null)
                    {
                        lblTitle.Text = lblTitle.Text + " - " + sessionId.ToString();   // Temporary
                        dtDate.Date = selSession.created.Date;
                        dtTime.Time = selSession.created.Date.TimeOfDay;
                        txtTitle.Text = selSession.title.ToString();
                        txtDescription.Text = selSession.description.ToString();
                        txtFolder.Text = selSession.folderDir != null ? selSession.folderDir.ToString() : "";
                    }
                }
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
            selSession.title = txtTitle.Text;
            selSession.description = txtDescription.Text;
            selSession.folderDir = txtFolder.Text;
            selSession.created = dtDate.Date.Date+dtTime.Time;

            // Save the session
            selSession.DBUpdate();
        }
    }
}
