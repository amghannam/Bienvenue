using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Bienvenue.ViewModel;

namespace Bienvenue
{
    public class ViewModelLocator
    {

        public CountrySelectionViewModel CountryViewModel
        {
            get {
  
              return new CountrySelectionViewModel();
            }
        }

        private MainPageViewModel _mainViewModel;
        public MainPageViewModel MainViewModel
        {
            get
            {
                return _mainViewModel ?? (_mainViewModel = new MainPageViewModel());
            }
        }
    }
}
