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
    public sealed partial class SubjectView : Page
    {
        private int sId = 0;
        private Subject selSubject;

        public SubjectView()
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

            if (sId > 0)
            {
                selSubject = selSubject.DBGet(sId);    // Load the session object

                lblTitle.Text = lblTitle.Text + " - " + sId.ToString();

                txtFirstName.Text = selSubject.first_name.ToString();
                txtLastName.Text = selSubject.last_name.ToString();
            }
        }

        /// <summary>
        /// Close Button Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }
    }
}
