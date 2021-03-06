﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Assessment.Dto;
using Assessment.Models;
using Assessment.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Assessment.Web.Services
{
    [Serializable]
    public class DataClient : IDataClient
    {
        public DataClient()
        {
            Client.DefaultRequestHeaders.Add("Accept", new[] { "application/json", "text/javascript" });
        }

        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:64232/") };

        /// <summary>
        /// Creates a new <see cref="Client"/> record in the data store.
        /// </summary>
        /// <param name="client">An <see cref="HttpClient"/> used to contact the API.</param>
        public async Task CreateAsync(Client client)
        {
            var content = JsonConvert.SerializeObject(client);
            var result = await Client.PostAsync("api/Clients/Post", new StringContent(content));
            result.EnsureSuccessStatusCode();            
        }

        /// <summary>
        /// Performs a normal GET index call to the API to get all Clients.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Client}"/></returns>
        public async Task<IEnumerable<Client>> ReadAsync(ClientRequest req)
        {
            // Can only post with content.
            string jsonIn = JsonConvert.SerializeObject(new Client());
            if (req.IsForReadAll)
            {                
                var jsonOut = await Client.PostAsync("api/Clients", new StringContent(jsonIn));
                var allclients = JsonConvert.DeserializeObject<IEnumerable<Client>>(await jsonOut.Content.ReadAsStringAsync());
                return allclients; 
            }
            var json = await Client.PostAsync($"api/Clients/{req.ClientId}", new StringContent(null));
            var clientRets = JsonConvert.DeserializeObject<IEnumerable<Client>>(await json.Content.ReadAsStringAsync());
            var singleClient = new List<Client> {clientRets.Single(c => c.Id == req.ClientId)};
            return singleClient;
        }


        /// <summary>
        /// Performs a GET call to the API to fetch a single Client record.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{Client}"/> containing all client records in the database.</returns>        
        public async Task<Client> ReadAsync(int id)
        {
            var json = await Client.GetStringAsync($"Clients/Read/{id:int}");
            var client = JsonConvert.DeserializeObject<Client>(json);
            return client;
        }

        /// <summary>
        /// Performs a PUT call to the API to update a client record.
        /// </summary>
        /// <param name="client">The <see cref="Client"/> to update.</param>
        public async Task UpdateAsync(Client client)
        {
            var json = JsonConvert.SerializeObject(client);
            await Client.PutAsync("api/Clients/Update", new StringContent(json));
        }
    }
}
