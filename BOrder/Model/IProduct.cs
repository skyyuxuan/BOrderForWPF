using BOrder.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    public interface IProduct
    {
        ObjectSize ProductSize { get; set; }
        FloorSizeCount FloorSizeCount { get; set; }
        int FloorCount { get; set; }
        PaperBox CreatePaperBox(IPaperBoxConfig config, int boxCount);
        PaperBox UpdatePaperBox(PaperBox paperBox, IPaperBoxConfig config, int boxCount);
        int GetPaperBoxCount(int total);
    }
}
