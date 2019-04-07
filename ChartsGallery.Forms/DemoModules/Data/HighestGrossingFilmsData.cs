﻿/*                                                         
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
using DevExpress.XamarinForms.Charts;

namespace ChartsGallery.Forms.Data {
    public class HighestGrossingFilmsByYearData : IXYSeriesData {
        class Data {
            public DateTime Date { get; private set; }
            public string Name { get; private set; }
            public double Value { get; private set; }
            public double WorldwideGrosses { get; private set; }
            public Data(DateTime date, string name, double value, double worldwideGrosses) {
                Date = date;
                Name = name;
                Value = value;
                WorldwideGrosses = worldwideGrosses;
            }
        }

        public class KeyData {
            public int Index { get; private set; }
            public string Name { get; private set; }
            public KeyData(int index, string name) {
                Index = index;
                Name = name;
            }
        }

        List<Data> data = new List<Data> {
            new Data(new DateTime(2007, 1, 1), "Pirates of the Caribbean: At World's End", 300D, 0.963),
            new Data(new DateTime(2008, 1, 1), "The Dark Knight", 185D, 1.004),
            new Data(new DateTime(2009, 1, 1), "Avatar", 237D, 2.788),
            new Data(new DateTime(2010, 1, 1), "Toy Story 3", 200D, 1.067),
            new Data(new DateTime(2011, 1, 1), "Harry Potter and the Deathly Hallows Part 2", 250D, 1.341),
            new Data(new DateTime(2012, 1, 1), "Marvel's The Avengers", 220D, 1.519),
            new Data(new DateTime(2013, 1, 1), "Frozen", 150D, 1.276),
            new Data(new DateTime(2014, 1, 1), "Transformers: Age of Extinction", 210D, 1.104),
            new Data(new DateTime(2015, 1, 1), "Star Wars: The Force Awakens", 245D, 2.068),
            new Data(new DateTime(2016, 1, 1), "Captain America: Civil War", 250D, 1.153),
        };

        public int GetDataCount() => data.Count;
        public SeriesDataType GetDataType() => SeriesDataType.WeightedDateTime;
        public DateTime GetDateTimeArgument(int index) => data[index].Date;
        public object GetKey(int index) => new KeyData(index, data[index].Name);
        public double GetNumericArgument(int index) => 0;
        public string GetQualitativeArgument(int index) => string.Empty;
        public double GetValue(DevExpress.XamarinForms.Charts.ValueType valueType, int index) {
            switch (valueType) {
                case DevExpress.XamarinForms.Charts.ValueType.Value:
                    return data[index].Value;
                case DevExpress.XamarinForms.Charts.ValueType.Weight:
                    return data[index].WorldwideGrosses;
                default:
                    return 0.0;
            }
        }
    }
}
