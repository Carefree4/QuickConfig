using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace QuickConfig.Model
{
    public class CommandsFactory
    {
        private static readonly Dictionary<string, Command> Commands = new Dictionary<string, Command>
        {
            {"ChangeHostname", new Command("Change Hostname", "hostname @", new List<string> {"Device Hostname"})},
            {"ChangeInterface", new Command("Change Interface", "interface @", new List<string> {"Interface"})},
            {
                "ChangeIpAddress",
                new Command("Change Ip address", "ip address @ @", new List<string> {"Ip", "Subnet Mask"})
            }
        };

        private static readonly List<ConfigurationGroup> ConfigurationGroups = new List<ConfigurationGroup>
        {
            new ConfigurationGroup()
            {
                DisplayName = "Basic Configuration",
                CommandKeys = new List<string> { "ChangeHostname","ChangeInterface" }
            }
        };

        public static void CreateCommandsFile(string filePath)
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new KeyValuePairConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (var sw = new StreamWriter(filePath))
            {
                using (var writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, Commands);
                }
            }
        }

        public static void CreateCommandGroupsFile(string filePath)
        {
            var serializer = new JsonSerializer();
            serializer.Converters.Add(new KeyValuePairConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;

            using (var sw = new StreamWriter(filePath))
            {
                using (var writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, ConfigurationGroups);
                }
            }
        }
    }
}