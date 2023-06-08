using System.Data;
using EntityFramwork_Test.Data;
using EntityFramwork_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFramwork_Test
{
    public static class DatabaseInitializer
    {
        public static void Initialize(DataContext dbContext)
        {
            // Apply pending migrations and create the database if it doesn't exist
            // put Person and SuperHero tables
            dbContext.Database.Migrate();

            // Ensure that the tables are created
            dbContext.Database.EnsureCreated();

            // Open the database connection
            dbContext.Database.OpenConnection();

            // Seed initial data if the tables are empty
            if (!dbContext.Operator.Any())
            {
                // Create a few instances of Person and Employee
                var operator1 = new Operator { Name = "Bob Johnson", Salary = 50000 };
                var operator2 = new Operator { Name = "Alice Williams", Salary = 60000 };

                // Add the instances to the DbContext
                dbContext.Operator.AddRange(operator1, operator2);

                // Save the changes to the database
                dbContext.SaveChanges();
            }

            // Close the database connection
            dbContext.Database.CloseConnection();
        }
    }
}
