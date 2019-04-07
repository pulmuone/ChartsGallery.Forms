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
using System.Timers;
using DevExpress.XamarinForms.Charts;
using Xamarin.Forms;

namespace ChartsGallery.Forms.Data {
    public class RealTimeSeriesData : IXYSeriesData, IChangeableSeriesData {
        static readonly int MaxDataCount = 300;

        readonly List<DateTimeData> data = new List<DateTimeData>();

        public event DataChangedEventHandler DataChanged;

        public void AddData(double value) {
            data.Add(new DateTimeData(DateTime.Now, value));
            DataChanged?.Invoke(this, DataChangedEventArgs.Add());
            if (data.Count > MaxDataCount) {
                data.RemoveAt(0);
                DataChanged?.Invoke(this, DataChangedEventArgs.Remove(0));
            }
        }

        public SeriesDataType GetDataType() => SeriesDataType.DateTime;
        public int GetDataCount() => data.Count;
        public string GetQualitativeArgument(int index) => string.Empty;
        public double GetNumericArgument(int index) => 0;
        public DateTime GetDateTimeArgument(int index) => data[index].Argument;
        public double GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index) => data[index].Value;
        public object GetKey(int index) => null;
    }

    public interface ISensor {
        void Start();
        void Stop();
        double GetXValue();
        double GetYValue();
        double GetZValue();
        bool IsData { get; }
    }

    public class AccelerometerDataProvider {
        static readonly int Delay = 10;

        readonly RealTimeSeriesData xAxisSeriesData = new RealTimeSeriesData();
        readonly RealTimeSeriesData yAxisSeriesData = new RealTimeSeriesData();
        readonly RealTimeSeriesData zAxisSeriesData = new RealTimeSeriesData();
        readonly ISensor sensor;

        readonly Timer timer;
        readonly ChartView chart;
        bool isRunning = false;

        public RealTimeSeriesData XAxisSeriesData => xAxisSeriesData;
        public RealTimeSeriesData YAxisSeriesData => yAxisSeriesData;
        public RealTimeSeriesData ZAxisSeriesData => zAxisSeriesData;

        public AccelerometerDataProvider(ChartView chart) {
            this.chart = chart;
            timer = new Timer(Delay);
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = false;
            sensor = DependencyService.Get<ISensor>();
        }

        void OnTimerElapsed(object sender, ElapsedEventArgs e) {
            Device.BeginInvokeOnMainThread(() => {
                if (isRunning) {
                    if (sensor != null && sensor.IsData) {
                        chart.SuspendRender();
                        xAxisSeriesData.AddData(sensor.GetXValue());
                        yAxisSeriesData.AddData(sensor.GetYValue());
                        zAxisSeriesData.AddData(sensor.GetZValue());
                        chart.ResumeRender();
                    }
                    timer.Start();
                }
            });
        }

        public void Stop() {
            isRunning = false;
            timer.Stop();
            sensor?.Stop();
        }
        public void Start() {
            isRunning = true;
            timer.Start();
            sensor?.Start();
        }
    }
}
