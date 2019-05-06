using Dapper;
using QuantumLeap.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace QuantumLeap.Data
{
    public class EventRepository
    {
        const string ConnectionString = "Server=localhost;Database=QuantumLeap;Trusted_Connection=True;";

        public IEnumerable<Event> GetAllEvents()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var events = db.Query<Event>("Select * from Event").ToList();

                return events;
            }
        }

        public Event AddEvent(string description, string location, DateTime year, bool isCorrect)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var insertQuery = @"
                    Insert into [dbo].[Event]([Description],[Location],[Year],[IsCorrect])
                    Output inserted .*
                    Values(@description, @location, @year, @isCorrect)";

                var parameters = new
                {
                    Description = description,
                    Location = location,
                    Year = year,
                    IsCorrect = isCorrect
                };

                var newEvent = db.QueryFirstOrDefault<Event>(insertQuery, parameters);

                if (newEvent != null)
                {
                    return newEvent;
                }
            }
            throw new Exception("Could not create event");
        }

        public Event CompleteEvent(Event eventToUpdate)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var updateQuery = @"
                    Update event
                    Set IsCorrect = 1
                    Where Id = @id";

                var rowsAffected = db.Execute(updateQuery, eventToUpdate);

                if (rowsAffected == 1)
                {
                    return eventToUpdate;
                }
            }
            throw new Exception("Could not complete event");
        }
    }
}
