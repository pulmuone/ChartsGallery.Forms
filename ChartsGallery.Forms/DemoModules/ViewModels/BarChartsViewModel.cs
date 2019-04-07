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
using Xamarin.Forms;

namespace ChartsGallery.Forms.ViewModels {
    public class BarChartViewModel : ChartViewModelBase {
        PopulationStructureData chartData = new PopulationStructureData();

        public override string Title => "Population Structure";
        public XYSeriesData MaleSeriesData => chartData.MaleSeriesData;
        public XYSeriesData FemaleSeriesData => chartData.FemaleSeriesData;
    }

    public class StackedBarChartViewModel : ChartViewModelBase {
        AgeStructureData chartData = new AgeStructureData();

        public override string Title => "Age Structure";
        public XYSeriesData Male0to14and65SeriesData => chartData.Male0to14and65SeriesData;
        public XYSeriesData Male15to64SeriesData => chartData.Male15to64SeriesData;
    }

    public class SideBySideStackedBarChartViewModel : ChartViewModelBase {
        AgeStructureData chartData = new AgeStructureData();
        Color[] palette = PaletteLoader.LoadPalette("#FF42A5F5", "#b342a5f5", "#FFFF5252", "#b3ff5252");

        public override string Title => "Age Structure";
        public Color[] Palette => palette;
        public XYSeriesData Male0to14and65SeriesData => chartData.Male0to14and65SeriesData;
        public XYSeriesData Male15to64SeriesData => chartData.Male15to64SeriesData;
        public XYSeriesData Female0to14and65SeriesData => chartData.Female0to14and65SeriesData;
        public XYSeriesData Female15to64SeriesData => chartData.Female15to64SeriesData;
    }

    public class FullStackedBarChartViewModel : ChartViewModelBase {
        DevAVSalesMixByRegionData chartData = new DevAVSalesMixByRegionData();

        public override string Title => "DevAV Sales Mix By Region";
        public XYSeriesData ProjectorsSeriesData => chartData.ProjectorsSeriesData;
        public XYSeriesData TelevisionsSeriesData => chartData.TelevisionsSeriesData;
    }
}
