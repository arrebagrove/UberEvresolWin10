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
    public sealed partial class Search : Page
    {
        public Search()
        {
            this.InitializeComponent();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            String qryStr = txtQry.Text;
            int qryType = cboFields.SelectedIndex;

            lstvResultsSessions.Visibility = Visibility.Collapsed;
            lstvResultsTracks.Visibility = Visibility.Collapsed;

            if (!String.IsNullOrEmpty(qryStr))  // Check input value
            {
                using (var db = new UberEversolContext())
                {
                    List<Session> ses_results;
                    List<Track> trk_results;

                    if (qryType == 0)
                    {
                        ses_results = db.Sessions.Where(s => s.title.Contains(qryStr)
                                || s.description.Contains(qryStr)).ToList();

                        txtSesResultCount.Text = ses_results.Count + " record(s) found!";
                        lstvResultsSessions.ItemsSource = ses_results;
                        lstvResultsSessions.Visibility = Visibility.Visible;
                    }
                    else if (qryType == 1)
                    {
                        trk_results = db.Tracks.Where(t => t.title.Contains(qryStr) 
                                || t.description.Contains(qryStr) 
                                || t.subject.first_name.Contains(qryStr)
                                || t.subject.last_name.Contains(qryStr)).ToList();

                        
                        foreach (Track t in trk_results)
                        {
                            t.loadStructures();  // Populates the Icollection objects of track

                            if (t.subject != null)
                                t.subject.imageObj = await t.subject.loadImage();
                        }

                        txtTrkResultCount.Text = trk_results.Count + " record(s) found!";
                        lstvResultsTracks.ItemsSource = trk_results;
                        lstvResultsTracks.Visibility = Visibility.Visible;
                    }
                }
            }
        }
    }
}
