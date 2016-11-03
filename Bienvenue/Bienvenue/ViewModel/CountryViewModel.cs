using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bienvenue.Models;

namespace Bienvenue.ViewModel
{
    public class CountryViewModel : GalaSoft.MvvmLight.ViewModelBase
    {

        private Country _country;
        public Country Country
        {
            get 
            {
                return _country;
            }
            set
            {
                _country = value;
                RaisePropertyChanged();
            }
        }  

        public CountryViewModel() { }
        public CountryViewModel(Country country) { Country = country; }

        public override string ToString()
        {
            return Country.CountryName;
        }
    }
}
