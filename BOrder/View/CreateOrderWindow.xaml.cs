using BOrder.Config;
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

namespace BOrder {
    /// <summary>
    /// Interaction logic for CreateOrderWindow.xaml
    /// </summary>
    public partial class CreateOrderWindow : Window {
        private const string CATEGORY = "箱子：BE五层 卡子：E卡";
        public CreateOrderWindow() {
            InitializeComponent();
            this.Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e) {
            this.Product_Category_TB.Text = CATEGORY;
            BoxType_CB.SelectedIndex = 1;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e) {
            Regex re = new Regex("[^0-9.-]+");
            e.Handled = re.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            //if (ValidationEmpty(Order_ID_TB, "请填写订单号") && ValidationEmpty(Product_Length_TB, "请正确填写产品尺寸") && ValidationEmpty(Product_Height_TB, "请正确填写产品尺寸") && ValidationEmpty(Product_Width_TB, "请正确填写产品尺寸") && ValidationEmpty(Floor_Width_Count_TB, "请正确填写每层装法") && ValidationEmpty(Floor_Length_Count_TB, "请正确填写每层装法") && ValidationEmpty(Floor_TB, "请正确填写层数") && ValidationEmpty(Product_Total_TB, "请正确填写产品总数")
            //    && ValidationEmpty(Paper_Price_TB, "请正确填写纸板价格") && ValidationEmpty(Gasket_Price_TB, "请正确填写垫片价格") && ValidationEmpty(Clip_Price_TB, "请正确填写卡子价格"))
            //{
            if (ValidationEmpty(Order_ID_TB, "请填写订单号") && ValidationEmpty(Product_Length_TB, "请正确填写产品尺寸") && ValidationEmpty(Product_Height_TB, "请正确填写产品尺寸") && ValidationEmpty(Product_Width_TB, "请正确填写产品尺寸") && ValidationEmpty(Floor_Width_Count_TB, "请正确填写每层装法") && ValidationEmpty(Floor_Length_Count_TB, "请正确填写每层装法") && ValidationEmpty(Floor_TB, "请正确填写层数") && ValidationEmpty(Product_Total_TB, "请正确填写产品总数")) {
                bool isShowPrice = (bool)IS_Show_Calc_Price_CB.IsChecked;
                if (isShowPrice) {
                    if (!ValidationEmpty(Paper_Price_TB, "请正确填写纸板价格") || !ValidationEmpty(Gasket_Price_TB, "请正确填写垫片价格") || !ValidationEmpty(Clip_Price_TB, "请正确填写卡子价格")) {
                        return;
                    }
                }
                double height = 0;
                double length = 0;
                double width = 0;

                int lengthCount = 0;
                int widthCount = 0;
                int floorCount = 0;
                int total = 0;
                float extraHeight = 0f;

                double paperPrice = 0;
                double clipPrice = 0;
                double gasketPrice = 0;


                double.TryParse(Product_Length_TB.Text, out length);
                double.TryParse(Product_Height_TB.Text, out height);
                double.TryParse(Product_Width_TB.Text, out width);
                int.TryParse(Floor_TB.Text, out floorCount);
                int.TryParse(Floor_Width_Count_TB.Text, out widthCount);
                int.TryParse(Floor_Length_Count_TB.Text, out lengthCount);
                int.TryParse(Product_Total_TB.Text, out total);
                float.TryParse(Extra_Height_TB.Text, out extraHeight);


                double.TryParse(Paper_Price_TB.Text, out paperPrice);
                double.TryParse(Clip_Price_TB.Text, out clipPrice);
                double.TryParse(Gasket_Price_TB.Text, out gasketPrice);

                if (floorCount == 0) {
                    MessageBox.Show("请正确填写层数");
                    return;
                }
                var bottle = new Bottle() {
                    PaperPrice = paperPrice,
                    GasketPrice = gasketPrice,
                    ClipPrice = clipPrice,
                    FloorCount = floorCount,
                    ProductSize = new ObjectSize() { Height = height, Length = length, Width = width },
                    FloorSizeCount = new FloorSizeCount() { LengthCount = lengthCount, WidthCount = widthCount }
                };
                var extra = new ProductExtra() {
                    IsPrintWord = (bool)IS_Print_CB.IsChecked,
                    OrderID = Order_ID_TB.Text,
                    Remarks = Product_Remarks_TB.Text,
                    Category = CATEGORY,
                };
                IPaperBoxConfig config = null;
                if (BoxType_CB.SelectedIndex == 0) {
                    if (!(bool)IS_Black_Clip_CB.IsChecked) {
                        config = new PaperBoxOfWhiteClipConfig();
                        config.ExtraHeight = extraHeight;
                    }
                    else {
                        config = new PaperBoxOfBlackClipConfig();
                        config.ExtraHeight = extraHeight;
                    }
                }
                else {
                    config = new PaperBoxBEConfig();
                    config.ExtraHeight = extraHeight;
                }
                var order = OrderManager.Instance().CreatePaperBoxOrder(config, bottle, extra, total);
                var window = new OrderDetailWindow();
                window.PaperBoxOrder = order;
                window.IsCalcPrice = isShowPrice;
                window.Show();
            }
            //string paperBoxInfo = $"箱子数量:{order.PaperBoxCount},箱子尺寸:长{order.PaperBox.BoxSize.Length}宽{order.PaperBox.BoxSize.Width}高{order.PaperBox.BoxSize.Height},纸板尺寸:长{order.PaperBox.Size.Length}宽{order.PaperBox.Size.Width},垫片的数量:{order.PaperBox.GasketCount},垫片的尺寸:长{order.PaperBox.GasketSize.Length}宽{order.PaperBox.GasketSize.Width},卡子数量:{order.PaperBox.ClipCount},长卡子数量:{order.PaperBox.LengthClipCount},长卡子尺寸:长{order.PaperBox.LengthClipSize.Length}宽{order.PaperBox.LengthClipSize.Width},短卡子数量:{order.PaperBox.ShortClipCount},短卡子尺寸:长{order.PaperBox.ShortClipSize.Length}宽{order.PaperBox.ShortClipSize.Width}"; 

            //Box_Output_TB.Text = paperBoxInfo;
        }

        private bool ValidationEmpty(TextBox textBox, string message) {
            if (string.IsNullOrEmpty(textBox.Text)) {
                MessageBox.Show(message);
                return false;
            }
            return true;
        }
    }
}
