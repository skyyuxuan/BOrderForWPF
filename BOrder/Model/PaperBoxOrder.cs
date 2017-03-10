using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    public class PaperBoxOrder : ModelBase
    {

        private string _id;

        public string ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value, nameof(ID)); }
        }

        private bool _isPrintWord;
        public bool IsPrintWord
        {
            get { return _isPrintWord; }
            set { SetProperty(ref _isPrintWord, value, nameof(IsPrintWord)); }

        }

        private string _remarks;
        public string Remarks
        {
            get { return _remarks; }
            set { SetProperty(ref _remarks, value, nameof(Remarks)); }

        }


        private PaperBox _paperBox;

        public PaperBox PaperBox
        {
            get { return _paperBox; }
            set { SetProperty(ref _paperBox, value, nameof(PaperBox)); }
        }

        private IProduct _product;

        public IProduct Product
        {
            get { return _product; }
            set { SetProperty(ref _product, value, nameof(Product)); }
        }

        private int _paperBoxCount;
        public int PaperBoxCount
        {
            get { return _paperBoxCount; }
            set { SetProperty(ref _paperBoxCount, value, nameof(PaperBoxCount)); }
        }

    }
}
