using System.Collections.Generic;
using System.Data.SqlClient;
using Assessment.Web.Dto;
using Microsoft.Extensions.Configuration;
using Assessment.Dto;

namespace Assessment.Web.Models
{
    public class ClientManager
    {
        public ClientManager(IConfiguration configuration)
        {
            _config = configuration;
        }

        private readonly IConfiguration _config;

        public static List<Gender> GenderModels { get; set; } = new List<Gender>();

        public void PopulateCore()
        {
            // NB Seeding.
            PopulateGenders();
        }

        public void PopulateGenders()
        {
            using (var conn = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
            using (var cmd = new SqlCommand("SELECT Id, Name FROM Gender", conn))
            {
                conn.Open();
                var reader = cmd.ExecuteReader();

                GenderModels.Clear();
                while (reader.Read())
                {
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
}
