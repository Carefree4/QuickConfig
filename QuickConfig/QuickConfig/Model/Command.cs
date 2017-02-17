using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuickConfig.Model
{

    public class Command
    {
        private const char ParameterEscape = '@';

        public string DisplayName { get; private set; }
        public string CommandShell { get; private set; }
        public IEnumerable<string> CommandParameterDescriptions { get; private set; }

        public Command(string displayName, string commandShell, IEnumerable<string> commandParameterDescriptions)
        {
            this.DisplayName = displayName;
            this.CommandShell = commandShell;
            this.CommandParameterDescriptions = commandParameterDescriptions;
        }

        public string GetCommand(IEnumerable<string> parameters)
        {
            var enumerable = parameters as string[] ?? parameters.ToArray();
            if (enumerable.Count() != CommandShell.Count(c => c == ParameterEscape))
            {
                return "INVALID PARAMETERS";
            }

            var builtCommand = CommandShell;
            var reggie = new Regex(Regex.Escape(ParameterEscape.ToString()));
            var i = 1;
            return enumerable.Aggregate(builtCommand, (current, parameter) => reggie.Replace(current, parameter, i++));
        }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
