using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    /// <summary>
    /// 纸箱排列
    /// </summary>
    public class PaperArrange : ModelBase
    {
        private string _category;
        public string Category
        {
            get { return _category; }
            set { SetProperty(ref _category, value, nameof(Category)); }

        }

        private ObjectSize _gasketSize;

        public ObjectSize GasketSize
        {
            get { return _gasketSize; }
            set { SetProperty(ref _gasketSize, value, nameof(GasketSize)); }
        }

        private ObjectArrange _gasketArrange;

        public ObjectArrange GasketArrange
        {
            get { return _gasketArrange; }
            set { SetProperty(ref _gasketArrange, value, nameof(GasketArrange)); }
        }

        private double _gasketCount;

        public double GasketCount
        {
            get
            {
                return _gasketCount;
            }
            set
            {
                SetProperty(ref _gasketCount, value, nameof(GasketCount));
            }
        }


        private ObjectSize _lengthClipSize;

        public ObjectSize LengthClipSize
        {
            get { return _lengthClipSize; }
            set { SetProperty(ref _lengthClipSize, value, nameof(LengthClipSize)); }
        }

        private ObjectArrange _lengthClipArrange;

        public ObjectArrange LengthClipArrange
        {
            get { return _lengthClipArrange; }
            set { SetProperty(ref _lengthClipArrange, value, nameof(LengthClipArrange)); }
        }

        private double _lengthClipCount;

        public double LengthClipCount
        {
            get
            {
                return _lengthClipCount;
            }
            set
            {
                SetProperty(ref _lengthClipCount, value, nameof(LengthClipCount));
            }
        }

        private ObjectSize _shortClipSize;

        public ObjectSize ShortClipSize
        {
            get { return _shortClipSize; }
            set { SetProperty(ref _shortClipSize, value, nameof(ShortClipSize)); }
        }

        private ObjectArrange _shortClipArrange;

        public ObjectArrange ShortClipArrange
        {
            get { return _shortClipArrange; }
            set { SetProperty(ref _shortClipArrange, value, nameof(ShortClipArrange)); }
        }

        private double _shortClipCount;

        public double ShortClipCount
        {
            get
            {
                return _shortClipCount;
            }
            set
            {
                SetProperty(ref _shortClipCount, value, nameof(ShortClipCount));
            }
        }
    }
}
