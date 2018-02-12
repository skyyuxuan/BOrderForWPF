using BOrder.Config;
using BOrder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOrder
{
    internal class OrderManager
    {
        private static OrderManager instance;

        private static object _lock = new object();

        public static OrderManager Instance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    instance = new OrderManager();
                }
            }
            return instance;
        }
        /// <summary>
        /// 创建白卡子订单
        /// </summary>
        /// <param name="product">商品</param>
        /// <param name="total">商品数量</param>
        /// <returns></returns>
        public PaperBoxOrder CreatePaperBoxOfWhiteClipOrder(IProduct product, ProductExtra extra, int total)
        {
            return CreatePaperBoxOrder(new PaperBoxOfWhiteClipConfig(), product, extra, total);
        }
        /// <summary>
        /// 创建黑卡子订单
        /// </summary>
        /// <param name="product">商品</param>
        /// <param name="total">商品数量</param>
        /// <returns></returns>
        public PaperBoxOrder CreatePaperBoxOfBlackClipOrder(IProduct product, ProductExtra extra, int total)
        {
            return CreatePaperBoxOrder(new PaperBoxOfBlackClipConfig(), product, extra, total);
        }
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="config">箱子配置</param>
        /// <param name="product">商品</param>
        /// <param name="total">商品数量</param>
        /// <returns></returns>
        public PaperBoxOrder CreatePaperBoxOrder(IPaperBoxConfig config, IProduct product, ProductExtra extra, int total)
        {
            var order = new PaperBoxOrder();
            order.ProductTotalCount = total;
            order.Product = product;
            order.PaperBoxCount = product.GetPaperBoxCount(total);
            order.PaperBox = product.CreatePaperBox(config, order.PaperBoxCount);
            order.ID = extra.OrderID;
            order.IsPrintWord = extra.IsPrintWord;
            order.Remarks = extra.Remarks;
            order.Category = extra.Category;
            return order;
        }
    }
}
