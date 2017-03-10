using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    public class ProductExtra : ModelBase
    {
        private string _orderID;
        public string OrderID
        {
            get { return _orderID; }
            set { SetProperty(ref _orderID, value, nameof(OrderID)); }

        }

        private string _remarks;
        public string Remarks
        {
            get { return _remarks; }
            set { SetProperty(ref _remarks, value, nameof(Remarks)); }

        }

        private bool _isPrintWord;
        public bool IsPrintWord
        {
            get { return _isPrintWord; }
            set { SetProperty(ref _isPrintWord, value, nameof(IsPrintWord)); }

        }
    }
}
