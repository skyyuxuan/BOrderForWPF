using BOrder.Model;
using BOrder.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderDetailWindow : Window
    {
        public PaperBoxOrder PaperBoxOrder;
        public bool IsCalcPrice;


        private OrderDetailViewModel _viewModel;

        public OrderDetailWindow()
        {
            InitializeComponent();
            _viewModel = new OrderDetailViewModel();
            this.DataContext = _viewModel;
        }

        private void OnPrintClick(object sender, RoutedEventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            dialog.PageRangeSelection = PageRangeSelection.AllPages;
            dialog.UserPageRangeEnabled = true;
            var printTicket = dialog.PrintTicket;
            printTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.Roll04Inch);
            printTicket.PageOrientation = PageOrientation.Portrait;//默认竖向打印 
            LayoutRoot.Measure(new Size(dialog.PrintableAreaWidth, dialog.PrintableAreaHeight));
            LayoutRoot.Arrange(new Rect(new Point(12, 0),
                    MainGrid.DesiredSize));
            if (dialog.ShowDialog() == true)
            {
                dialog.PrintVisual(LayoutRoot, "Print Test");
            }
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            _viewModel.PaperBoxOrder = PaperBoxOrder;
            _viewModel.IsCalcPrice = IsCalcPrice;
        }
    }
}
