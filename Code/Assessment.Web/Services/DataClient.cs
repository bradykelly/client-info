using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Assessment.Dto;
using Assessment.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        
        public async Task CreateAsync(Client client)
        {
            var content = JsonConvert.SerializeObject(client);
            var result = await Client.PostAsync("api/Clients/Create", new StringContent(content));
            result.EnsureSuccessStatusCode();
        }

        public async Task<IEnumerable<Client>> ReadAsync()
        {
            var json = await Client.GetStringAsync("api/Clients/Get");
            var clients = JsonConvert.DeserializeObject<IEnumerable<Client>>(json);
            return clients;
        }

        private Client BuildFromDataReader(SqlDataReader reader)
        {
            var client = new Client();
            client.Id = (int)reader["Id"];
            client.Gender = ClientModel.GenderModels.SingleOrDefault(g => g.Id == client.Id);
            client.DateOfBirth = (DateTime)reader["DateOfBirth"];
            client.FamilyName = reader["FamilyName"].ToString();
            client.GenderId = Convert.ToChar(reader["GenderId"]);
            client.GivenName = reader["GivenName"].ToString();
            return client;
        }

        // TODO Remove.
        public IEnumerable<Client> BuildDummyData()
        {
            var ret = new List<Client>
            {

                new Client
                {
                    Gender =  ClientModel.GenderModels.Single(g => g.Id == (int)Genders.Male),
                    FamilyName = "Smith",
                    GivenName = "Roger",
                    DateOfBirth = new DateTime(1980, 4, 16)
                },
                new Client
                {
                    Gender = ClientModel.GenderModels.Single(g => g.Id == (int)Genders.Female),
                    FamilyName = "Smith",
                    GivenName = "Jane",
                    DateOfBirth = new DateTime(2000, 8, 6)
                },
                new Client
                {
                    Gender = ClientModel.GenderModels.Single(g => g.Id == (int)Genders.Withheld),
                    FamilyName = "Gotham",
                    GivenName = "Cindy",
                    DateOfBirth = new DateTime(2010, 3, 2)
                },
                new Client
                {
                    Gender = ClientModel.GenderModels.Single(g => g.Id == (int)Genders.Female),
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
