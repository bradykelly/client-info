using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Assessment.Gui.Models;
using Assessment.Gui.Services;
using Assessment.Gui.ViewModels;

namespace Assessment.Gui
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            ////base.OnStartup(e);

            // Insert 4 test clients.
            ////ClientModel.Populate();
            ////ClientService.InsertDummyData();
        }
    }
}
