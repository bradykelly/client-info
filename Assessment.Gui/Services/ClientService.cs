using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Assessment.Dto;
using Assessment.Gui.ViewModels;

namespace Assessment.Gui.Services
{
    public class ClientService
    {
        public static int Create(Dto.Client client)
        {
            using (var conn = new SqlConnection("data source=localhost;initial catalog=ClientInfo;Integrated Security=SSPI;"))
            using (var cmdInsert = new SqlCommand("INSERT CLIENT (GivenName, FamilyName, Gender, DateOfBirth) VALUES(@givenName, @familyName, @gender, @DateOfBirth)", conn))
            {
                conn.Open();
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Parameters.AddWithValue("@givenName", client.GivenName);
                cmdInsert.Parameters.AddWithValue("@familyName", client.FamilyName);
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
                    return int.Parse(id.ToString());
                }
            }
        }

        public static IEnumerable<Dto.Client> Read()
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
                    client.Gender = Gender.FromCode((char)reader["Gender"]);
                    ////client.DateOfBirth = 
                }

                return ret;
            }
        }
    }
}
