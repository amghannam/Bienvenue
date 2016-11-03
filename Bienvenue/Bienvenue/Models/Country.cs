using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Bienvenue.Models
{
    /// <summary>
    /// This class will be instantiated from the JSON objects found in the Data folder of the project.
    /// Inherits from Galasoft.MvvmLight.ObservableObject to adhere to the INotifyPropertyChanged interface
    /// with default implementation.
    /// </summary>
    public class Country : GalaSoft.MvvmLight.ObservableObject
    {

        // Empty constructor... for now.
        public Country() { }

        public static Country FromJson(string jsonString) 
        {
            return JsonConvert.DeserializeObject<Country>(jsonString);
        }

        private string _countryName; // Private Backing Store
        [DataMember] // Mark with attribute for deserialization.
        public string CountryName
        {
            get                         // Essentially equivalent to:
            {                           // public String getCountryName() { return this.countryName; }
                return _countryName;
            }
            set
            {                           // Essentially equivalent to:
                _countryName = value;   // public void setCountryName(String name) { this.countryName = name; ... }
                RaisePropertyChanged();
            }
        }

        // Code to abstractions (i.e. interfaces) when possible.
        public IDictionary<string, string> Properties { get; set; } 
    }
}
