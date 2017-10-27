using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Dto;
using Assessment.Gui.Services;
using Assessment.Gui.ViewModels;

namespace Assessment.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new ClientListViewModel();
            model.Read();
        }
    }
}
