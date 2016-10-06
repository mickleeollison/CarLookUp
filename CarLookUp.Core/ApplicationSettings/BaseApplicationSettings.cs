using CarLookUp.Core.Exceptions;
using System.Configuration;

namespace CarLookUp.Core.ApplicationSettings
{
    public class BaseApplicationSettings
    {
        protected static string Get(string key)
        {
            var setting = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(setting))
            {
                throw new ApplicationSettingsException(string.Format("The settting {0} has not been set.", key));
            }
            return setting;
        }
    }
}
