using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Config {
    public class PaperBoxOfBlackClipConfig : IPaperBoxConfig
    {

        public float ExtraHeight
        {
            get; set;
        }

        public float Inside
        {
            get; set;
        }

        public float InsideHeight
        {
            get; set;
        }

        public float PaperLengthDefaut
        {
            get; set;
        }

        public float PaperWidthDefaut
        {
            get; set;
        }

        public float Spacing
        {
            get; set;
        }

        public PaperBoxOfBlackClipConfig()
        {
            Spacing = 0.3F;
            Inside = 1;
            InsideHeight = 1.2F;
            ExtraHeight = 0F;
            PaperWidthDefaut = 0.5F;
            PaperLengthDefaut = 3F;
        }
    }
}
