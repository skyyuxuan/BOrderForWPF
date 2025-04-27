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

    public class LargeArrange : IArrange
    {
        public PaperArrange CreatePaperArrange(PaperBox paperBox, ObjectArrange gasketArrange, ObjectArrange lengthClipArrange, ObjectArrange shortClipArrange)
        {
            var arrange = new PaperArrange();
            var gasket = Calc(gasketArrange, paperBox.GasketSize, paperBox.GasketCount);
            arrange.GasketSize = gasket.Size;
            arrange.GasketCount = gasket.Count;

            var lengthClip = Calc(lengthClipArrange, new ObjectSize()
            {
                Length = paperBox.LengthClipSize.Length + paperBox.ShortClipSize.Length + 1.2d,
                Width = paperBox.LengthClipSize.Width,
            }, paperBox.LengthClipCount);
            arrange.LengthClipSize = new ObjectSize() { Length = lengthClip.Size.Length, Width = lengthClip.Size.Width + 1.2d };
            arrange.LengthClipCount = lengthClip.Count;


            var shortClip = Calc(shortClipArrange, new ObjectSize()
            {
                Length = paperBox.ShortClipSize.Length + 1.2d,
                Width = paperBox.ShortClipSize.Width,
            }, paperBox.ShortClipCount - paperBox.LengthClipCount);
            arrange.ShortClipSize = new ObjectSize() { Length = shortClip.Size.Length, Width = shortClip.Size.Width + 1.2d };
            arrange.ShortClipCount = shortClip.Count;

            return arrange;

        }
        private (ObjectSize Size, int Count) Calc(ObjectArrange arrange, ObjectSize objectSize, int totalCount)
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
    }

    public class SmallArrange : IArrange
    {
        public PaperArrange CreatePaperArrange(PaperBox paperBox, ObjectArrange gasketArrange, ObjectArrange lengthClipArrange, ObjectArrange shortClipArrange)
        {
            var arrange = new PaperArrange();
            var gasket = Calc(gasketArrange, paperBox.GasketSize, paperBox.GasketCount);
            arrange.GasketSize = gasket.Size;
            arrange.GasketCount = gasket.Count;

            var lengthClip = Calc(lengthClipArrange, new ObjectSize()
            {
                Length = paperBox.LengthClipSize.Length + 1.2d,
                Width = paperBox.LengthClipSize.Width,
            }, paperBox.LengthClipCount);
            arrange.LengthClipSize = new ObjectSize() { Length = lengthClip.Size.Length, Width = lengthClip.Size.Width + 1.2d };
            arrange.LengthClipCount = lengthClip.Count;


            var shortClip = Calc(shortClipArrange, new ObjectSize()
            {
                Length = paperBox.ShortClipSize.Length + 1.2d,
                Width = paperBox.ShortClipSize.Width,
            }, paperBox.ShortClipCount);
            arrange.ShortClipSize = new ObjectSize() { Length = shortClip.Size.Length, Width = shortClip.Size.Width + 1.2d };
            arrange.ShortClipCount = shortClip.Count;
            return arrange;

        }
        private (ObjectSize Size, int Count) Calc(ObjectArrange arrange, ObjectSize objectSize, int totalCount)
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

    }
}
