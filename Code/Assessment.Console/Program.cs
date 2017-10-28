using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Assessment.Dto;
using Nito.AsyncEx;

namespace Assessment.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncContext.Run(() => MainAsync(args));
        }

        static void MainAsync(string[] args)
        {
            var client = new HttpClient();

            
        }
    }
}
