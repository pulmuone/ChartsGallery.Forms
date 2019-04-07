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
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using ChartsGallery.Forms.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(ExtNavigationRenderer))]
[assembly: ExportRenderer(typeof(ListView), typeof(ExtListViewRenderer))]
[assembly: ExportRenderer(typeof(ViewCell), typeof(ExtViewCellRenderer))]
namespace ChartsGallery.Forms.iOS {
    public class ExtNavigationRenderer : NavigationRenderer {
        public override void ViewDidLoad() {
            base.ViewDidLoad();
            NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            NavigationBar.ShadowImage = new UIImage();
        }
    }

    public class ExtListViewRenderer : ListViewRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e) {
            base.OnElementChanged(e);
            if (Element != null) {
                Control.AlwaysBounceVertical = Element.IsPullToRefreshEnabled;
                Control.Bounces = Element.IsPullToRefreshEnabled;
            }
        }
    }

    public class ExtViewCellRenderer : ViewCellRenderer {
        readonly UIView selectedView = new UIView() { BackgroundColor = UIColor.FromRGBA(0, 0, 0, 48) };
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv) {
            var cell = base.GetCell(item, reusableCell, tv);
            if (cell != null)
                cell.SelectedBackgroundView = selectedView;
            return cell;
        }
    }
}