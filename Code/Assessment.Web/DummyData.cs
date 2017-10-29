using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assessment.Web.Models;

namespace Assessment.Web
{
    public class DummyData
    {
        // TODO Remove.
        public IEnumerable<Client> BuildDummyData()
        {
            var ret = new List<Client>
            {

                new Client
                {
                    Gender =  ClientManager.GenderModels.Single(g => g.Id == (int)Genders.Male),
                    FamilyName = "Smith",
                    GivenName = "Roger",
                    DateOfBirth = new DateTime(1980, 4, 16)
                },
                new Client
                {
                    Gender = ClientManager.GenderModels.Single(g => g.Id == (int)Genders.Female),
                    FamilyName = "Smith",
                    GivenName = "Jane",
                    DateOfBirth = new DateTime(2000, 8, 6)
                },
                new Client
                {
                    Gender = ClientManager.GenderModels.Single(g => g.Id == (int)Genders.Withheld),
                    FamilyName = "Gotham",
                    GivenName = "Cindy",
                    DateOfBirth = new DateTime(2010, 3, 2)
                },
                new Client
                {
                    Gender = ClientManager.GenderModels.Single(g => g.Id == (int)Genders.Female),
                    FamilyName = "Andrews",
                    GivenName = "Jeanette",
                    DateOfBirth = new DateTime(2019, 7, 6)
                }
            };
            return ret;
        }

        public async Task InsertDummyClients()
        {
            var clients = BuildDummyData();
            foreach (var client in clients)
            {
                await Create(client);
            }
        }
    }
}
