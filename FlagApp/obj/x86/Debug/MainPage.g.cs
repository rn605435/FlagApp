﻿#pragma checksum "C:\Users\rn605435.IUTNICE\Documents\Flagquizz\FlagApp\FlagApp\FlagApp\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "44D0E65E5F20A4CFA38240F835EF20C2"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlagApp
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 35
                {
                    this.homeMenu = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 3: // MainPage.xaml line 47
                {
                    this.btnPlay = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnPlay).Click += this.btnPlay_Click;
                }
                break;
            case 4: // MainPage.xaml line 55
                {
                    this.btnScore = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnScore).Click += this.btnScore_Click;
                }
                break;
            case 5: // MainPage.xaml line 98
                {
                    this.sliderNumber = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.sliderNumber).ValueChanged += this.SliderNumber_ValueChanged;
                }
                break;
            case 6: // MainPage.xaml line 86
                {
                    this.rdiExtreme = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 7: // MainPage.xaml line 91
                {
                    this.rdiCustom = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 8: // MainPage.xaml line 68
                {
                    this.rdiEasy = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 9: // MainPage.xaml line 74
                {
                    this.rdiMedium = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                }
                break;
            case 10: // MainPage.xaml line 17
                {
                    this.titleApp = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.17.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

