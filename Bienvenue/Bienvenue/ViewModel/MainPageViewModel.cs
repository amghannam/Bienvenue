using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

namespace Bienvenue.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {

        private ObservableCollection<CountrySelectionViewModel> _countryViewModels = null;
        public ObservableCollection<CountrySelectionViewModel> CountryViewModels
        {
            get
            {
                if(_countryViewModels == null)
                {
                    _countryViewModels = new ObservableCollection<CountrySelectionViewModel>();
                    _countryViewModels.Add(new CountrySelectionViewModel());
                }

                return _countryViewModels;
            }

            private set 
            {
                _countryViewModels = value;
                RaisePropertyChanged();
            }
        }

        private RelayCommand _addCountry;
        public RelayCommand AddCountry
        {
            get 
            {
                if(_addCountry == null) 
                {
                    _addCountry = new RelayCommand(AddCountryCommand);
                }

                return _addCountry;
            }
        }

        private void AddCountryCommand()
        {
            CountryViewModels.Add(new CountrySelectionViewModel());
        }

        private RelayCommand _resetCountries;
        public RelayCommand ResetCountries
        {
            get
            {
                if(_resetCountries == null) {
                    _resetCountries = new RelayCommand(ResetCountriesCommand);
                }

                return _resetCountries;
            }
        }

        private void ResetCountriesCommand()
        {
            CountryViewModels = null;
        }

    }
}
