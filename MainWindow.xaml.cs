using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace GridForm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataView dgView;

        public MainWindow()
        {
            InitializeComponent();
            DataTable dt = DataAccess.MainTable();
            label.Content = "Version " + App.Version;
            labelCount.Content = "Count: " + dt.Rows.Count;
            textBox.IsEnabled = (dt.Rows.Count > 35);
            btnFilter.IsEnabled = textBox.IsEnabled;
            //dataGrid.DataContext = dt.DefaultView;
            dgView = new DataView(dt);
            dgView.RowFilter = String.Empty;
            dataGrid.DataContext = dgView;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.SelectedIndex = -1;
            labelID.Content = "";
        }

        private void filter_Click(object sender, RoutedEventArgs e)
        {
            string fil = textBox.Text;
            if (String.IsNullOrWhiteSpace(fil))
            {
                dgView.RowFilter = String.Empty;
                labelOn.Content = "";
            }
            else
            {
                dgView.RowFilter = fil;
                labelOn.Content = "On";
            }
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedIndex >= 0)
            {
                DataRowView dr = (DataRowView)dataGrid.Items[dataGrid.SelectedIndex];
                Int16 cttID = Convert.ToInt16(dr["ctt_id"]);
                labelID.Content = "Id: " + cttID;
            }
        }

    }
}
