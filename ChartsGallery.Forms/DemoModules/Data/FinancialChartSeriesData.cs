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
using System.IO;
using System.Xml.Serialization;
using DevExpress.XamarinForms.Charts;
using Xamarin.Forms;

namespace ChartsGallery.Forms.Data {
    [XmlRoot(ElementName = "StockPrices")]
    public class StockPrices : List<StockPrice> { }

    public class StockPrice {
        public DateTime Date { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
    }

    public class StockData {
        public static StockPrices GetStockPrices() {
            StockPrices stockPrices;
            var assembly = typeof(StockData).Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("Resources.GoogleStock.xml")) {
                var serializer = new XmlSerializer(typeof(StockPrices));
                stockPrices = (StockPrices)serializer.Deserialize(stream);
            }
            return stockPrices;
        }
    }

    public class StockSeriesData : IXYSeriesData {
        StockPrices stockPrices;
        SeriesDataType seriesDataType;

        public StockSeriesData(StockPrices stockPrices, SeriesDataType seriesDataType) {
            this.stockPrices = stockPrices;
            this.seriesDataType = seriesDataType;
        }

        public int GetDataCount() => stockPrices.Count;
        public SeriesDataType GetDataType() => seriesDataType;
        public DateTime GetDateTimeArgument(int index) => stockPrices[index].Date;
        public double GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index) {
            switch (valueType) {
                case DevExpress.XamarinForms.Charts.ValueType.Value: return stockPrices[index].Volume;
                case DevExpress.XamarinForms.Charts.ValueType.High: return stockPrices[index].High;
                case DevExpress.XamarinForms.Charts.ValueType.Low: return stockPrices[index].Low;
                case DevExpress.XamarinForms.Charts.ValueType.Open: return stockPrices[index].Open;
                case DevExpress.XamarinForms.Charts.ValueType.Close: return stockPrices[index].Close;
            }
            return 0;
        }
        public double GetNumericArgument(int index) { return 0; }
        public string GetQualitativeArgument(int index) { return string.Empty; }
        public object GetKey(int index) => string.Empty;
    }

    public class CalculatedSeriesData : BindableObject, ICalculatedSeriesData {
        readonly Series masterSeries;

        public CalculatedSeriesData(Series masterSeries) {
            this.masterSeries = masterSeries;
        }
        public Series Series { get => masterSeries; }
    }
}
