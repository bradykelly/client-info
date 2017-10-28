﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessment.Dto.Base;

namespace Assessment.Dto
{
    public class Client: BaseEntity
    {
        public string GivenName { get; set; }

        public string FamilyName { get; set; }

        public Gender Gender { get; set; }

        public int GenderId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Address> Addresses { get; } = new List<Address>();

        public List<Contact> Contacts { get; } = new List<Contact>();

        public void ReadDataReader(SqlDataReader reader)
        {
            GivenName = reader["GivenName"].ToString();
            FamilyName = reader["FamilyName"].ToString();
            GenderId = (int)reader["GenderId"];
            DateOfBirth = (DateTime)reader["DateOfBirth"];
        }
    }
}