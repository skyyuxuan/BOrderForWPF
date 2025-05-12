using BOrder.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    public interface IArrange
    {
        PaperArrange CreatePaperArrange(PaperBox paperBox, ObjectArrange gasketArrange, ObjectArrange lengthClipArrange, ObjectArrange shortClipArrange);
    }

    public class LargeArrange : ArrangeBase, IArrange
    {
        private const double LengthExtra = 1d;
        private const double WidthExtra = 1.2d;
        public PaperArrange CreatePaperArrange(PaperBox paperBox, ObjectArrange gasketArrange, ObjectArrange lengthClipArrange, ObjectArrange shortClipArrange)
        {
            var arrange = new PaperArrange();
            var gasket = Calc(gasketArrange, paperBox.GasketSize, paperBox.GasketCount);
            arrange.GasketSize = gasket.Size;
            arrange.GasketCount = gasket.Count;
            arrange.GasketArea = CalcArea(arrange.GasketSize, arrange.GasketCount);

            if (paperBox.LengthClipCount <= paperBox.ShortClipCount)
            { 
                var lengthClip = Calc(lengthClipArrange, new ObjectSize()
                {
                    Length = paperBox.LengthClipSize.Length + paperBox.ShortClipSize.Length + LengthExtra,
                    Width = paperBox.LengthClipSize.Width,
                }, paperBox.LengthClipCount);
                arrange.LengthClipSize = new ObjectSize()
                {
                    Length = lengthClip.Size.Length,
                    Width = lengthClip.Size.Width + WidthExtra
                };
                arrange.LengthClipCount = lengthClip.Count;
                arrange.LengthClipArea = CalcArea(arrange.LengthClipSize, arrange.LengthClipCount);


                var shortClip = Calc(shortClipArrange, new ObjectSize()
                {
                    Length = paperBox.ShortClipSize.Length,
                    Width = paperBox.ShortClipSize.Width,
                }, paperBox.ShortClipCount - paperBox.LengthClipCount);
                arrange.ShortClipSize = new ObjectSize()
                {
                    Length = shortClip.Size.Length + LengthExtra,
                    Width = shortClip.Size.Width + WidthExtra
                };
                arrange.ShortClipCount = shortClip.Count;
                arrange.ShortClipArea = CalcArea(arrange.ShortClipSize, arrange.ShortClipCount);
            }
            else
            {

                var lengthClip = Calc(lengthClipArrange, new ObjectSize()
                {
                    Length = paperBox.LengthClipSize.Length,
                    Width = paperBox.LengthClipSize.Width,
                }, paperBox.LengthClipCount - paperBox.ShortClipCount);
                arrange.LengthClipSize = new ObjectSize()
                {
                    Length = lengthClip.Size.Length + LengthExtra,
                    Width = lengthClip.Size.Width + WidthExtra
                };
                arrange.LengthClipCount = lengthClip.Count;
                arrange.LengthClipArea = CalcArea(arrange.LengthClipSize, arrange.LengthClipCount);

                var shortClip = Calc(shortClipArrange, new ObjectSize()
                {
                    Length = paperBox.LengthClipSize.Length + paperBox.ShortClipSize.Length + LengthExtra,
                    Width = paperBox.ShortClipSize.Width,
                }, paperBox.ShortClipCount);
                arrange.ShortClipSize = new ObjectSize()
                {
                    Length = shortClip.Size.Length,
                    Width = shortClip.Size.Width + WidthExtra
                };
                arrange.ShortClipCount = shortClip.Count;
                arrange.ShortClipArea = CalcArea(arrange.ShortClipSize, arrange.ShortClipCount); 

             
            }
            return arrange;

        }

    }
    public class ArrangeBase
    {
        protected (ObjectSize Size, int Count) Calc(ObjectArrange arrange, ObjectSize objectSize, int totalCount)
        {
            double length = objectSize.Length * arrange.Row;
            double width = objectSize.Width * arrange.Column;
            int count = (int)Math.Ceiling((double)totalCount / (arrange.Row * arrange.Column));

            return (new ObjectSize()
            {
                Length = Math.Max(length, width),
                Width = Math.Min(length, width)
            }, count);
        }

        protected double CalcArea(ObjectSize objectSize, double totalCount)
        {
            return Math.Ceiling(objectSize.Length * objectSize.Width * totalCount / 10000.0 * 10) / 10.0;
        }
    }
    public class SmallArrange : ArrangeBase, IArrange
    {
        private const double LengthExtra = 1d;
        private const double WidthExtra = 1.2d;
        public PaperArrange CreatePaperArrange(PaperBox paperBox, ObjectArrange gasketArrange, ObjectArrange lengthClipArrange, ObjectArrange shortClipArrange)
        {
            var arrange = new PaperArrange();
            var gasket = Calc(gasketArrange, paperBox.GasketSize, paperBox.GasketCount);
            arrange.GasketSize = gasket.Size;
            arrange.GasketCount = gasket.Count;
            arrange.GasketArea = CalcArea(arrange.GasketSize, arrange.GasketCount);

            var lengthClip = Calc(lengthClipArrange, new ObjectSize()
            {
                Length = paperBox.LengthClipSize.Length + LengthExtra,
                Width = paperBox.LengthClipSize.Width,
            }, paperBox.LengthClipCount);
            arrange.LengthClipSize = new ObjectSize()
            {
                Length = lengthClip.Size.Length,
                Width = lengthClip.Size.Width + WidthExtra
            };
            arrange.LengthClipCount = lengthClip.Count;
            arrange.LengthClipArea = CalcArea(arrange.LengthClipSize, arrange.LengthClipCount);

            var shortClip = Calc(shortClipArrange, new ObjectSize()
            {
                Length = paperBox.ShortClipSize.Length + LengthExtra,
                Width = paperBox.ShortClipSize.Width,
            }, paperBox.ShortClipCount);
            arrange.ShortClipSize = new ObjectSize()
            {
                Length = shortClip.Size.Length,
                Width = shortClip.Size.Width + WidthExtra
            };
            arrange.ShortClipCount = shortClip.Count;
            arrange.ShortClipArea = CalcArea(arrange.ShortClipSize, arrange.ShortClipCount);

            return arrange;

        }
    }
}
