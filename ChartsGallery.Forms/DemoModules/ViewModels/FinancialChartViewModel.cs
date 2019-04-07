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
using ChartsGallery.Forms.Data;
using DevExpress.XamarinForms.Charts;

namespace ChartsGallery.Forms.ViewModels {
    public class FinancialChartViewModel : ChartViewModelBase {
        readonly CalculatedSeriesData calculatedSeriesData;
        readonly StockSeriesData stockSeriesData;
        readonly StockSeriesData volumeSeriesData;
        DateTimeRange visualRange;

        public CalculatedSeriesData CalculatedSeriesData => calculatedSeriesData;
        public StockSeriesData StockSeriesData => stockSeriesData;
        public StockSeriesData VolumeSeriesData => volumeSeriesData;
        public DateTimeRange VisualRange => visualRange;

        public FinancialChartViewModel(Series masterSeries) {
            StockPrices stockPrices = StockData.GetStockPrices();
            calculatedSeriesData = new CalculatedSeriesData(masterSeries);
            stockSeriesData = new StockSeriesData(stockPrices, DevExpress.XamarinForms.Charts.SeriesDataType.Financial);
            volumeSeriesData = new StockSeriesData(stockPrices, DevExpress.XamarinForms.Charts.SeriesDataType.DateTime);
            visualRange = new DateTimeRange() { VisualMin = new System.DateTime(2016, 7, 29), VisualMax = new System.DateTime(2016, 10, 15) };
        }
    }
}
