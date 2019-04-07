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
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Xamarin.Forms;

namespace ChartsGallery.Forms.Demo {
    [ContentProperty("Items")]
    public partial class TabControl : ContentView {
        public static readonly BindablePropertyKey ItemsPropertyKey = BindableProperty.CreateReadOnly("Items", typeof(ObservableCollection<TabItem>), typeof(TabControl), null);
        public static readonly BindableProperty ItemsProperty = ItemsPropertyKey.BindableProperty;
        public ObservableCollection<TabItem> Items { get => (ObservableCollection<TabItem>)GetValue(ItemsProperty); }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(TabControl), Color.FromHex("#CCCCCC"), propertyChanged:BorderColorPropertyChanged);
        static void BorderColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabControl)bindable).OnBorderColorChanged((Color)newValue);
        public Color BorderColor { get => (Color)GetValue(BorderColorProperty); set => SetValue(BorderColorProperty, value); }

        public static readonly BindableProperty SelectedItemBackgroundColorProperty = BindableProperty.Create("SelectedItemBackgroundColor", typeof(Color), typeof(TabControl), Color.FromHex("#FFFFFF"), propertyChanged: SelectedItemBackgroundColorPropertyChanged);
        static void SelectedItemBackgroundColorPropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((TabControl)bindable).OnSelectedItemBackgroundColorChanged((Color)newValue);
        public Color SelectedItemBackgroundColor { get => (Color)GetValue(SelectedItemBackgroundColorProperty); set => SetValue(SelectedItemBackgroundColorProperty, value); }

        public static readonly BindablePropertyKey IsLandscapePropertyKey = BindableProperty.CreateReadOnly("IsLandscape", typeof(bool), typeof(TabControl), false);
        public static readonly BindableProperty IsLandscapeProperty = IsLandscapePropertyKey.BindableProperty;
        public bool IsLandscape { get => (bool)GetValue(IsLandscapeProperty); }

        TabItem selectedItem;
        TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

        public TabControl() {
            var items = new ObservableCollection<TabItem>();
            items.CollectionChanged += ItemsCollectionChanged;
            SetValue(ItemsPropertyKey, items);
            tapGestureRecognizer.Tapped += TabButtonTapped;
            InitializeComponent();
            SizeChanged += (s, e) => UpdateOrientation(Width, Height);
            BindingContext = this;
            UpdateOrientation(Width, Height);
        }

        void TabButtonTapped(object sender, EventArgs e) {
            TabItem newItem = Items.First((item) => item.GetButton() == sender);
            if (newItem != null && selectedItem != newItem) {
                newItem.SetVisibility(true);
                if (selectedItem != null)
                    selectedItem.SetVisibility(false);
                selectedItem = newItem;
            }
        }
        void OnBorderColorChanged(Color newValue) {
            if (Items != null) {
                foreach (TabItem item in Items)
                    if (item.GetButton() != null)
                        item.GetButton().BorderColor = newValue;
            }
        }
        void OnSelectedItemBackgroundColorChanged(Color newValue) {
            if (Items != null) {
                foreach (TabItem item in Items)
                    if (item.GetButton() != null)
                        item.GetButton().SelectedColor = newValue;
            }
        }
        void ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.NewItems != null) {
                foreach (TabItem item in e.NewItems) {
                    item.Initialize();
                    item.GetButton().GestureRecognizers.Add(tapGestureRecognizer);
                    item.GetButton().BorderColor = BorderColor;
                    item.GetButton().SelectedColor = SelectedItemBackgroundColor;
                    stackLayout.Children.Add(item.GetButton());
                    viewsContainer.Children.Add(item.GetContentView());
                }
                if (selectedItem == null) {
                    selectedItem = Items[0];
                    selectedItem.SetVisibility(true);
                }
            }
        }
        void UpdateOrientation(double width, double height) {
            SetValue(IsLandscapePropertyKey, width > height);
            foreach (TabItem item in Items)
                if (item.GetButton() != null)
                    item.GetButton().IsVertical = IsLandscape;
        }
    }

    [ContentProperty("View")]
    public class TabItem : BindableObject {
        TabButton button;
        ContentView contentView;

        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(string), typeof(TabItem));
        public string ImageSource { get => (string)GetValue(ImageSourceProperty); set => SetValue(ImageSourceProperty, value); }

        public static readonly BindableProperty ViewProperty = BindableProperty.Create("View", typeof(View), typeof(TabItem), null, BindingMode.Default);
        public View View {
            get => (View)GetValue(ViewProperty);
            set => SetValue(ViewProperty, value);
        }

        internal TabButton GetButton() => button;
        internal ContentView GetContentView() => contentView;

        internal void SetVisibility(bool isVisible) {
            if (button != null)
                button.IsSelected = isVisible;
            if (contentView != null)
                contentView.IsVisible = isVisible;
        }

        internal void Initialize() {
            contentView = new ContentView {
                IsVisible = false,
                Content = View,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            button = new TabButton() { ImageSource = ImageSource };
        }
    }
}
