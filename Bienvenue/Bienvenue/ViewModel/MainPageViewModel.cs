using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.UI.Xaml; 
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

        private RelayCommand<string> _addCountry;
        public RelayCommand<string> AddCountry
        {
            get 
            {
                if(_addCountry == null) 
                {
                    _addCountry = new RelayCommand<string>(AddCountryCommand);
                }

                return _addCountry;
            }
        }

        public void AddCountryCommand(string country = "United States of America")
        {
            var viewModel = new CountrySelectionViewModel();
            viewModel.SelectedCountry = viewModel.AvailableCountries.Where(x => x.Country.CountryName == country).FirstOrDefault();

            CountryViewModels.Add(viewModel);

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

        public void ResetCountriesCommand()
        {
            CountryViewModels = null;
        }

        public RelayCommand ExitApp
        {
            get
            {
                return new RelayCommand(ExitCommand);
            }
        }

        public void ExitCommand()
        {
            Application.Current.Exit(); 
        }
    }
}


