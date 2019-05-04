using Dapper;
using QuantumLeap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumLeap.Data
{
    public class LeapRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";

        public Leap AddLeap(int leaperId)
        {
            using (var db = new SqlConnection(ConnectionString))
            {

                // Get a random event where the timeline is not correct
                var myEvent = db.Query<Event>(@"
                                Select top 1 e.*
                                From Event e
                                Where e.iscorrect = 0
                                Order By NEWID()");


                // Get a random leapee
                var myLeapee = db.Query<Leapee>(@"
                                Select top 1 l.*
                                From Leapee l
                                Order By NEWID()");


                // Get leaper, and check for budget
                var leapers = db.Query<Leaper>("Select * from Leaper").ToList();

                var myLeaper = leapers.FirstOrDefault(leaper => leaper.Id == leaperId);

                if (myLeaper.Budget > 10000)
                {
                    var insertQuery = @"
                            Insert into [dbo].[Leap],[LeaperId]("
                }

                return leap;
            }

        }
    }
}
