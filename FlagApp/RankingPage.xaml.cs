using FlagApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlagApp
{
    public class ScoreTemplate
    {
        public string scoreImage { get; set; }
        public int Score { get; set; }
    }
    public sealed partial class RankingPage : Page
    {
        List<Ranking> lstRanking = new List<Ranking>();
        List<ScoreTemplate> lstSource = new List<ScoreTemplate>();
        DBHelper db;

        public RankingPage()
        {
            this.InitializeComponent();
            db = new DBHelper();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var currentView = SystemNavigationManager.GetForCurrentView();
            //make the btn visible
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            //detect pressed
            currentView.BackRequested += backButton_Tapped;
            loadRanking();
        }
        private void backButton_Tapped(object sender, BackRequestedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void loadRanking()
        {
                lstRanking = db.getRanking();
                //Add image to list
                foreach (var item in lstRanking)
                {
                    ScoreTemplate score = new ScoreTemplate();
                    score.Score = item.Score;
                    score.scoreImage = "ms-appx:///Assets/bronze.png";
                    lstSource.Add(score);
                }
                //Sort 
                lstSource = lstSource.OrderByDescending(x => x.Score).ToList();
                //top 1 & 2
                if (lstSource.Count > 2)
                {
                    lstSource[0].scoreImage = "ms-appx:///Assets/gold.png";
                    lstSource[1].scoreImage = "ms-appx:///Assets/silver.png";
                }
                else if (lstSource.Count == 1)
                {
                    lstSource[0].scoreImage = "ms-appx:///Assets/gold.png";
                }
                else
                {
                    // count = 0
                }

            lstScore.ItemsSource = lstSource;

        }
    }
}
