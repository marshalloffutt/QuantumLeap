using Dapper;
using QuantumLeap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumLeap.Data
{
    public class LeapeeRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";

        public IEnumerable<Leapee> GetAllLeapees()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var leapees = db.Query<Leapee>("Select * from Leapee").ToList();

                return leapees;
            }
        }

        public Leapee AddLeapee(string name)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var insertQuery = @"
                    Insert into [dbo].[Leapee]([Name])
                    Output inserted .*
                    Values(@name)";

                var parameters = new
                {
                    Name = name
                };

                var newLeapee = db.QueryFirstOrDefault<Leapee>(insertQuery, parameters);

                if (newLeapee != null)
                {
                    return newLeapee;
                }
            }
            throw new Exception("Could not create leapee");
        }
    }
}
