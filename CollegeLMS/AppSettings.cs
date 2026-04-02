using System;
using System.Configuration;

namespace CollegeLMS
{
    internal static class AppSettings
    {
        internal const string ConnectionStringName = "CTUCollegeDB";

        private static readonly Lazy<string> LazyConnectionString = new Lazy<string>(() =>
        {
            string cs = ConfigurationManager.ConnectionStrings[ConnectionStringName]?.ConnectionString;
            if (string.IsNullOrWhiteSpace(cs))
            {
                throw new ConfigurationErrorsException(
                    $"Missing connection string '{ConnectionStringName}' in App.config.");
            }

            return cs;
        });

        internal static string ConnectionString => LazyConnectionString.Value;
    }
}
