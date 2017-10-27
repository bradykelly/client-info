using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Assessment.Gui.Services;

namespace Assessment.Gui.Views
{
    /// <summary>
    /// Interaction logic for ClientListAlt.xaml
    /// </summary>
    public partial class ClientListAlt : UserControl
    {
        private ClientService _clients;

        public ClientListAlt()
        {
            InitializeComponent();
        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            ClientDataGrid.DataContext = ClientService.Read();
        }
    }
}
