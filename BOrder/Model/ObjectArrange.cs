using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    /// <summary>
    /// 纸箱排列
    /// </summary>
    public class ObjectArrange : ModelBase
    {
        private double _row;
        public double Row
        {
            get
            {
                return _row;
            }
            set
            {
                SetProperty(ref _row, value, nameof(Row));
            }
        }
        private double _column;
        public double Column
        {
            get
            {
                return _column;
            }
            set
            {
                SetProperty(ref _column, value, nameof(Column));
            }
        } 
    }
}
