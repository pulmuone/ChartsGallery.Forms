/*                                                         
               Copyright (c) 2018 Developer Express Inc.                
{*******************************************************************}   
{                                                                   }   
{       Developer Express Mobile Chart Library                      }   
{                                                                   }   
{                                                                   }   
{       Copyright (c) 2018 Developer Express Inc.                   }   
{       ALL RIGHTS RESERVED                                         }   
{                                                                   }   
{   The entire contents of this file is protected by U.S. and       }   
{   International Copyright Laws. Unauthorized reproduction,        }   
{   reverse-engineering, and distribution of all or any portion of  }   
{   the code contained in this file is strictly prohibited and may  }   
{   result in severe civil and criminal penalties and will be       }   
{   prosecuted to the maximum extent possible under the law.        }   
{                                                                   }   
{   RESTRICTIONS                                                    }   
{                                                                   }   
{   THIS SOURCE CODE AND ALL RESULTING INTERMEDIATE FILES           }   
{   ARE CONFIDENTIAL AND PROPRIETARY TRADE                          }   
{   SECRETS OF DEVELOPER EXPRESS INC. THE REGISTERED DEVELOPER IS   }   
{   LICENSED TO DISTRIBUTE THE PRODUCT AND ALL ACCOMPANYING         }   
{   CONTROLS AS PART OF AN EXECUTABLE PROGRAM ONLY.                 }   
{                                                                   }   
{   THE SOURCE CODE CONTAINED WITHIN THIS FILE AND ALL RELATED      }   
{   FILES OR ANY PORTION OF ITS CONTENTS SHALL AT NO TIME BE        }   
{   COPIED, TRANSFERRED, SOLD, DISTRIBUTED, OR OTHERWISE MADE       }   
{   AVAILABLE TO OTHER INDIVIDUALS WITHOUT EXPRESS WRITTEN CONSENT  }   
{   AND PERMISSION FROM DEVELOPER EXPRESS INC.                      }   
{                                                                   }   
{   CONSULT THE END USER LICENSE AGREEMENT FOR INFORMATION ON       }   
{   ADDITIONAL RESTRICTIONS.                                        }   
{                                                                   }   
{*******************************************************************}   
*/                                                                      
using System;
using System.Threading.Tasks;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;
using ChartsGallery.Models;
using ChartsGallery.Forms.ViewModels;

namespace ChartsGallery.Forms.Views {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
        }

        NavigationPage GetPage(DemoItem item) {
            NavigationPage navigationPage = null;
            if (item != null &&
                item.Module != null &&
                item.Module.IsSubclassOf(typeof(Page))) {
                Page page = (Page)Activator.CreateInstance(item.Module);
                navigationPage = new NavigationPage(page) { Title = item.Title } ;
                NavigationPage.SetHasNavigationBar(page, false);
            }
            return navigationPage;
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args) {
            var item = args.SelectedItem as DemoItem;
            if (item != null) {
                NavigationPage navigationPage = GetPage(item);
                await Navigation.PushAsync(navigationPage);
                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);
                ItemsListView.SelectedItem = null;
            }
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            viewModel.HeaderSeriesData.Start();
        }
        protected override void OnDisappearing() {
            base.OnDisappearing();
            viewModel.HeaderSeriesData.Pause();
        }
    }

    public class DemoItemToBoolConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            DemoItem item = value as DemoItem;
            MainViewModel viewModel = parameter as MainViewModel;
            return item != null && viewModel != null && viewModel.Items.LastOrDefault() != item;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
