using Dapper;
using QuantumLeap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumLeap.Data
{
    public class LeaperRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";

        public Leaper AddLeaper(string name, int age)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var insertQuery = @"
                    Insert Into [dbo].[Leapers]([Name],[Age]])
                    Output inserted.*
                    Values (@name, @age)";

                var parameters = new
                {
                    Name = name,
                    Age = age,
                };

                var newLeaper = db.QueryFirstOrDefault<Leaper>(insertQuery, parameters);

                if (newLeaper != null)
                {
                    return newLeaper;
                }
            }
            throw new Exception("Could not create leaper");
        }
    }
}
