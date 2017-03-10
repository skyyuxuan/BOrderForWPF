using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    public class ObjectSize : ModelBase
    {
        private double _height;
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                SetProperty(ref _height, value, nameof(Height));
            }
        }
        private double _width;
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                SetProperty(ref _width, value, nameof(Width));
            }
        }
        private double _length;
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                SetProperty(ref _length, value, nameof(Length));
            }
        }
    }
}
