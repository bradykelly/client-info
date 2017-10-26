using System.Data;
using System.Data.SqlClient;
using Assessment.Gui.ViewModels;

namespace Assessment.Gui.Services
{
    public class ClientService
    {
        public static int Create(Dto.Client client)
        {
            using (var conn = new SqlConnection())
            using (var cmdInsert = new SqlCommand("INSERT CLIENT (GivenName, FamilyName, Gender, DateOfBirth) VALUES(@givenName, @familyName, @gender, @DateOfBirth)"))
            {
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Connection = conn;
                cmdInsert.Parameters.AddWithValue("@givenName", client.GivenName);
                cmdInsert.Parameters.AddWithValue("@familyName", client.GivenName);
                cmdInsert.Parameters.AddWithValue("@Gender", client.GivenName);
                // NB Make explicit date type for sql.
                cmdInsert.Parameters.AddWithValue("@DateOfBirth", client.GivenName);
                cmdInsert.ExecuteNonQuery();

                using (var cmdIdentity = new SqlCommand("SELECT @@identity"))
                {
                    cmdIdentity.CommandType = CommandType.Text;
                    cmdIdentity.Connection = conn;
                    return (int)cmdIdentity.ExecuteScalar();
                }
            }
        }
    }
}
