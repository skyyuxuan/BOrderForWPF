using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    public class FloorSizeCount : ModelBase
    {
        private int _widthCount;
        //与产品的宽对应
        public int WidthCount
        {
            get { return _widthCount; }

            set { SetProperty(ref _widthCount, value, nameof(WidthCount)); }
        }
        private int _lengthCount;
        //与产品的长对应
        public int LengthCount
        {
            get { return _lengthCount; }

            set { SetProperty(ref _lengthCount, value, nameof(LengthCount)); }
        }
    }
}
