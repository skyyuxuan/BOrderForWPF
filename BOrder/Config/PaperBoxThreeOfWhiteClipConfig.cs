using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Config {
    public class PaperBoxThreeOfWhiteClipConfig : IPaperBoxConfig {
        public float ExtraHeight {
            get; set;
        }

        public float Inside {
            get; set;
        }

        public float InsideHeight {
            get; set;
        }

        public float PaperLengthDefaut {
            get; set;
        }

        public float PaperWidthDefaut {
            get; set;
        }

        public float Spacing {
            get; set;
        }

        public PaperBoxThreeOfWhiteClipConfig() {
            Spacing = 0.1F;
            Inside = 0.8F;
            InsideHeight = 0.6F;
            ExtraHeight = 0.3F;
            PaperWidthDefaut = 0F;
            PaperLengthDefaut = 3F;
        }
    }
}
