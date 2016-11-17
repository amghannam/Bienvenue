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
        
        public CountrySelectionViewModel () {
            Instances.Add(this);
        }
        private static ICollection<CountrySelectionViewModel> _instances;
        private static ICollection<CountrySelectionViewModel> Instances
        {
            get {
                if (_instances == null) _instances = new List<CountrySelectionViewModel>();
                return _instances;
            }
            set {
                _instances = value;
            }
        }
        private static double _verticalOffset;

        public double VerticalOffset
        {
            get
            {
                return _verticalOffset;
            }
            set
            {
                _verticalOffset = value;
                RaisePropertyChanged();
                foreach(var inst in Instances) {
                    if (inst == this) continue;
                    inst.RaisePropertyChanged("VerticalOffset");
                }
            }
        }

        private static ICollection<CountryViewModel> _availableCountries;
        public ICollection<CountryViewModel> AvailableCountries
        {
            get 
            {
                return _availableCountries ?? GetAvailableCountries();
            }
        }

        private ICollection<CountryViewModel> GetAvailableCountries()
        {
            var directory = System.IO.Path.Combine("Data", 
                System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName);

            var files = System.IO.Directory.EnumerateFiles(directory);

            _availableCountries = files.Select((x) =>
            {
                return new CountryViewModel
                {
                    Country = Country.FromJson(System.IO.File.ReadAllText(x))
                };
            }).ToList();

            RaisePropertyChanged("AvailableCountries");

            return _availableCountries;
        }

        private CountryViewModel _selectedCountry;
        public CountryViewModel SelectedCountry
        {
            get
            {
                return _selectedCountry ?? (_selectedCountry = AvailableCountries.Where(x => x.Country.Abbreviation == "USA").FirstOrDefault());
            }
            set
            {
                _selectedCountry = value;
                RaisePropertyChanged();
            }
        }

    }
}
