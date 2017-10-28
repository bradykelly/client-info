using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Assessment.Gui.Models;
using Assessment.Web;

namespace Assessment.Gui.Services
{
    public class ClientService
    {
        // NB Unique key for Client.
        public int Create(Client client)
        {
            using (var conn = new SqlConnection("data source=localhost;initial catalog=ClientInfo;Integrated Security=SSPI;"))
            using (var cmdInsert = new SqlCommand("INSERT CLIENT (GivenName, FamilyName, GenderCode, DateOfBirth) VALUES(@givenName, @familyName, @gender, @DateOfBirth)", conn))
            {
                conn.Open();
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Parameters.AddWithValue("@givenName", client.GivenName);
                cmdInsert.Parameters.AddWithValue("@familyName", client.FamilyName);
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

        public IEnumerable<Client> Read()
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
                    client.GenderId = Convert.ToChar(reader["GenderId"]);
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
                    Gender = ClientModel.Genders.Single(g => g.Id == (int)GendersEnum.Female),
                    FamilyName = "Smith",
                    GivenName = "Roger",
                    DateOfBirth = new DateTime(1980, 4, 16)
                },
                new Client
                {
                    Gender = ClientModel.Genders.Single(g => g.Id == (int)GendersEnum.Female),
                    FamilyName = "Smith",
                    GivenName = "Jane",
                    DateOfBirth = new DateTime(2000, 8, 6)
                },
                new Client
                {
                    Gender = ClientModel.Genders.Single(g => g.Id == (int)GendersEnum.Withheld),
                    FamilyName = "Gotham",
                    GivenName = "Logan",
                    DateOfBirth = new DateTime(2010, 3, 2)
                },
                new Client
                {
                    Gender = ClientModel.Genders.Single(g => g.Id == (int)GendersEnum.Male),
                    FamilyName = "Andrews",
                    GivenName = "Phillip",
                    DateOfBirth = new DateTime(2019, 7, 6)
                }
            };
            ret.ForEach(c => c.GenderId = c.Gender.Id);
            return ret;
        }

        public static void InsertDummyData()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("INSERT Client (GenderId, FamilyName, GivenName, DateOfBirth) VALUES (@genderId, @familyName, @givenName, @dateOfBirth)", conn))
            {
                conn.Open();

                cmd.Parameters.Add(new SqlParameter("@genderid", SqlDbType.Int));
                cmd.Parameters.Add(new SqlParameter("@familyName", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@givenName", SqlDbType.NVarChar));
                cmd.Parameters.Add(new SqlParameter("@dateOfBirth", SqlDbType.DateTime2));

                foreach (var dummy in BuildDummyData())
                {
                    cmd.Parameters["@genderid"].Value = dummy.GenderId;
                    cmd.Parameters["@familyName"].Value = dummy.FamilyName;
                    cmd.Parameters["@givenName"].Value = dummy.GivenName;
                    cmd.Parameters["@dateOfBirth"].Value = dummy.DateOfBirth;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
