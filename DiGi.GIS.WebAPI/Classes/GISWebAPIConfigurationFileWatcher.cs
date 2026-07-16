namespace DiGi.GIS.WebAPI.Classes
{
    /// <summary>
    /// Provides functionality to watch and retrieve configuration settings for the GIS PostgreSQL Web API from a specified configuration file.
    /// </summary>
    public class GISWebAPIConfigurationFileWatcher : Core.IO.FileWatcher.Classes.ConfigurationFileWatcher
    {
        /// <summary>
        /// Initializes a new instance of the GISWebAPIConfigurationFileWatcher class.
        /// </summary>
        /// <param name="path">The path to the configuration file to be watched.</param>
        /// <param name="interval">The time interval in milliseconds between checks for changes to the configuration file.</param>
        public GISWebAPIConfigurationFileWatcher(string path, double interval = 5000)
            : base(path, interval)
        {
        }

        /// <summary>
        /// Gets a value indicating whether updates to 2D buildings are permitted based on the configuration file settings.
        /// </summary>
        public bool AllowUpdateBuilding2D
        {
            get
            {
                return ConfigurationFile.GetValue<bool>(nameof(AllowUpdateBuilding2D));
            }
        }

        /// <summary>
        /// Gets a value indicating whether updates to administrative areal 2D data are permitted according to the configuration file.
        /// </summary>
        public bool AllowUpdateAdministrativeAreal2D
        {
            get
            {
                return ConfigurationFile.GetValue<bool>(nameof(AllowUpdateAdministrativeAreal2D));
            }
        }

        /// <summary>
        /// Gets a value indicating whether updates to orthophoto data are permitted according to the configuration file.
        /// </summary>
        public bool AllowUpdateOrtoDatas
        {
            get
            {
                return ConfigurationFile.GetValue<bool>(nameof(AllowUpdateOrtoDatas));
            }
        }

        /// <summary>
        /// Gets a value indicating whether updating year built data is enabled in the configuration.
        /// </summary>
        public bool AllowUpdateYearBuiltData
        {
            get
            {
                return ConfigurationFile.GetValue<bool>(nameof(AllowUpdateYearBuiltData));
            }
        }

        /// <summary>
        /// Gets a value indicating whether updating EPW file data is enabled in the configuration.
        /// </summary>
        public bool AllowUpdateEPWFile
        {
            get
            {
                return ConfigurationFile.GetValue<bool>(nameof(AllowUpdateEPWFile));
            }
        }
    }
}