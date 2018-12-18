using FlagApp.Model;
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

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlagApp
{

    public sealed partial class Done : Page
    {
        public string modeDeJeu;
        DBHelper db;
        public Done()
        {
            this.InitializeComponent();
            db = new DBHelper();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var data = e.Parameter as SendData;
            txtReussi.Text = $"Réussi : {data.correctAnswer}/{data.totalQuestion}";
            txtScore.Text = $"Score : {data.score}";
            progressBar.Minimum = 0;
            progressBar.Maximum = data.totalQuestion;
            progressBar.Value = data.correctAnswer;

            if (progressBar.Maximum == 30)
            {
                modeDeJeu = "Facile";
            }
            else if(progressBar.Maximum == 50)
            {
                modeDeJeu = "Moyen";
            }
            else if(progressBar.Maximum == 100)
            {
                modeDeJeu = "Extreme";
            }
            else
            {
                modeDeJeu = "Personnalisé";
            }

            //Save score to local DB for ranking
            db.insertScore(data.score, modeDeJeu);
        }

        private void btnTryAgain_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
