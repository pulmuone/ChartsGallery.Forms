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
using System.Collections.Generic;
using Xamarin.Forms;
using ChartsGallery.Forms.Data;
using ChartsGallery.Models;
using System.Windows.Input;

namespace ChartsGallery.Forms.ViewModels {
    public class MainViewModel : ViewModelBase {
        readonly InfoCommand infoCommand;
        readonly ThemeCommand themeCommand;
        readonly HeaderSeriesData headerSeriesData;

        public string Version => "Version 1.1.4";
        public string Title => "DevExpress";
        public string Address => "https://www.devexpress.com/products/native/chart/";
        public List<DemoItem> Items => DemoData.DemoItems;
        public HeaderSeriesData HeaderSeriesData => headerSeriesData;
        public InfoCommand InfoCommand => infoCommand;
        public ThemeCommand ThemeCommand => themeCommand;

        bool isLightTheme = true;
        public bool IsLightTheme {
            get { return isLightTheme; }
            set { SetProperty(ref isLightTheme, value, onChanged: () => ((App)Application.Current).ApplyTheme(isLightTheme) ); }
        }

        public MainViewModel() {
            infoCommand = new InfoCommand();
            themeCommand = new ThemeCommand(() => IsLightTheme = !isLightTheme );
            headerSeriesData = DemoData.GetHeaderSeriesData();
        }
    }

    public class InfoCommand : ICommand {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => Device.OpenUri(new Uri(parameter as string));
    }

    public class ThemeCommand : ICommand {
        Action action;
        public event EventHandler CanExecuteChanged { add { } remove { } }
        public ThemeCommand(Action action) => this.action = action;
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter) => action();
    }
}