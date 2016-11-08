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
        public CountrySelectionViewModel CountrySelectViewModel
        {
            get {
                return new CountrySelectionViewModel();
            }
        }
    }
}
