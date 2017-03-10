using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class PaperBox : ModelBase
    {
        private ObjectSize _boxSize;
        /// <summary>
        /// 箱子尺寸
        /// </summary> 
        public ObjectSize BoxSize
        {
            get { return _boxSize; }
            set { SetProperty(ref _boxSize, value, nameof(BoxSize)); }
        }
        private int _productCount;
        /// <summary>
        /// 放置产品数量
        /// </summary>
        public int ProductCount
        {
            get { return _productCount; }
            set { SetProperty(ref _productCount, value, nameof(ProductCount)); }
        }
        private ObjectSize _paperSize;
        /// <summary>
        /// 纸板尺寸
        /// </summary>
        public ObjectSize PaperSize
        {
            get { return _paperSize; }
            set { SetProperty(ref _paperSize, value, nameof(PaperSize)); }
        }
        private int _clipCount;
        /// <summary>
        /// 卡子数量
        /// </summary>
        public int ClipCount
        {
            get { return _clipCount; }
            set
            {
                SetProperty(ref _clipCount, value, nameof(ClipCount));
            }
        }
        private int _gasketCount;
        /// <summary>
        /// 垫片数量
        /// </summary>
        public int GasketCount
        {
            get { return _gasketCount; }
            set
            {
                SetProperty(ref _gasketCount, value, nameof(GasketCount));
            }
        }
        private ObjectSize gasketSize;
        /// <summary>
        /// 垫片尺寸
        /// </summary>
        public ObjectSize GasketSize
        {
            get { return gasketSize; }
            set
            {
                SetProperty(ref gasketSize, value, nameof(GasketSize));
            }
        }
        private ObjectSize _lengthClipSize;
        /// <summary>
        /// 长卡子尺寸
        /// </summary>
        public ObjectSize LengthClipSize
        {
            get { return _lengthClipSize; }
            set
            {
                SetProperty(ref _lengthClipSize, value, nameof(LengthClipSize));
            }
        }
        private int _lengthClipCount;
        /// <summary>
        /// 长卡子数量
        /// </summary>
        public int LengthClipCount
        {
            get { return _lengthClipCount; }
            set
            {
                SetProperty(ref _lengthClipCount, value, nameof(LengthClipCount));
            }
        }
        private ObjectSize _shortClipSize;
        /// <summary>
        /// 短卡子尺寸
        /// </summary>
        public ObjectSize ShortClipSize
        {
            get { return _shortClipSize; }
            set
            {
                SetProperty(ref _shortClipSize, value, nameof(ShortClipSize));
            }
        }
        private int _shortClipCount;
        /// <summary>
        /// 短卡子数量
        /// </summary>
        public int ShortClipCount
        {
            get { return _shortClipCount; }
            set
            {
                SetProperty(ref _shortClipCount, value, nameof(ShortClipCount));
            }
        }


    }
}
