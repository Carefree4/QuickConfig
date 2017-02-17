using System.Collections.Generic;

namespace QuickConfig.Model
{
    public class ConfigurationGroup
    {
        public string DisplayName { get; set; }
        public IEnumerable<string> CommandKeys { get; set; }

        public override string ToString() => DisplayName;
    }
}