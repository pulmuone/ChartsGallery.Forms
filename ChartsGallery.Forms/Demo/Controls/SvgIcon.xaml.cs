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
using System.IO;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;

namespace ChartsGallery.Forms.Demo {
    public partial class SvgIcon : ContentView {
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("ImageSource", typeof(string), typeof(SvgIcon), propertyChanged: ImageSourcePropertyChanged);
        static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue) => ((SvgIcon)bindable).OnImageSourceChanged((string)newValue);
        public string ImageSource { get => (string)GetValue(ImageSourceProperty); set => SetValue(ImageSourceProperty, value); }

        SkiaSharp.Extended.Svg.SKSvg svg;

        public SvgIcon() {
            InitializeComponent();
        }

        void OnImageSourceChanged(string newValue) {
            if (!string.IsNullOrWhiteSpace(newValue)) {
                using (Stream stream = GetType().Assembly.GetManifestResourceStream(newValue)) {
                    svg = new SkiaSharp.Extended.Svg.SKSvg();
                    svg.Load(stream);
                }
            }
            else svg = null;
            ((SKCanvasView)Content).InvalidateSurface();
        }

        void Handle_PaintSurface(object sender, SKPaintSurfaceEventArgs e) {
            if (svg != null) {
                SKCanvas canvas = e.Surface.Canvas;
                canvas.Clear();
                SKRect svgBounds = svg.ViewBox;
                SKImageInfo info = e.Info;
                canvas.Translate(info.Width / 2f, info.Height / 2f);
                float ratio = Math.Min(info.Width / svgBounds.Width, info.Height / svgBounds.Height);
                canvas.Scale(ratio);
                canvas.Translate(-svgBounds.MidX, -svgBounds.MidY);
                canvas.DrawPicture(svg.Picture);
            }
        }
    }
}
