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
using System.Xml;
using System.Text;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace UberEversol.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubjectList : Page
    {
        public List<Subject> subjectList;

        public SubjectList()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Page Load Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            using (var db = new UberEversolContext())
            {
                subjectList = db.Subjects.OrderBy(s => s.last_name).ToList();
                foreach (Subject s in subjectList.Where(s => s.image != null))
                {
                    s.imageObj = await s.loadImage();
                }

                subject_list.ItemsSource = subjectList;
            }
        }

        /// <summary>
        /// List View select row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void subject_list_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            cdViewSubject viewSubjectDialog = new cdViewSubject();
            viewSubjectDialog.selSubject = (Subject)subject_list.SelectedItem;
            await viewSubjectDialog.ShowAsync();
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
                using (var db = new DataModel.UberEversolContext())
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

        /// <summary>
        /// Saves the subject list to an xml file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AppBtnExportSubjects_Click(object sender, RoutedEventArgs e)
        {
            XmlWriter writer;
            StringWriter sw;

            using (sw = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.NewLineOnAttributes = true;

                //using (writer = XmlWriter.Create(new StringBuilder("subjects.xml")))
                using (writer = XmlWriter.Create(sw, settings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Employees");

                    foreach (Subject person in subjectList)
                    {
                        writer.WriteStartElement("Subject");

                        writer.WriteElementString("id", person.id.ToString());
                        writer.WriteElementString("first_name", person.first_name);
                        writer.WriteElementString("last_name", person.last_name);
                        writer.WriteElementString("created", person.created.ToString());
                        writer.WriteElementString("hit_count", person.hit_count.ToString());
                        writer.WriteElementString("recording_count", person.recording_count.ToString());
                        writer.WriteElementString("user_rating", person.user_rating.ToString());
                        writer.WriteElementString("image", Convert.ToBase64String(person.image));
                        //byte[] decByte3 = Convert.FromBase64String(s3); to undo
                        writer.WriteElementString("active", person.active.ToString());

                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }

            var savePicker = new Windows.Storage.Pickers.FileSavePicker();
            savePicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;

            // Dropdown of file types the user can save the file as
            savePicker.FileTypeChoices.Add("XML", new List<string>() { ".xml" });

            // Default file name if the user does not type one in or select a file to replace
            savePicker.SuggestedFileName = "subjects";

            //Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();
            Windows.Storage.StorageFile file = await savePicker.PickSaveFileAsync();

            if (file != null)
            {
                // Prevent updates to the remote version of the file until
                // we finish making changes and call CompleteUpdatesAsync.
                Windows.Storage.CachedFileManager.DeferUpdates(file);

                // write to file
                await Windows.Storage.FileIO.WriteTextAsync(file, sw.ToString());

                // Let Windows know that we're finished changing the file so
                // the other app can update the remote version of the file.
                // Completing updates may require Windows to ask for user input.
                Windows.Storage.Provider.FileUpdateStatus status = await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);

                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    FlyoutBase.SetAttachedFlyout(this, (FlyoutBase)this.Resources["notifyFlyout_saved"]);
                    FlyoutBase.ShowAttachedFlyout(this);
                }
                else
                {
                    FlyoutBase.SetAttachedFlyout(this, (FlyoutBase)this.Resources["notifyFlyout_error"]);
                    FlyoutBase.ShowAttachedFlyout(this);
                }
            }
        }
    }
}
