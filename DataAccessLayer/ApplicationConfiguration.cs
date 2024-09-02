using System.Configuration;

namespace DataAccessLayer
{
    public static class ApplicationConfiguration
    {
        private static string dbConnectionString;
        // Caches the data provider name
        private static string dbProviderName;
        static ApplicationConfiguration()
        {
            System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder e =
                new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder(ConfigurationManager.ConnectionStrings["UsualConnection"].ConnectionString);
            dbConnectionString = e.ProviderConnectionString;
            dbProviderName = e.Provider;
        }
        // Returns the connection string for the BalloonShop database
        public static string DbConnectionString
        {
            get
            {
                return dbConnectionString;
            }
        }
        // Returns the data provider name
        public static string DbProviderName
        {
            get
            {
                return dbProviderName;
            }
        }
    }
}
