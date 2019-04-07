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
    public class HeaderSeriesData : IXYSeriesData, IChangeableSeriesData {
        const int dataCount = 200;

        readonly Timer timer;
        readonly Random random = new Random();
        readonly List<double> values = new List<double>();
        double lastValue = 0;
        int argumentOffset = 0;
        bool isRunning = false;

        public event DataChangedEventHandler DataChanged;

        public HeaderSeriesData() {
            for (int i = 0; i < dataCount; i++) {
                lastValue = GenerateNextValue(lastValue);
                values.Add(lastValue);
            }
            timer = new Timer(50);
            timer.Elapsed += OnTimerElapsed;
            timer.AutoReset = false;
        }
        double GenerateNextValue(double value) {
            return value + (random.NextDouble() * 10.0 - 5.0);
        }

        void OnTimerElapsed(object sender, ElapsedEventArgs e) {
            Device.BeginInvokeOnMainThread(() => {
                if (isRunning) {
                    DataChanged?.Invoke(this, DataChangedEventArgs.Remove(0));
                    values.Add(lastValue);
                    argumentOffset++;
                    lastValue = GenerateNextValue(lastValue);
                    values.RemoveAt(0);
                    DataChanged?.Invoke(this, DataChangedEventArgs.Add());
                    timer.Start();
                }
            });
        }
      
        public int GetDataCount() => values.Count;
        public double GetNumericArgument(int index) => index + argumentOffset;
        public SeriesDataType GetDataType() => SeriesDataType.Numeric;
        public DateTime GetDateTimeArgument(int index) => DateTime.Now;
        public string GetQualitativeArgument(int index) => string.Empty;
        public double GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index) => values[index];
        public object GetKey(int index) => string.Empty;

        public void Pause() {
            isRunning = false;
            timer.Stop();
        }
        public void Start() {
            isRunning = true;
            timer.Start();
        }
    }
}
