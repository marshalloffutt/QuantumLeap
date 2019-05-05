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
                var eventId = db.Query<Event>(@"
                                Select top 1 e.Id
                                From Event e
                                Where e.iscorrect = 0
                                Order By NEWID()");


                // Get a random leapee
                var leapeeId = db.Query<Leapee>(@"
                                Select top 1 l.Id
                                From Leapee l
                                Order By NEWID()");


                // Get leaper, and check for budget
                var leapers = db.Query<Leaper>("Select * from Leaper").ToList();

                var myLeaper = leapers.FirstOrDefault(leaper => leaper.Id == leaperId);

                if (myLeaper.Budget >= 10000)
                {
                    var insertQuery = $@"
                            Insert into [dbo].[Leap]([LeaperId],[LeapeeId],[EventId])
                            Output inserted .*
                            Values(@leaperId, {leapeeId}, {eventId})";

                    var parameters = new
                    {
                        LeaperId = leaperId,
                        LeapeeId = leapeeId,
                        EventId = eventId
                    };

                    var newLeap = db.QueryFirstOrDefault<Leap>(insertQuery, parameters);

                    if (newLeap != null)
                    {
                        return newLeap;
                    }
                }
                else
                {
                    throw new Exception("You cannot afford to leap. You are stuck here.");
                }
            }
            throw new Exception("Could not create Leap");
        }
    }
}
