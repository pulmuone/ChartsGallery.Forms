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
using DevExpress.XamarinForms.Charts;
using Xamarin.Forms;

namespace ChartsGallery.Forms {
    public partial class App : Application {
        public static ChartTheme Theme { get; set; }
        public NavigationPage NavigationPage { get; private set; }

        readonly string[][] styles = {
            new string[] { "navPageStyle", "darkNavPage", "lightNavPage" },
            new string[] { "chartStyle", "darkChart", "lightChart" },
            new string[] { "panelStyle", "darkPanel", "lightPanel" },
            new string[] { "labelStyle", "darkLabel", "lightLabel" },
            new string[] { "buttonStyle", "darkButton", "lightButton" },
            new string[] { "tabControlStyle", "darkTabControl", "lightTabControl" },
            new string[] { "listViewStyle", "darkListView", "lightListView" },
        };

        public App() {
            InitializeComponent();
        }
        internal void ApplyTheme(bool isLightTheme) {
            for (int i = 0; i < styles.Length; i++) 
                ((Style)Resources[styles[i][0]]).BasedOn = (Style)Resources[isLightTheme ? styles[i][2] : styles[i][1]];
        }
    }
}
