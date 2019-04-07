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

namespace ChartsGallery.Forms.ViewModels {
    public class AreaChartViewModel : ChartViewModelBase {
        OutsideVendorCostsData chartData = new OutsideVendorCostsData();

        public override string Title => "Vendeor Costs";
        public XYSeriesData DevAVNorth => chartData.DevAVNorth;
        public XYSeriesData DevAVSouth => chartData.DevAVSouth;
    }

    public class StackedAreaChartViewModel : ChartViewModelBase {
        SalesByLastYearsData chartData = new SalesByLastYearsData();

        public override string Title => "DevAV Sales";
        public XYSeriesData NorthAmerica => chartData.NorthAmerica;
        public XYSeriesData Europe => chartData.Europe;
        public XYSeriesData Australia => chartData.Australia;
    }

    public class FullStackedAreaChartViewModel : ChartViewModelBase {
        BranchesSalesData chartData = new BranchesSalesData();

        public override string Title => "Market Share Over Time";
        public XYSeriesData DevAVEast => chartData.DevAVEast;
        public XYSeriesData DevAVWest => chartData.DevAVWest;
        public XYSeriesData DevAVSouth => chartData.DevAVSouth;
        public XYSeriesData DevAVCenter => chartData.DevAVCenter;
        public XYSeriesData DevAVNorth => chartData.DevAVNorth;
    }

    public class StepAreaChartViewModel : ChartViewModelBase {
        AverageDieselPricesData chartData = new AverageDieselPricesData();

        public override string Title => "U.S. Average Diesel Prices";
        public XYSeriesData DieselPrices => chartData.DieselPrices;
    }
}
