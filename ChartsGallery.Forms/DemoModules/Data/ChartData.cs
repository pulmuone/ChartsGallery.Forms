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
using System.Collections.Generic;

namespace ChartsGallery.Forms.Data {
    public class OutsideVendorCostsData {
        List<XYSeriesData> seriesData;
        public XYSeriesData DevAVNorth => seriesData[0];
        public XYSeriesData DevAVSouth => seriesData[1];

        public OutsideVendorCostsData() {
            seriesData = XmlDataDeserializer.GetDateTimeSeriesData("Resources.OutsideVendorCosts.xml");
        }
    }

    public class PopulationStructureData {
        List<XYSeriesData> seriesData;

        public XYSeriesData MaleSeriesData => seriesData[0];
        public XYSeriesData FemaleSeriesData => seriesData[1];

        public PopulationStructureData() {
            seriesData = XmlDataDeserializer.GetQualitativeSeriesData("Resources.PopulationStructure.xml");
        }
    }

    public class AgeStructureData {
        List<XYSeriesData> seriesData;

        public XYSeriesData Male0to14and65SeriesData => seriesData[0];
        public XYSeriesData Male15to64SeriesData => seriesData[1];
        public XYSeriesData Female0to14and65SeriesData => seriesData[2];
        public XYSeriesData Female15to64SeriesData => seriesData[3];

        public AgeStructureData() {
            seriesData = XmlDataDeserializer.GetQualitativeSeriesData("Resources.AgeStructure.xml");
        }
    }

    public class DevAVSalesMixByRegionData {
        List<XYSeriesData> seriesData;

        public XYSeriesData ProjectorsSeriesData => seriesData[0];
        public XYSeriesData TelevisionsSeriesData => seriesData[1];

        public DevAVSalesMixByRegionData() {
            seriesData = XmlDataDeserializer.GetQualitativeSeriesData("Resources.DevAVSalesMixByRegion.xml");
        }
    }

    public class AverageDieselPricesData {
        List<XYSeriesData> seriesData;
        public XYSeriesData DieselPrices => seriesData[0];

        public AverageDieselPricesData() {
            seriesData = XmlDataDeserializer.GetDateTimeSeriesData("Resources.AverageDieselPrices.xml");
        }
    }

    public class LondonWeatherData {
        List<XYSeriesData> seriesData;

        public XYSeriesData NightMin => seriesData[0];
        public XYSeriesData DayMax => seriesData[1];
        public double NightMinAverageValue => SeriesDataCalculator.GetAverageValue(NightMin.Data);
        public double DayMaxAverageValue => SeriesDataCalculator.GetAverageValue(DayMax.Data);

        public LondonWeatherData() {
            seriesData = XmlDataDeserializer.GetDateTimeSeriesData("Resources.LondonWeather.xml");
        }
    }

    public class TrendPopulationData {
        List<XYSeriesData> seriesData;

        public XYSeriesData Europe => seriesData[0];
        public XYSeriesData Americas => seriesData[1];
        public XYSeriesData Africa => seriesData[2];

        public TrendPopulationData() {
            seriesData = XmlDataDeserializer.GetDateTimeSeriesData("Resources.TrendPopulation.xml");
        }
    }

    public class SalesByLastYearsData {
        readonly string[] names = { "North America", "Europe", "Australia" };
        readonly double[][] values = {
            new double[] { 2.666, 3.665, 3.555, 3.485, 3.747, 4.182 },
            new double[] { 2.078, 3.888, 3.008, 3.088, 3.357, 3.725 },
            new double[] { 1.09, 2.01, 1.85, 1.78, 1.957, 2.272 }
        };
        List<XYSeriesData> seriesData = new List<XYSeriesData>();

        public XYSeriesData NorthAmerica => seriesData[0];
        public XYSeriesData Europe => seriesData[1];
        public XYSeriesData Australia => seriesData[2];

        public SalesByLastYearsData() {
            int year = DateTime.Now.Year;
            for (int i = 0; i < names.Length; i++) {
                List<DateTimeData> data = new List<DateTimeData>();
                for (int j = 0; j < values[i].Length; j++)
                    data.Add(new DateTimeData(new DateTime(year - values[i].Length + j, 1, 1), values[i][j]));
                seriesData.Add(new XYSeriesData(names[i], new DateTimeXYSeriesData(data.ToArray())));
            }
        }
    }

    public class BranchesSalesData {
        readonly string[] names = { "DevAV East", "DevAV West", "DevAV South", "DevAV Center", "DevAV North" };
        readonly double[][] values = {
            new double[] { 0D, 0D, 0.003, 0.32, 0.51, 1.71 },
            new double[] { 0.95, 1.53, 1.75, 1.31, 1.31, 1.22 },
            new double[] { 1.09, 1.01, 1.11, 1.12, 1.12, 1.111 },
            new double[] { 2.078, 3.888, 3.008, 3.088, 3.357, 3.725 },
            new double[] { 2.666, 3.665, 3.555, 3.485, 3.747, 4.182 }
        };

        List<XYSeriesData> seriesData = new List<XYSeriesData>();

        public XYSeriesData DevAVEast => seriesData[0];
        public XYSeriesData DevAVWest => seriesData[1];
        public XYSeriesData DevAVSouth => seriesData[2];
        public XYSeriesData DevAVCenter => seriesData[3];
        public XYSeriesData DevAVNorth => seriesData[4];

        public BranchesSalesData() {
            GenerateData();
        }
        void GenerateData() {
            int year = DateTime.Now.Year;
            for (int i = 0; i < names.Length; i++) {
                List<DateTimeData> data = new List<DateTimeData>();
                for (int j = 0; j < values[i].Length; j++)
                    data.Add(new DateTimeData(new DateTime(year - values[i].Length + j, 1, 1), values[i][j]));
                seriesData.Add(new XYSeriesData(names[i], new DateTimeXYSeriesData(data.ToArray())));
            }
        }
    }

    public class SalesByYearsData {
        static DateTime StartDate = new DateTime(DateTime.Now.Year, 1, 1).AddYears(-10);
        readonly IList<string> categories = new List<string> { "Asia", "Australia", "Europe", "N. America", "S. America" };
        readonly IList<IList<double>> values = new List<IList<double>> {
            new List<double> { 1.8532D, 1.9849D, 2.4372D, 2.5147D, 2.7514D, 2.8532D, 3.5849D, 4.2372D, 4.7685D, 5.2890D },
            new List<double> { 0.6988D, 0.8320D, 0.8711D, 0.9210D, 0.9651D, 1.2586D, 1.5744D, 1.7871D, 1.9576D, 2.2727D },
            new List<double> { 1.1210D, 1.1311D, 1.3025D, 1.3214D, 1.4284D, 1.9579D, 2.5664D, 3.0884D, 3.3579D, 3.7257D },
            new List<double> { 1.9855D, 2.1288D, 2.4855D, 2.7477D, 2.8825D, 2.9855D, 3.0788D, 3.4855D, 3.7477D, 4.1825D },
            new List<double> { 0.9127D, 0.9734D, 0.9927D, 1.1237D, 1.3172D, 1.3827D, 1.5734D, 1.6027D, 1.8237D, 2.1172D }
        };
        public IList<DateTimeXYSeriesData> Data { get; private set; } = new List<DateTimeXYSeriesData>();
        public PieSeriesData PieData { get; private set; }

        public SalesByYearsData() {
            IList<DateTime> arguments = new List<DateTime>();
            for (int i = 0; i < values[0].Count; i++)
                arguments.Add(StartDate.AddYears(i));
            IList<double> sumByYears = new List<double>();
            foreach (IList<double> valuesByYear in values) {
                Data.Add(new DateTimeXYSeriesData(arguments, valuesByYear));
                sumByYears.Add(valuesByYear.Sum());
            }
            PieData = new PieSeriesData(categories, sumByYears);
        }
    }

    public class BondPortfolioDiversification {
        PieSeriesData securitiesByTypes;
        PieSeriesData securitiesByRisk;

        public PieSeriesData SecuritiesByTypes => securitiesByTypes;
        public PieSeriesData SecuritiesByRisk => securitiesByRisk;

        public BondPortfolioDiversification() {
            securitiesByTypes = new PieSeriesData(
                new List<string>() { "Stock", "Mutual Fund", "Bond" },
                new List<double>() { 417360.00, 27414.32, 35682.00 }
            );
            securitiesByRisk = new PieSeriesData(
                new List<string>() { "Income", "Growth", "Speculation", "Hedge" },
                new List<double>() { 132826.00, 208816.0, 24700.00, 80114.00 }
            );
        }
    }
    public class SecuritesByRiskAndTypes {
        PieSeriesData rating;
        PieSeriesData security;

        public PieSeriesData Rating => rating;
        public PieSeriesData Security => security;

        public SecuritesByRiskAndTypes() {
            rating = new PieSeriesData(
                new List<string>() { "AA", "MBB+", "BBB", "BBB-", "NR" },
                new List<double>() { 13, 7, 45, 20, 15 }
            );
            security = new PieSeriesData(
                new List<string>() { "FRN", "FCB", "CIB", "IAB" },
                new List<double>() { 16.0, 41.0, 25.0, 18.0 }
            );
        }
    }

}