using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Config {
    public class PaperBoxThreeBEConfig : IPaperBoxConfig {

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

        public PaperBoxThreeBEConfig() {
            Spacing = 0.2F;
            Inside = 0.8F;
            InsideHeight = 0.6F;
            ExtraHeight = 0F;
            PaperWidthDefaut = 0F;
            PaperLengthDefaut = 3F;
        }
    }
}
