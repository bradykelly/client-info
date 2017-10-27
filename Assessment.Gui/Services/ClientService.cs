using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Assessment.Dto;
using Assessment.Gui.ViewModels;

namespace Assessment.Gui.Services
{
    public class ClientService
    {
        // NB Unique key for Client.
        public static int Create(Dto.Client client)
        {
            using (var conn = new SqlConnection("data source=localhost;initial catalog=ClientInfo;Integrated Security=SSPI;"))
            using (var cmdInsert = new SqlCommand("INSERT CLIENT (GivenName, FamilyName, GenderCode, DateOfBirth) VALUES(@givenName, @familyName, @gender, @DateOfBirth)", conn))
            {
                conn.Open();
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Parameters.AddWithValue("@givenName", client.GivenName);
                cmdInsert.Parameters.AddWithValue("@familyName", client.FamilyName);
                // NB Not pulling through.
                cmdInsert.Parameters.AddWithValue("@Gender", client.Gender.Code);
                // NB Make explicit date type for sql.
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

        public static IEnumerable<Client> Read()
        {
            using (var conn = new SqlConnection("data source=localhost;initial catalog=ClientInfo;Integrated Security=SSPI;"))
            using (var cmdRead = new SqlCommand("SELECT * FROM Client", conn))
            {
                conn.Open();
                cmdRead.CommandType = CommandType.Text;
                var ret = new List<Client>();

                var reader = cmdRead.ExecuteReader();
                while (reader.Read())
                {
                    var client = new Client();
                    // NB Uncomment and correct gender.
                    ////client.Gender = Gender.FromCode(reader.GetChar(3));
                    client.DateOfBirth = (DateTime)reader["DateOfBirth"];
                    client.FamilyName = reader["FamilyName"].ToString();
                    client.GenderCode = Convert.ToChar(reader["GenderCode"]);
                    client.GivenName = reader["GivenName"].ToString();
                    ret.Add(client);
                }

                return ret;
            }
        }

        // TODO Remove.
        public static IEnumerable<Client> BuildDummyData()
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
                    DateOfBirth = new DateTime(2010, 3, 2)
                },
                new Client
                {
                    Gender = new Gender('M', "Male"),
                    FamilyName = "Andrews",
                    GivenName = "Jeanette",
                    DateOfBirth = new DateTime(2019, 7, 6)
                }
            };
            return ret;
        }
    }
}
