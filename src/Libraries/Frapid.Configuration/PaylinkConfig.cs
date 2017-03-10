namespace Frapid.Configuration
{
    public class PaylinkConfig
    {
        public static string GetDefaultProvider()
        {
            return ConfigurationManager.GetConfigurationValue("ParameterConfigFileLocation", "PaylinkDefaultProvider");
        }
    }

    
}