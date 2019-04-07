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
using System.Xml.Serialization;
using DevExpress.XamarinForms.Charts;

namespace ChartsGallery.Forms.Data {
    [XmlRoot("DataSetsContainer")]
    public class DataSetsContainer<T> {
        [XmlArrayItem]
        public List<DataSetContainer<T>> DataSets { get; set; }
    }

    [XmlRoot("DataSetContainer")]
    public class DataSetContainer<T> {
        [XmlElement]
        public string Name { get; set; }
        [XmlArrayItem]
        public List<T> DataSet { get; set; }
    }

    [XmlRoot("NumericDataSets")]
    public class NumericDataSets : DataSetsContainer<NumericData> { }
    [XmlRoot("DateTimeDataSets")]
    public class DateTimeDataSets : DataSetsContainer<DateTimeData> { }
    [XmlRoot("QualitativeDataSets")]
    public class QualitativeDataSets : DataSetsContainer<QualitativeData> { }


    public class XYSeriesData {
        string displayName;
        IXYSeriesData data;
        public string DisplayName => displayName;
        public IXYSeriesData Data => data;

        public XYSeriesData(string displayName, IXYSeriesData data) {
            this.displayName = displayName;
            this.data = data;
        }
    }

    public class QualitativeData {
        public string Argument { get; set; }
        public double Value { get; set; }
        public QualitativeData() { }
        public QualitativeData(string argument, double value) {
            Argument = argument;
            Value = value;
        }
    }
    public class QualitativeXYSeriesData : IXYSeriesData {
        readonly QualitativeData[] data;

        public QualitativeXYSeriesData(params QualitativeData[] data) {
            this.data = data;
        }

        public int GetDataCount() => data.Length;
        public SeriesDataType GetDataType() => SeriesDataType.Qualitative;
        public DateTime GetDateTimeArgument(int index) => DateTime.Now;
        public object GetKey(int index) => string.Empty;
        public double GetNumericArgument(int index) => 0;
        public string GetQualitativeArgument(int index) => data[index].Argument;
        public double GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index) => data[index].Value;
    }

    public class DateTimeData {
        public DateTime Argument { get; set; }
        public double Value { get; set; }
        public DateTimeData() { }
        public DateTimeData(DateTime argument, double value) {
            Argument = argument;
            Value = value;
        }
    }
    public class DateTimeXYSeriesData : IXYSeriesData {
        readonly IList<DateTime> arguments;
        readonly IList<double> values;

        public DateTimeXYSeriesData(params DateTimeData[] data) {
            this.arguments = new List<DateTime>();
            this.values = new List<double>();
            foreach (var item in data) {
                arguments.Add(item.Argument);
                values.Add(item.Value);
            }
        }

        public DateTimeXYSeriesData(IList<DateTime> arguments, IList<double> values) {
            this.arguments = arguments;
            this.values = values;
        }

        public int GetDataCount() => arguments.Count;
        public SeriesDataType GetDataType() => SeriesDataType.DateTime;
        public DateTime GetDateTimeArgument(int index) => arguments[index];
        public object GetKey(int index) => arguments[index];
        public double GetNumericArgument(int index) => 0;
        public string GetQualitativeArgument(int index) => string.Empty;
        public double GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index) => values[index];
    }

    public class NumericData {
        public double Argument { get; private set; }
        public double Value { get; private set; }
        public NumericData(double argument, double value) {
            Argument = argument;
            Value = value;
        }
    }
    public class NumericSeriesData : IXYSeriesData {
        readonly IList<double> arguments;
        readonly IList<double> values;

        public NumericSeriesData(IList<double> arguments, IList<double> values) {
            this.arguments = arguments;
            this.values = values;
        }
        public NumericSeriesData(params NumericData[] data) {
            this.arguments = new List<double>();
            this.values = new List<double>();
            foreach (var item in data) {
                arguments.Add(item.Argument);
                values.Add(item.Value);
            }
        }

        public int GetDataCount() => arguments.Count;
        public SeriesDataType GetDataType() => SeriesDataType.Numeric;
        public DateTime GetDateTimeArgument(int index) => DateTime.Now;
        public object GetKey(int index) => arguments[index];
        public double GetNumericArgument(int index) => arguments[index];
        public string GetQualitativeArgument(int index) => string.Empty;
        public double GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index) => values[index];
    }

    public class PieSeriesData : IPieSeriesData {
        readonly IList<string> categories;
        readonly IList<double> values;

        public PieSeriesData(IList<string> categories, IList<double> values) {
            this.categories = categories;
            this.values = values;
        }

        public int GetDataCount() => categories.Count;
        public string GetLabel(int index) => categories[index];
        public double GetValue(int index) => values[index];
        public object GetKey(int index) => categories[index];
    }

    static class SeriesDataCalculator {
        public static double GetAverageValue(IXYSeriesData data) {
            double result = 0;
            for (int i = 0; i < data.GetDataCount(); i++)
                result += data.GetValue(DevExpress.XamarinForms.Charts.ValueType.Value, i);
            return result / data.GetDataCount();
        }
    }
}
