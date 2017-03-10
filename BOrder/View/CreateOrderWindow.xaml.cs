using BOrder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BOrder
{
    /// <summary>
    /// Interaction logic for CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window
    {
        public CreateOrderWindow()
        {
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");
            e.Handled = re.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationEmpty(Order_ID_TB, "请填写订单号") && ValidationEmpty(Product_Length_TB, "请正确填写产品尺寸") && ValidationEmpty(Product_Height_TB, "请正确填写产品尺寸") && ValidationEmpty(Product_Width_TB, "请正确填写产品尺寸") && ValidationEmpty(Floor_Width_Count_TB, "请正确填写每层装法") && ValidationEmpty(Floor_Length_Count_TB, "请正确填写每层装法") && ValidationEmpty(Floor_TB, "请正确填写层数") && ValidationEmpty(Product_Total_TB, "请正确填写产品总数"))
            {
                double height = 0;
                double length = 0;
                double width = 0;
                int lengthCount = 0;
                int widthCount = 0;
                int floorCount = 0;
                int total = 0;

                double.TryParse(Product_Length_TB.Text, out length);
                double.TryParse(Product_Height_TB.Text, out height);
                double.TryParse(Product_Width_TB.Text, out width);
                int.TryParse(Floor_TB.Text, out floorCount);
                int.TryParse(Floor_Width_Count_TB.Text, out widthCount);
                int.TryParse(Floor_Length_Count_TB.Text, out lengthCount);
                int.TryParse(Product_Total_TB.Text, out total);

                var bottle = new Bottle()
                {
                    FloorCount = floorCount,
                    ProductSize = new ObjectSize() { Height = height, Length = length, Width = width },
                    FloorSizeCount = new FloorSizeCount() { LengthCount = lengthCount, WidthCount = widthCount }
                };
                var extra = new ProductExtra()
                {
                    IsPrintWord = (bool)IS_Print_CB.IsChecked,
                    OrderID = Order_ID_TB.Text,
                    Remarks = Product_Remarks_TB.Text
                };

                var order = OrderManager.Instance().CreatePaperBoxOfWhiteClipOrder(bottle, extra, total);
                var window = new OrderDetailWindow();
                window.PaperBoxOrder = order;
                window.Show();
            }
            //string paperBoxInfo = $"箱子数量:{order.PaperBoxCount},箱子尺寸:长{order.PaperBox.BoxSize.Length}宽{order.PaperBox.BoxSize.Width}高{order.PaperBox.BoxSize.Height},纸板尺寸:长{order.PaperBox.Size.Length}宽{order.PaperBox.Size.Width},垫片的数量:{order.PaperBox.GasketCount},垫片的尺寸:长{order.PaperBox.GasketSize.Length}宽{order.PaperBox.GasketSize.Width},卡子数量:{order.PaperBox.ClipCount},长卡子数量:{order.PaperBox.LengthClipCount},长卡子尺寸:长{order.PaperBox.LengthClipSize.Length}宽{order.PaperBox.LengthClipSize.Width},短卡子数量:{order.PaperBox.ShortClipCount},短卡子尺寸:长{order.PaperBox.ShortClipSize.Length}宽{order.PaperBox.ShortClipSize.Width}"; 

            //Box_Output_TB.Text = paperBoxInfo;
        }

        private bool ValidationEmpty(TextBox textBox, string message)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show(message);
                return false;
            }
            return true;


        }
    }
}
