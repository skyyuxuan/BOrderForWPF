using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder.Model
{
    public interface IPaperBoxConfig
    {
        /// <summary>
        /// 产品间距
        /// </summary>
        float Spacing { set; get; }
        /// <summary>
        /// 箱子内径
        /// </summary>
        float Inside { set; get; }
        /// <summary>
        /// 箱子高内径
        /// </summary>
        float InsideHeight { set; get; }
        /// <summary>
        /// 箱子额外高
        /// </summary>
        float ExtraHeight { set; get; }
        /// <summary>
        /// 纸张默认添加值
        /// </summary>
        float PaperWidthDefaut { set; get; }
        /// <summary>
        /// 纸张默认添加值
        /// </summary>
        float PaperLengthDefaut { set; get; } 
       
    }
}
