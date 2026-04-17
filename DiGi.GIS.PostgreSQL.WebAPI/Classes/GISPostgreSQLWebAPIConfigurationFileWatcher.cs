namespace DiGi.GIS.PostgreSQL.WebAPI.Classes
{
    public class GISPostgreSQLWebAPIConfigurationFileWatcher : Core.IO.FileWatcher.Classes.ConfigurationFileWatcher
    {
        public GISPostgreSQLWebAPIConfigurationFileWatcher(string path, double interval = 5000)
            : base(path, interval)
        {
        }

        public bool AllowUpdateBuilding2D
        {
            get
            {
                return ConfigurationFile.GetValue<bool>(nameof(AllowUpdateBuilding2D));
            }
        }

        public bool AllowUpdateAdministrativeAreal2D
        {
            get
            {
                return ConfigurationFile.GetValue<bool>(nameof(AllowUpdateAdministrativeAreal2D));
            }
        }

        public bool AllowUpdateOrtoDatas
        {
            get
            {
                return ConfigurationFile.GetValue<bool>(nameof(AllowUpdateOrtoDatas));
            }
        }

        public bool AllowUpdateYearBuiltData
        {
            get
            {
                return ConfigurationFile.GetValue<bool>(nameof(AllowUpdateYearBuiltData));
            }
        }
    }
}