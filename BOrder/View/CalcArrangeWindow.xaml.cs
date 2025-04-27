using BOrder.Model;
using BOrder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace BOrder
{
    /// <summary>
    /// Interaction logic for CalcArrangeWindow.xaml
    /// </summary>
    public partial class CalcArrangeWindow : Window
    {
        public PaperBoxOrder PaperBoxOrder;
        public bool IsCalcPrice;


        private OrderDetailViewModel _viewModel;

        public CalcArrangeWindow()
        {
            InitializeComponent();
            _viewModel = new OrderDetailViewModel();
            this.DataContext = _viewModel;
        }

        private void OnCreateOrderClick(object sender, RoutedEventArgs e)
        {
            var window = new OrderDetailWindow();
            if (ValidationEmpty(Gasket_Row_TB, "垫片排列") && ValidationEmpty(Gasket_Column_TB, "垫片排列")
                && ValidationEmpty(LengthClip_Row_TB, "长卡子排列") && ValidationEmpty(LengthClip_Column_TB, "长卡子排列")
                && ValidationEmpty(ShortClip_Row_TB, "短卡子排列") && ValidationEmpty(ShortClip_Column_TB, "短卡子排列"))
            {

                IArrange arrange = null;
                string category = "";
                if (this.ArrangeType_CB.SelectedIndex == 0)
                {
                    arrange = new SmallArrange();
                    category = "小刀板";
                }
                else
                {
                    arrange = new LargeArrange();
                    category = "大刀板";
                }
                ObjectArrange gasketArrange = new ObjectArrange()
                {
                    Row = double.Parse(Gasket_Row_TB.Text),
                    Column = double.Parse(Gasket_Column_TB.Text)
                };
                ObjectArrange lengthClipArrange = new ObjectArrange()
                {
                    Row = double.Parse(LengthClip_Row_TB.Text),
                    Column = double.Parse(LengthClip_Column_TB.Text)
                };
                ObjectArrange shortClipArrange = new ObjectArrange()
                {
                    Row = double.Parse(ShortClip_Row_TB.Text),
                    Column = double.Parse(ShortClip_Column_TB.Text)
                };
                PaperArrange paperArrange = arrange.CreatePaperArrange(PaperBoxOrder.PaperBox, gasketArrange, lengthClipArrange, shortClipArrange);
                paperArrange.GasketArrange = gasketArrange;
                paperArrange.LengthClipArrange = lengthClipArrange;
                paperArrange.ShortClipArrange = shortClipArrange; 
                paperArrange.Category = category;
                PaperBoxOrder.PaperArrange = paperArrange;
                window.PaperBoxOrder = PaperBoxOrder;
                window.IsCalcPrice = _viewModel.IsCalcPrice;
                window.Show();
                this.Close();
            }
        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0-9.-]+");
            e.Handled = re.IsMatch(e.Text);
        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel.PaperBoxOrder = PaperBoxOrder;
            _viewModel.IsCalcPrice = IsCalcPrice;
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

        private void ArrangeType_CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.ArrangeType_CB != null && this.LengthClip_Row_TB != null)
            {
                if (this.ArrangeType_CB.SelectedIndex == 1)
                {
                    this.LengthClip_Row_TB.IsEnabled = false;
                    this.LengthClip_Row_TB.Text = "1";
                }
                else
                {
                    this.LengthClip_Row_TB.IsEnabled = true;
                }
            }

        }
    }
}
