using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using QuickConfig.Model;

namespace QuickConfig.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public List<ConfigurationGroup> CommandGroups { get; set; }
        public ObservableCollection<ConfigurationGroup> UsedCommands { get; set; }

        private ConfigurationGroup selectedConfigurationGroup;
                
        public ConfigurationGroup SelectedConfigurationGroup
        {
            get { return selectedConfigurationGroup; }
            set
            {
                OnCommandGroupSelectionChanged(value);
                selectedConfigurationGroup = value;
            }
        }


        public void OnCommandGroupSelectionChanged(ConfigurationGroup configuration)
        {
            Debug.WriteLine(configuration);
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {

            CommandsFactory.CreateCommandsFile(@"commands.json");

            CommandGroups = new List<ConfigurationGroup>
            {
                
                new ConfigurationGroup
                {
                    DisplayName = "Basic Config",
                    CommandKeys = new List<string>
                    {
                        "ChangeHostname",
                        "ChangeInterface"
                    }
                    
                },
                new ConfigurationGroup
                {
                    DisplayName = "EIGRP"
                },
            };
            
            // Load in XAML
        }
    }
}