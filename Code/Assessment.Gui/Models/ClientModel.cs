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
        public static List<Gender> GenderModels { get; set; }

        public void Populate()
        {
            // NB Seeding.

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            using (var cmd = new SqlCommand("SELECT Id, Name FROM Gender", conn))
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                GenderModels.Clear();
                var gender = new Gender
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                GenderModels.Add(gender);
            }
        }
    }
}
