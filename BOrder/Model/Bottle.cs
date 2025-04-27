using BOrder.Config;
using System;
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

        private double _paperPrice;
        public double PaperPrice
        {
            get { return _paperPrice; }
            set
            {
                SetProperty(ref _paperPrice, value, nameof(PaperPrice));
            }
        }

        private double _gasketPrice;
        public double GasketPrice
        {
            get { return _gasketPrice; }
            set
            {
                SetProperty(ref _gasketPrice, value, nameof(GasketPrice));
            }
        }

        private double _clipPrice;
        public double ClipPrice
        {
            get { return _clipPrice; }
            set
            {
                SetProperty(ref _clipPrice, value, nameof(ClipPrice));
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

            result.BoxSize.Length = length;
            result.BoxSize.Width = width;

            return UpdatePaperBox(result, config, boxCount);
            ////卡子数量
            //result.ClipCount = boxCount * FloorCount;
            ////垫片数量
            //result.GasketCount = (FloorCount + 1) * boxCount;
            ////垫片尺寸
            //var gasketSize = new ObjectSize();
            //gasketSize.Width = result.BoxSize.Width - 1;
            //gasketSize.Length = result.BoxSize.Length - 1;
            //result.GasketSize = gasketSize;

            ////长卡子尺寸
            //var lengthClipSize = new ObjectSize();
            //lengthClipSize.Width = ProductSize.Height;
            //lengthClipSize.Length = result.GasketSize.Length;
            //result.LengthClipSize = lengthClipSize;

            ////长卡子尺寸
            //var shortClipSize = new ObjectSize();
            //shortClipSize.Width = ProductSize.Height;
            //shortClipSize.Length = result.GasketSize.Width;
            //result.ShortClipSize = shortClipSize;
            //if (length >= width)
            //{
            //    result.LengthClipCount = result.ClipCount * (FloorSizeCount.WidthCount - 1);
            //    result.ShortClipCount = result.ClipCount * (FloorSizeCount.LengthCount - 1);
            //}
            //else
            //{
            //    result.LengthClipCount = result.ClipCount * (FloorSizeCount.LengthCount - 1);
            //    result.ShortClipCount = result.ClipCount * (FloorSizeCount.WidthCount - 1);
            //}
            //var size = new ObjectSize();
            //size.Width = result.BoxSize.Width + result.BoxSize.Height + 0.5;
            //size.Length = (result.BoxSize.Length + result.BoxSize.Width) * 2 + 3;
            //result.PaperSize = size;
            //return result;
        }

        public int GetPaperBoxCount(int total)
        {
            return (int)Math.Ceiling(((decimal)total / (this.FloorSizeCount.WidthCount * this.FloorSizeCount.LengthCount * FloorCount)));
        }

        public PaperBox UpdatePaperBox(PaperBox paperBox, IPaperBoxConfig config, int boxCount)
        {
            if (paperBox == null || paperBox.BoxSize == null)
                return paperBox;

            double length = paperBox.BoxSize.Length;
            double width = paperBox.BoxSize.Width;


            paperBox.BoxSize.Length = Math.Max(length, width);
            paperBox.BoxSize.Width = Math.Min(length, width);

            //卡子数量
            paperBox.ClipCount = boxCount * FloorCount;
            //垫片数量
            paperBox.GasketCount = FloorCount * boxCount;
            //垫片尺寸
            var gasketSize = new ObjectSize();
            gasketSize.Width = paperBox.BoxSize.Width - config.Inside;
            gasketSize.Length = paperBox.BoxSize.Length - config.Inside;
            paperBox.GasketSize = gasketSize;

            //长卡子尺寸
            var lengthClipSize = new ObjectSize();
            lengthClipSize.Width = ProductSize.Height;
            lengthClipSize.Length = paperBox.GasketSize.Length;
            paperBox.LengthClipSize = lengthClipSize;

            //长卡子尺寸
            var shortClipSize = new ObjectSize();
            shortClipSize.Width = ProductSize.Height;
            shortClipSize.Length = paperBox.GasketSize.Width;
            paperBox.ShortClipSize = shortClipSize;
            if (length >= width)
            {
                paperBox.LengthClipCount = paperBox.ClipCount * (FloorSizeCount.WidthCount - 1);
                paperBox.ShortClipCount = paperBox.ClipCount * (FloorSizeCount.LengthCount - 1);
            }
            else
            {
                paperBox.LengthClipCount = paperBox.ClipCount * (FloorSizeCount.LengthCount - 1);
                paperBox.ShortClipCount = paperBox.ClipCount * (FloorSizeCount.WidthCount - 1);
            }
            var size = new ObjectSize();
            size.Width = paperBox.BoxSize.Width + paperBox.BoxSize.Height + config.PaperWidthDefaut;
            size.Length = (paperBox.BoxSize.Length + paperBox.BoxSize.Width) * 2 + config.PaperLengthDefaut;
            paperBox.PaperSize = size;

            //计算价格

            //每箱垫片价格
            paperBox.GasketPrice = FloorCount * paperBox.GasketSize.Width * paperBox.GasketSize.Length * GasketPrice / 10000;
            //短卡子价格
            paperBox.ShortClipPrice = paperBox.ShortClipSize.Width * paperBox.ShortClipSize.Length * (paperBox.ShortClipCount / boxCount) * ClipPrice / 10000;
            //长卡子价格
            paperBox.LengthClipPrice = paperBox.LengthClipSize.Width * paperBox.LengthClipSize.Length * (paperBox.LengthClipCount / boxCount) * ClipPrice / 10000;
            //纸板价格
            paperBox.PaperPrice = paperBox.PaperSize.Width * paperBox.PaperSize.Length * PaperPrice / 10000;
            //每箱子总价
            paperBox.PaperBoxPrice = paperBox.GasketPrice + paperBox.ShortClipPrice + paperBox.LengthClipPrice + paperBox.PaperPrice;

            return paperBox;
        }
    }
}
