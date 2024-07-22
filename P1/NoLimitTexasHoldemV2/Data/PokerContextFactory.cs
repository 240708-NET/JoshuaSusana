using Microsoft.EntityFrameworkCore;                //To use DbContextOptionsBuilder
using Microsoft.EntityFrameworkCore.Design;         //To implement the IDesignTimeDbContextFactory interface
using Microsoft.Extensions.Configuration;           //To use IConfigurationRoot

namespace NoLimitTexasHoldemV2.Data
{
    //Purpose of this class is to create an instance of DbContext during design-time, useful for migrations
    public class PokerContextFactory : IDesignTimeDbContextFactory<PokerContext>
    {
        //Part of contract is we must implement this method, which instantiates and configures a PokerContext object
        public PokerContext CreateDbContext(string[] args)
        {
            //The variable itself represents a root node in a configuration hierarchy. It provides access to configuration settings.
            //Initialize the variable to configuration object, set base path to current directory, add user secrets so we can get
            //the connection string, then build the confiugration object
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<Program>()
                .Build();

            //Create a DbContextOptionsBuilder object to configure options for DbConttext
            DbContextOptionsBuilder<PokerContext> builder = new DbContextOptionsBuilder<PokerContext>();

            //Getting connection string from user secrets
            string connectionString = configuration.GetConnectionString("PokerDatabaseConnection");

            //Connect to SQL server using connection string
            builder.UseSqlServer(connectionString);

            //Return a new instance of PokerContext with the configured options
            return new PokerContext(builder.Options);
        }
    }
}
