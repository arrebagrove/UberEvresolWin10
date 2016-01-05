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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UberEversol.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubjectEdit : Page
    {
        Subject person = new Subject();
        private int sId = 0;

        public SubjectEdit()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// When navigated to from another frame
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
                sId = int.Parse(e.Parameter.ToString());

            person = person.DBGet(sId);    // Load the session object
            lblTitle.Text = lblTitle.Text + " - " + sId.ToString();

            if (person != null)
            {
                txtFirstName.Text = person.first_name.ToString();
                txtLastName.Text = person.last_name.ToString();
            }
        }

        /// <summary>
        /// Save Subject Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                person = new Subject(txtFirstName.Text, txtLastName.Text);
                person.DBSave();
            }
            catch(InvalidDataException exc)
            {
                lblNotify.Text = "Error! " + exc.Message;
                lblNotify.Visibility = Visibility.Visible;
            }

            lblNotify.Text = "Subject Saved!";
            lblNotify.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Cancel Click Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
