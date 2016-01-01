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

        /// For list view
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new UberEversolContext())
            {
                session_list.ItemsSource = db.Sessions.ToList();
            }
        }

        private async void session_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btnRemove.IsEnabled = true;
            MessageDialog dialog;
            ListViewItem itemId = ((sender as ListView).SelectedItem as ListViewItem);
            if (itemId != null)
            {
                dialog = new MessageDialog(itemId.ToString());
            }
            else
            {
                dialog = new MessageDialog("Item Selected");
            }

            await dialog.ShowAsync();
        }

        private void btnNewSession_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnRemoveSession_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
