using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Assessment.Dto;
using Assessment.Gui.Services;
using Assessment.Gui.ViewModels;

namespace Assessment.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ClientService _clientService = new ClientService();

        public App()
        {
            var model = new ClientListViewModel();
            model.Read();

            var window = new MainWindow();
            window.DataContext = model;
            window.Show();
        }
    }
}
