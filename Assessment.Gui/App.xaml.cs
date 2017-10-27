using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Assessment.Gui.Services;

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
            ////var clients = ClientService.BuildDummyData();
            ////foreach (var c in clients)
            ////{
            ////    ClientService.Create(c);
            ////}
            var clients = ClientService.Read();
        }
    }
}
