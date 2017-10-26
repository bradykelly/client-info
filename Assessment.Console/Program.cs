using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Dto;

namespace Assessment.Console
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private IEnumerable<Client> BuildDummyData()
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
                }
            };


        }
    }
}
