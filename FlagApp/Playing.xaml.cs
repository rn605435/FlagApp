using FlagApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace FlagApp
{
    public class SendData
    {
        public int correctAnswer { get; set; }
        public int totalQuestion { get; set; }
        public int score { get; set; } //send to done.xaml
    }
    public sealed partial class Playing : Page
    {
        //Vars
        const int TIME_LIMIT = 5;
        DispatcherTimer timer; //timer for progress bar value increase
        List<Question> lstQuestion = new List<Question>();
        DBHelper db;
        int index = 0, score = 0, correctAnswer = 0, totalQuestion = 0, thisQuestion = 1, progress=0;



        public Playing()
        {
            this.InitializeComponent();
            db = new DBHelper();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Get user mode from Mainpage
            var mode = e.Parameter;

            //Get mode and set Play mode
            if ((Mode)mode == Mode.EASY)
                lstQuestion = db.getEasyMode().OrderBy(s => Guid.NewGuid()).ToList();
            else if ((Mode)mode == Mode.MEDIUM)
                lstQuestion = db.getMedium().OrderBy(s => Guid.NewGuid()).ToList();
            else if ((Mode)mode == Mode.HARD)
                lstQuestion = db.getHardMode().OrderBy(s => Guid.NewGuid()).ToList();
            else if ((Mode)mode == Mode.EXTREME)
                lstQuestion = db.getExtremeMode().OrderBy(s => Guid.NewGuid()).ToList();

            //init progressbar
            progressBar.Minimum = 0;
            progressBar.Value = 0;
            progressBar.Maximum = TIME_LIMIT;

            //Get total question number 
            totalQuestion = lstQuestion.Count;

            //Show first question
            ShowQuestion(index);
        }

        private void btnAnswerA_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }

        private void btnAnswerB_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }

        private void btnAnswerC_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }

        private void btnAnswerD_Click(object sender, RoutedEventArgs e)
        {
            AnswerAccept(sender as Button);
        }


        //Function to check Answer
        private void AnswerAccept(Button btn)
        {
            //If answer is right
            if (btn.Content.Equals(lstQuestion[index].CorrectAnswer.ToUpper()))
            {
                score += 10; //increase score
                correctAnswer++; //increase correctAnswer
                txtScore.Text = score.ToString();

            }

            
            thisQuestion++;
            index++;
            resetTimer();
            ShowQuestion(index); //next question
            
        }

        //Function show question
        public void ShowQuestion(int index)
        {
            if (index < lstQuestion.Count)
            {
                //get image url
                string imgUrl = "ms-appx:///Assets/Flags/" + lstQuestion[index].Image + ".png";
                // Add image to image control
                imgLoad.Source = new BitmapImage(new Uri(imgUrl));

                //Set content of button to data from lstQuestion
                btnAnswerA.Content = lstQuestion[index].AnswerA.ToUpper();
                btnAnswerB.Content = lstQuestion[index].AnswerB.ToUpper();
                btnAnswerC.Content = lstQuestion[index].AnswerC.ToUpper();
                btnAnswerD.Content = lstQuestion[index].AnswerD.ToUpper();

                //Set status of Question
                txtNum.Text = $"{thisQuestion}/{totalQuestion}";

                //Load Timer
                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Tick += Timer_Tick;
                timer.Start();

            }
            else // if index > totalQuestion
            {
                //Navigate Done page and send result
                Frame.Navigate(typeof(Done), new SendData() { correctAnswer = this.correctAnswer, totalQuestion = this.totalQuestion, score = this.score });
            }

        }

        private void Timer_Tick(object sender, object e)
        {
            //Increase progress bar value
            progress++;
            progressBar.Value = progress;
            if(progress > progressBar.Maximum) //Time over
            {
                
                progress++;
                progressBar.Value = progress;
                Task.Delay(1000); //1s
                thisQuestion++; //next q
                index++; //next q
                resetTimer();
                ShowQuestion(index);
                
            }
        }

        private void resetTimer()
        {
            timer.Stop();
            timer = null;
            progressBar.Value = 0;
            progress = 0;
        }
    }
}
