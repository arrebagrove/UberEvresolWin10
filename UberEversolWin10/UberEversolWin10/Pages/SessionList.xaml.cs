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
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UberEversol.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SessionList : Page
    {
        public SessionList()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Page Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new UberEversolContext())
            {
                session_list.ItemsSource = db.Sessions.ToList();
            }
        }

        private void session_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btnRemove.IsEnabled = true;
            //MessageDialog dialog;
            //ListViewItem itemId = ((sender as ListView).SelectedItem as ListViewItem);
            //if (itemId != null)
            //{
            //    dialog = new MessageDialog(itemId.ToString());
            //}
            //else
            //{
            //    dialog = new MessageDialog("Item Selected");
            //}
        }

        private void btnNewSession_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(SessionEdit))
            {
                frame.Navigate(typeof(SessionEdit));
            }
        }

        private void btnRemoveSession_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Open a Session live recording
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSessionLive_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(SessionLive))
            {
                if (session_list.SelectedIndex >= 0)
                {
                    int selId = ((Session)session_list.SelectedItem).id;

                    // Open the session live and pass the Id in to the frame
                    frame.Navigate(typeof(SessionLive), selId);
                }
            }
        }

        /// <summary>
        /// Double Click event for list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void session_list_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(SessionLive))
            {
                if (session_list.SelectedIndex >= 0)
                {
                    int selId = ((Session)session_list.SelectedItem).id;

                    // Open the session live and pass the Id in to the frame
                    frame.Navigate(typeof(SessionLive), selId);
                }
            }
        }
    }
}
