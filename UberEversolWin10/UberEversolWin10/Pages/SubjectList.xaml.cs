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
    public sealed partial class SubjectList : Page
    {
        public SubjectList()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Page Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            using (var db = new UberEversolContext())
            {
                subject_list.ItemsSource = db.Subjects.ToList();
            }
        }

        /// <summary>
        /// List View select row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void subject_list_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;

            if (page?.GetType() != typeof(SubjectList))
            {
                if (subject_list.SelectedIndex >= 0)
                {
                    int selId = ((Subject)subject_list.SelectedItem).id;

                    // Open the session live and pass the Id in to the frame
                    frame.Navigate(typeof(SubjectView), selId);
                }
            }
        }

        /// <summary>
        /// Add a new Subject
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBtnNew_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;
            Page page = frame?.Content as Page;

            if (page?.GetType() != typeof(SubjectEdit))
            {
                frame.Navigate(typeof(SubjectEdit));
            }
        }

        /// <summary>
        /// Add a new Subject
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AppBtnNewSubject_Dialog_Click(object sender, RoutedEventArgs e)
        {
            cdNewSubject newSubjectDialog = new cdNewSubject();
            await newSubjectDialog.ShowAsync();

            if (newSubjectDialog.result == cdResult.AddSuccess)
            {
                // Add New was successful.
                // Refresh the listview
                using (var db = new UberEversolContext())
                {
                    subject_list.ItemsSource = db.Subjects.ToList();
                }
            }
            else if (newSubjectDialog.result == cdResult.AddFail)
            {
                // Add failed.
                // Prompt User
            }

        }

        /// <summary>
        /// Remove Subject Button 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Subject selSub = (Subject)subject_list.SelectedItem;
            int selItem = selSub.id;

            if (selItem >= 0)
            {
                selSub.DBRemove();
            }

            Frame.Navigate(typeof(SubjectList));
        }

        /// <summary>
        /// Edit button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBtnEdit_Click(object sender, RoutedEventArgs e)
        {
            var frame = this.DataContext as Frame;

            if (subject_list.SelectedIndex >= 0)
            {
                int selId = ((Subject)subject_list.SelectedItem).id;

                // Open the session live and pass the Id in to the frame
                frame.Navigate(typeof(SubjectEdit), selId);
            }
        }

        /// <summary>
        /// The listview selection changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void subject_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AppBtnEdit.Visibility = Visibility.Visible;
        }
    }
}
