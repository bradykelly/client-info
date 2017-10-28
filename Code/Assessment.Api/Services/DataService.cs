using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Assessment.Web;
using Microsoft.Extensions.Configuration;

namespace Assessment.Api.Services
{
    public class DataService : IDataService
    {
        public DataService(IConfiguration config)
        {
            _config = config;
            _connString = config.GetConnectionString("DefaultConnection");
        }

        private readonly string _connString;
        private IConfiguration _config;

        public int Create(Client client)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmdInsert = new SqlCommand("INSERT CLIENT (GivenName, FamilyName, GenderId, DateOfBirth) VALUES(@givenName, @familyName, @gender, @DateOfBirth)", conn))
            {
                conn.Open();
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Parameters.AddWithValue("@givenName", client.GivenName);
                cmdInsert.Parameters.AddWithValue("@familyName", client.FamilyName);
                cmdInsert.Parameters.AddWithValue("@Gender", client.Gender.Id);
                cmdInsert.Parameters.AddWithValue("@DateOfBirth", client.DateOfBirth);
                cmdInsert.ExecuteNonQuery();

                using (var cmdIdentity = new SqlCommand("SELECT @@identity"))
                {
                    cmdIdentity.CommandType = CommandType.Text;
                    cmdIdentity.Connection = conn;
                    var id = cmdIdentity.ExecuteScalar();
                    // Can't directly cast to int.               
                    return Convert.ToInt32(id);
                }
            }
        }

        public IEnumerable<Client> Read()
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmdRead = new SqlCommand("SELECT * FROM Client", conn))
            {
                conn.Open();
                var ret = new List<Client>();

                var reader = cmdRead.ExecuteReader();
                while (reader.Read())
                {
                    var client = BuildFromDataReader(reader);
                    ret.Add(client);
                }

                return ret;
            }
        }

        public async Task<IEnumerable<Client>> ReadAsync()
        {
            using (var conn = new SqlConnection(_connString)) 
            using (var cmdRead = new SqlCommand("SELECT * FROM Client", conn))
            {
                conn.Open();
                var ret = new List<Client>();

                var reader = await cmdRead.ExecuteReaderAsync();
                while (reader.Read())
                {
                    var client = BuildFromDataReader(reader);
                    ret.Add(client);
                }

                return ret;
            }
        }

        public async Task<Client> ReadAsync(int id)
        {
            using (var conn = new SqlConnection(_connString))
            using (var cmdRead = new SqlCommand("SELECT * FROM Client WHERE Id = @id", conn))
            {
                conn.Open();
                cmdRead.Parameters.AddWithValue("@id", id);
                var reader = await cmdRead.ExecuteReaderAsync();

                if (reader.Read())
                {
                    var client = BuildFromDataReader(reader);
                    return client;
                }

                return null;
            }
        }

        private Client BuildFromDataReader(SqlDataReader reader)
        {
            var client = new Client();
            client.Id = (int)reader["Id"];
            // NB Uncomment and correct gender.
            ////client.Gender = Gender.FromCode(reader.GetChar(3));
            client.DateOfBirth = (DateTime)reader["DateOfBirth"];
            client.FamilyName = reader["FamilyName"].ToString();
            client.GenderId = Convert.ToChar(reader["GenderId"]);
            client.GivenName = reader["GivenName"].ToString();
            return client;
        }
    }
}
