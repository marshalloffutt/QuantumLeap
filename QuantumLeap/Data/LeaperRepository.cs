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

        public IEnumerable<Leaper> GetAllLeapers()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var leapers = db.Query<Leaper>("Select * from Leaper").ToList();

                return leapers;
            }
        }

        public Leaper AddLeaper(string name, int age, decimal budget, DateTime homeYear)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var insertQuery = @"
                    Insert into [dbo].[Leaper]([Name],[Age],[Budget],[HomeYear])
                    Output inserted.*
                    Values(@name, @age, @budget, @homeYear)";

                var parameters = new
                {
                    Name = name,
                    Age = age,
                    Budget = budget,
                    HomeYear = homeYear
                };

                var newLeaper = db.QueryFirstOrDefault<Leaper>(insertQuery, parameters);

                if (newLeaper != null)
                {
                    return newLeaper;
                }
            }
            throw new Exception("Could not create leaper");
        }

        public Leaper UpdateBudget(Leaper leaperToUpdate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var updateQuery = @"
                    Update leaper
                    Set Budget = Budget - 10000
                    Where Id = @id";

                var rowsAffected = db.Execute(updateQuery, leaperToUpdate);

                if (rowsAffected == 1)
                {
                    return leaperToUpdate;
                }
            }
            throw new Exception("Could not update leaper's budget");
        }
    }
}
