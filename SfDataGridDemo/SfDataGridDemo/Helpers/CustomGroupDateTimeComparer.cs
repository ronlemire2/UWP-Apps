﻿using SfDataGridDemo.Converters;
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Controls.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridDemo.Helpers {
    public class CustomGroupDateTimeComparer : IComparer<Object>, IColumnAccessProvider, ISortDirection {
        /// <summary>
        /// SortDirection gives the dirction of sorting.
        /// </summary>
        public ListSortDirection SortDirection { get; set; }

        /// <summary>
        /// This Compare method helps to compare the values and it will return the SortDirection.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y) {
            var group = (x as Group);
            var group1 = (y as Group);
            for (int i = 0; i < (x as Group).GetTopLevelGroup().GroupDescriptions.Count; i++) {
                if (group.Records == null) {
                    group = group.Groups.FirstOrDefault() as Group;
                    group1 = group1.Groups.FirstOrDefault() as Group;
                }
            }
            object record = group.Records.FirstOrDefault().Data;
            object record1 = group1.Records.FirstOrDefault().Data;
            var key1 = PropertyReflector.GetValue(record, ColumnName);
            var key2 = PropertyReflector.GetValue(record1, ColumnName);
            var ColumnType = key1.GetType();
            int compareFirstValue = 0, compareSecondValue = 0;
            DateTime date = (DateTime)key1;
            DateTime date1 = (DateTime)key2;
            if (GroupMode == DateGroupingMode.Month) {
                compareFirstValue = date.Month;
                compareSecondValue = date1.Month;
            }
            else if (GroupMode == DateGroupingMode.Year) {
                compareFirstValue = date.Year;
                compareSecondValue = date.Year;
            }
            else {
                var dt = (Converters.DateRange)group.Key;
                var dt1 = (Converters.DateRange)group1.Key;
                compareFirstValue = (int)dt;
                compareSecondValue = (int)dt1;
            }

            var diff = compareFirstValue.CompareTo(compareSecondValue);

            if (diff > 0)
                return SortDirection == ListSortDirection.Ascending ? 1 : -1;
            if (diff == -1)
                return SortDirection == ListSortDirection.Ascending ? -1 : 1;
            return 0;
        }

        /// <summary>
        /// Gets or sets the GroupMode to Group the Date-Time Column
        /// </summary>
        private DateGroupingMode groupMode;
        public DateGroupingMode GroupMode {
            get { return this.groupMode; }
            set { groupMode = value; }
        }
        /// <summary>
        /// ColumnName property helps to identify which column is getting into the Group.
        /// </summary>
        private string _ColumnName;
        public string ColumnName {
            get { return this._ColumnName; }
            set { _ColumnName = value; }
        }

        /// <summary>
        /// This PropertyReflector property helps to the value.
        /// </summary>
        private IPropertyAccessProvider _propertyReflector;
        public IPropertyAccessProvider PropertyReflector {
            get { return this._propertyReflector; }
            set { _propertyReflector = value; }
        }
    }


    public class CustomGroupNumericComparer : IComparer<object>, IColumnAccessProvider, ISortDirection {

        /// <summary>
        /// This Compare method helps to compare the values and it will return the SortDirection.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y) {
            var group = (x as Group);
            var group1 = (y as Group);
            for (int i = 0; i < (x as Group).GetTopLevelGroup().GroupDescriptions.Count; i++) {
                if (group.Records == null) {
                    group = group.Groups.FirstOrDefault() as Group;
                    group1 = group1.Groups.FirstOrDefault() as Group;
                }
            }
            object record = group.Records.FirstOrDefault().Data;
            object record1 = group1.Records.FirstOrDefault().Data;
            var key1 = PropertyReflector.GetValue(record, ColumnName);
            var key2 = PropertyReflector.GetValue(record1, ColumnName);
            int compareFirstValue = Convert.ToInt32(key1);
            int compareSecondValue = Convert.ToInt32(key2);
            var diff = compareFirstValue.CompareTo(compareSecondValue);

            if (diff > 0)
                return SortDirection == ListSortDirection.Ascending ? 1 : -1;
            if (diff == -1)
                return SortDirection == ListSortDirection.Ascending ? -1 : 1;
            return 0;
        }

        /// <summary>
        /// ColumnName property helps to identify which column is getting into the Group.
        /// </summary>
        private string columnName;
        public string ColumnName {
            get { return this.columnName; }
            set { columnName = value; }
        }

        /// <summary>
        /// This PropertyReflector property helps to the value.
        /// </summary>
        private IPropertyAccessProvider propertyReflector;
        public IPropertyAccessProvider PropertyReflector {
            get { return this.propertyReflector; }
            set { propertyReflector = value; }
        }

        /// <summary>
        /// Gets or sets the SortDirection
        /// </summary>
        public ListSortDirection SortDirection { get; set; }
    }

    public class CustomGroupTextComparer : IComparer<object>, IColumnAccessProvider, ISortDirection {
        /// <summary>
        /// ColumnName property helps to identify which column is getting into the Group.
        /// </summary>
        private string columnName;
        public string ColumnName {
            get { return this.columnName; }
            set { columnName = value; }
        }

        /// <summary>
        /// This PropertyReflector property helps to the value.
        /// </summary>
        private IPropertyAccessProvider propertyReflector;
        public IPropertyAccessProvider PropertyReflector {
            get { return this.propertyReflector; }
            set { propertyReflector = value; }
        }

        /// <summary>
        /// Gets or sets the SortDirection
        /// </summary>
        public ListSortDirection SortDirection { get; set; }

        /// <summary>
        /// This Compare method helps to compare the values and it will return the SortDirection.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y) {
            var group = (x as Group);
            var group1 = (y as Group);
            for (int i = 0; i < (x as Group).GetTopLevelGroup().GroupDescriptions.Count; i++) {
                if (group.Records == null) {
                    group = group.Groups.FirstOrDefault() as Group;
                    group1 = group1.Groups.FirstOrDefault() as Group;
                }
            }
            object record = group.Records.FirstOrDefault().Data;
            object record1 = group1.Records.FirstOrDefault().Data;
            var key1 = PropertyReflector.GetValue(record, ColumnName);
            var key2 = PropertyReflector.GetValue(record1, ColumnName);
            char[] first = key1.ToString().ToCharArray();
            char[] second = key2.ToString().ToCharArray();
            int compareFirstValue = Convert.ToInt32(first[0]);
            int compareSecondValue = Convert.ToInt32(second[0]);
            var diff = compareFirstValue.CompareTo(compareSecondValue);

            if (diff > 0)
                return SortDirection == ListSortDirection.Ascending ? 1 : -1;
            if (diff == -1)
                return SortDirection == ListSortDirection.Ascending ? -1 : 1;
            return 0;
        }
    }
}
