using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Dto;
using Assessment.Gui.Services;

namespace Assessment.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var clients = ClientService.Read();
            ////var clients = ClientService.BuildDummyData();
            ////foreach (var c in clients)
            ////{
            ////    ClientService.Create(c);
            ////}
        }
    }
}
