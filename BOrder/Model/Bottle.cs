﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    public class Bottle : ModelBase, IProduct
    {
        private int _floorCount;

        public int FloorCount
        {
            get { return _floorCount; }
            set
            {
                SetProperty(ref _floorCount, value, nameof(FloorCount));
            }
        }
        private FloorSizeCount _floorSizeCount;
        public FloorSizeCount FloorSizeCount
        {
            get { return _floorSizeCount; }
            set
            {
                SetProperty(ref _floorSizeCount, value, nameof(FloorSizeCount));
            }
        }

        private ObjectSize _productSize;
        public ObjectSize ProductSize
        {
            get { return _productSize; }
            set
            {
                SetProperty(ref _productSize, value, nameof(ProductSize));
            }
        }

        public PaperBox CreatePaperBox(IPaperBoxConfig config, int boxCount)
        {
            var result = new PaperBox();
            //箱子容量
            result.ProductCount = this.FloorSizeCount.WidthCount * this.FloorSizeCount.LengthCount * FloorCount;
            result.BoxSize = new ObjectSize();
            result.BoxSize.Height = (ProductSize.Height + config.Spacing) * FloorCount + config.InsideHeight + config.ExtraHeight * (FloorCount - 1);
            double length = (ProductSize.Length + config.Spacing) * FloorSizeCount.LengthCount + config.Inside;
            double width = (ProductSize.Width + config.Spacing) * FloorSizeCount.WidthCount + config.Inside;
            //卡子数量
            result.ClipCount = boxCount * FloorCount;
            result.BoxSize.Length = Math.Max(length, width);
            result.BoxSize.Width = Math.Min(length, width);
            //垫片数量
            result.GasketCount = (FloorCount + 1) * boxCount;
            //垫片尺寸
            var gasketSize = new ObjectSize();
            gasketSize.Width = result.BoxSize.Width - 1;
            gasketSize.Length = result.BoxSize.Length - 1;
            result.GasketSize = gasketSize;

            //长卡子尺寸
            var lengthClipSize = new ObjectSize();
            lengthClipSize.Width = ProductSize.Height;
            lengthClipSize.Length = result.GasketSize.Length;
            result.LengthClipSize = lengthClipSize;

            //长卡子尺寸
            var shortClipSize = new ObjectSize();
            shortClipSize.Width = ProductSize.Height;
            shortClipSize.Length = result.GasketSize.Width;
            result.ShortClipSize = shortClipSize;
            if (length >= width)
            {
                result.LengthClipCount = result.ClipCount * (FloorSizeCount.WidthCount - 1);
                result.ShortClipCount = result.ClipCount * (FloorSizeCount.LengthCount - 1);
            }
            else
            {
                result.LengthClipCount = result.ClipCount * (FloorSizeCount.LengthCount - 1);
                result.ShortClipCount = result.ClipCount * (FloorSizeCount.WidthCount - 1);
            }
            var size = new ObjectSize();
            size.Width = result.BoxSize.Width + result.BoxSize.Height + 0.5;
            size.Length = (result.BoxSize.Length + result.BoxSize.Width) * 2 + 3;
            result.PaperSize = size;
            return result;
        }

        public int GetPaperBoxCount(int total)
        {
            return (int)Math.Ceiling(((decimal)total / (this.FloorSizeCount.WidthCount * this.FloorSizeCount.LengthCount * FloorCount)));
        }
    }
}
