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
using System.Collections.Generic;
using ChartsGallery.Forms.Views;
using ChartsGallery.Models;

namespace ChartsGallery.Forms.Data {
    public class DemoData {
        static List<DemoItem> demoItems;

        static DemoData() {
            demoItems = new List<DemoItem>() {
                new DemoItem() {
                    Title = "Financial Chart",
                    Description="Displays Open-High-Low-Close stock price statistics as Candles Bars.",
                    Module = typeof(FinancialChart),
                    Icon = "MainList.FinancialChart.svg"},
                new DemoItem() {
                    Title = "Real-Time Data Updates",
                    Description="Displays an auto-refreshed Line Chart bound to a frequently updated dataset.",
                    Module = typeof(RealTimeData),
                    Icon = "MainList.RealTimeData.svg"},
                new DemoItem() {
                    Title = "Selection",
                    Description="Demonstrates support for series and point selection within a chart.",
                    Module = typeof(Selection),
                    Icon = "MainList.Selection.svg"},
                new DemoItem() {
                    Title = "Large Dataset",
                    Description="Demonstrates the speed with which DevExpress Charts can render a large number of points.",
                    Module = typeof(LargeDataset),
                    Icon = "MainList.LargeDataset.svg"},
                new DemoItem() {
                    Title = "Bar Charts",
                    Description="Demonstrates Stacked and Side-by-Side Bar series chart views.",
                    Module = typeof(BarCharts),
                    Icon = "MainList.BarCharts.svg"},
                new DemoItem() {
                    Title = "Line Charts",
                    Description="Demonstrates use of Simple, Scatter, and Step Line chart series views.",
                    Module = typeof(LineCharts),
                    Icon = "MainList.LineCharts.svg"},
                new DemoItem() {
                    Title = "Point & Bubble Charts",
                    Description="Demonstrates the use of Point and Bubble chart series views.",
                    Module = typeof(PointsCharts),
                    Icon = "MainList.PointsCharts.svg"},
                new DemoItem() {
                    Title = "Area Charts",
                    Description="Demonstrates Simple, Stacked and Step Area chart series views.",
                    Module = typeof(AreaCharts),
                    Icon = "MainList.AreaCharts.svg"},
                new DemoItem() {
                    Title = "Pie & Donut Charts",
                    Description="Demonstrates the use of multi-series Pie and Donut chart views.",
                    Module = typeof(PieCharts),
                    Icon = "MainList.PieCharts.svg"},
            };

        }

        public static HeaderSeriesData GetHeaderSeriesData() => new HeaderSeriesData();
        public static List<DemoItem> DemoItems => demoItems;
    }
}
