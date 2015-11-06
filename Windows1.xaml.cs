using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Input;
using System.Windows.Media;

namespace AccGrid
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window // RibbonWindow
    {
        public Window1()
        {
			Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("zh-CN");

            InitializeComponent();		
			setDataContext1();
        }
		
		private void dg1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
			var dg = sender as DataGrid;
			if (dg == null)
				return;
			if (dg.CurrentColumn == dg.Columns[0]) {
			    var gridCheckBox = (dg.CurrentColumn.GetCellContent(dg.SelectedItem) as CheckBox);
				if (gridCheckBox != null)
					gridCheckBox.IsChecked = !gridCheckBox.IsChecked;
			}
        }
		
		private void btnUpdateClick(object sender, RoutedEventArgs e)
		{
			DataTable dt = dg1.DataContext as DataTable;
			dt.AcceptChanges();			
			try
			{
				AppDS.UpdateData(dt);
				setDataContext1();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		private void btnRefreshClick(object sender, RoutedEventArgs e)
		{
			setDataContext1();
		}

		private void OnClickSet(object sender, RoutedEventArgs e)
		{
			try 
			{
				AppDS.InsertData(Date1.SelectedDate, Categ.Text, Desc.Text);
				setDataContext1();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void setDataContext1()
		{
			try 
			{
				dg1.DataContext = AppDS.GetDataTable1();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		
		private void RibbonLoaded(object sender, RoutedEventArgs e)
		{
			Grid child = VisualTreeHelper.GetChild((DependencyObject)sender, 0) as Grid;
			if (child != null)
			{
				child.RowDefinitions[0].Height = new GridLength(0);
			}
		}
    }
}
