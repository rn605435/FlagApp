using FlagApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FlagApp
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static double customQ = 0;
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Disabled;
            //check screen size
            var bounds = ApplicationView.GetForCurrentView().VisibleBounds;
            var scaleFactor = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
            var size = new Size(bounds.Width * scaleFactor, bounds.Height * scaleFactor);
            //Debug.WriteLine($"Width:{size.Width}:Height:{size.Height}"); //screen size displayed
            if(size.Width == 500 && size.Height == 600)
            {
                homeMenu.VerticalAlignment = VerticalAlignment.Bottom;
            }
            else
            {
                homeMenu.VerticalAlignment = VerticalAlignment.Center; //default
            }
            //hide status bar
            if(Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                await Windows.UI.ViewManagement.StatusBar.GetForCurrentView().HideAsync();
            }

  


        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            Mode mode;
            
            if (rdiEasy.IsChecked == true)
            {
                mode = Mode.EASY;
            }
            else if (rdiMedium.IsChecked == true)
            {
                mode = Mode.MEDIUM;
            }
            else if (rdiCustom.IsChecked == true)
            {
                mode = Mode.CUSTOM;
            }
            else
                mode = Mode.EXTREME;
            Frame.Navigate(typeof(Playing),mode);
        }

        private void btnScore_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RankingPage));
        }

        private void SliderNumber_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            
            if (slider != null)
            {
                customQ = slider.Value;
            }
        }
    }
}
