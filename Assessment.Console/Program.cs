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
            var clients = BuildDummyData();
            foreach (var c in clients)
            {
                ClientService.Create(c);
            }
        }

        private static IEnumerable<Client> BuildDummyData()
        {
            var ret = new List<Client>
            {
                new Client
                {
                    Gender = new Gender('F', "Female"),
                    FamilyName = "Smith",
                    GivenName = "Roger",
                    DateOfBirth = new DateTime(1980, 4, 16)
                },
                new Client
                {
                    Gender = new Gender('F', "Female"),
                    FamilyName = "Smith",
                    GivenName = "Jane",
                    DateOfBirth = new DateTime(2000, 8, 6)
                },
                new Client
                {
                    Gender = new Gender('M', "Male"),
                    FamilyName = "Gotham",
                    GivenName = "Cindy",
                    DateOfBirth = new DateTime(2000, 8, 6)
                },
                new Client
                {
                    Gender = new Gender('M', "Male"),
                    FamilyName = "Andrews",
                    GivenName = "Jeanette",
                    DateOfBirth = new DateTime(2000, 8, 6)
                }
            };
            return ret;
        }
    }
}
