using BOrder.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.ViewModel
{
    public class OrderDetailViewModel : ViewModelBase
    {
        private PaperBoxOrder _paperBoxOrder;
        public PaperBoxOrder PaperBoxOrder
        {
            get { return _paperBoxOrder; }
            set
            {
                _paperBoxOrder = value;
                RaisePropertyChanged(nameof(PaperBoxOrder));
            }
        } 
        private bool _isCalcPrice;
        public bool IsCalcPrice
        {
            get { return _isCalcPrice; }
            set
            {
                _isCalcPrice = value;
                RaisePropertyChanged(nameof(IsCalcPrice));
            }
        }

    }
}
