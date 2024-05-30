using System.Diagnostics;
using System.Text;

namespace Rise_of_Derma.providers
{
    public class Config
    {
        private string ConfigPath {
            get { return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/RiseOfDerma"; } 
        }

        private string ConfigFilePath
        {
            get { return ConfigPath + "/config.txt"; }
        }

        public string UserName { get; set; }
        public string UUID { get; set; }

        public Config()
        {
            UserName = string.Empty;
            UUID = string.Empty;
            parseConfig();
        }

        private string[] getConfigFile()
        {
            // Check if config directory exists
            if (!Directory.Exists(ConfigPath))
            {
                // If not create the folder
                Directory.CreateDirectory(ConfigPath);
                // Also Create the config file
                createConfigFile();
            } 

            // Check if config file exists
            if (!File.Exists(ConfigFilePath))
            {
                createConfigFile();
            }

            // Read the file than return it
            return File.ReadAllLines(ConfigFilePath);
        }

        private void createConfigFile()
        {
            // Print debug
            Debug.WriteLine("Creating Config file");

            // Create file than write default variables in there
            StreamWriter f = new StreamWriter(ConfigFilePath, false, Encoding.UTF8);
            f.WriteLine("UserName=");
            f.WriteLine($"UUID={Guid.NewGuid().ToString()}");
            f.Close();
        }

        private void parseConfig()
        {
            // Print debug
            Debug.WriteLine("Parsing Config file");

            // Get file lines
            string[] configFile = getConfigFile();

            // If not null, than parse
            if (configFile != null)
            {
                UserName = configFile[0].Split('=')[1];
                UUID = configFile[1].Split('=')[1];
            }
        }

        public void setConfig(string ConfigName, string ConfigValue)
        {
            // Print debug
            Debug.WriteLine($"Updating config file: {ConfigName} to {ConfigValue}");

            string[] configFile = getConfigFile();

            if (configFile != null)
            {
                switch (ConfigName)
                {
                    case "UserName":
                        UserName = ConfigValue;
                        configFile[0] = $"UserName={ConfigValue}";
                        break;
                }

                File.WriteAllLines(ConfigFilePath, configFile);
            }
        }

        public void refreshConfig()
        {
            parseConfig();
        }

        public string getConfigPath() { return ConfigPath; }
    }
}
