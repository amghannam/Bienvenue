using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bienvenue.Models;

namespace Bienvenue.ViewModel
{
    public class CountrySelectionViewModel : GalaSoft.MvvmLight.ViewModelBase
    {

        private static ICollection<CountryViewModel> _availableCountries;
        public static ICollection<CountryViewModel> AvailableCountries
        {
            get 
            {
                return _availableCountries ?? GetAvailableCountries();
            }
            private set {
                _availableCountries = value;
            }
        }

        private static ICollection<CountryViewModel> GetAvailableCountries()
        {
            var directory = System.IO.Path.Combine("Data", 
                System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName);

            var files = System.IO.Directory.EnumerateFiles(directory);

            AvailableCountries = files.Select((x) =>
            {
                return new CountryViewModel
                {
                    Country = Country.FromJson(System.IO.File.ReadAllText(x))
                };
            }).ToList(); 

            return AvailableCountries;
        }

        private CountryViewModel _selectedCountry;
        public CountryViewModel SelectedCountry
        {
            get
            {
                return _selectedCountry;
            }
            set
            {
                _selectedCountry = value;
                RaisePropertyChanged();
            }
        }

    }
}
