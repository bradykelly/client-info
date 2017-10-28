using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Dto;

namespace Assessment.Gui.Models
{
    // NB Naming???
    public class ClientModel
    {
        private static readonly object LockObject = new object();

        public static List<Gender> Genders { get; } = new List<Gender>();

        public static void Populate()
        {
            // NB Seeding.

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT Id, Name FROM Gender", conn))
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                lock (LockObject)
                {
                    Genders.Clear();
                    while (reader.Read())
                    {
                        var gender = new Gender
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                        Genders.Add(gender);
                    } 
                }
            }
        }
    }
}
