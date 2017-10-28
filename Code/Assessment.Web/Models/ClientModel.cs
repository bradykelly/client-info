using System.Collections.Generic;
using System.Data.SqlClient;
using Assessment.Dto;

namespace Assessment.Web.Models
{
    // NB Naming???
    public class ClientModel
    {
        public static List<Gender> GenderModels { get; set; }

        public void Populate()
        {
            //// NB Seeding.

            //using (var conn = new SqlConnection(Config ["DefaultConnection"].ConnectionString))
            //using (var cmd = new SqlCommand("SELECT Id, Name FROM Gender", conn))
            //{
            //    conn.Open();
            //    var reader = cmd.ExecuteReader();

            //    GenderModels.Clear();
            //    var gender = new Gender
            //    {
            //        Id = reader.GetInt32(0),
            //        Name = reader.GetString(1)
            //    };
            //    GenderModels.Add(gender);
            //}
        }
    }
}
