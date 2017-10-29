using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Assessment.Web.Models;
using Newtonsoft.Json;

namespace Assessment.Web.Services
{
    public class DataClient : IDataClient
    {
        public DataClient()
        {
            Client.DefaultRequestHeaders.Add("Accept", new []{ "application/json", "text/javascript" });
        }

        private static readonly HttpClient Client = new HttpClient {BaseAddress = new Uri("http://localhost:63675/") };
        
        /// <summary>
        /// Creates a new <see cref="Client"/> record in the data store.
        /// </summary>
        /// <param name="client">An <see cref="HttpClient"/> used to contact the API.</param>
        public async Task CreateAsync(Client client)
        {
            var content = JsonConvert.SerializeObject(client);
            var result = await Client.PostAsync("api/Clients/Create", new StringContent(content));
            result.EnsureSuccessStatusCode();
        }

        /// <summary>
        /// Performs a normal GET index call to the API.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Client}"/></returns>
        public async Task<IEnumerable<Client>> ReadAsync()
        {
            string json = null;
            try
            {
                json = await Client.GetStringAsync("api/Clients/Get");
            }
            catch (Exception ex)
            {
                var name = ex.GetType().Name;
                throw;
            }
            var clients = JsonConvert.DeserializeObject<IEnumerable<Client>>(json);
            return clients;
        }

        /// <summary>
        /// Performs a GET call to the API to fetch a single Client record.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Client}"/> containing all client records in the database.</returns>        
        public async Task<Client> ReadAsync(int id)
        {
            var json = await Client.GetStringAsync($"api/Clients/Get/{id}");
            var client = JsonConvert.DeserializeObject<Client>(json);
            return client;
        }

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
                await CreateAsync(client);
            }
        }
    }
}
