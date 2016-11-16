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

        // Declare a private backing store variable.
        private string _countryName;

        // Make sure to use the DataMember attribute to mark an item
        // for (de)serialization. 
        [DataMember]
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

        private string _abbreviation;
        [DataMember]
        public string Abbreviation
        {
            get
            {
                return _abbreviation;
            }
            set
            {
                _abbreviation = value;
                RaisePropertyChanged();
            }
        }

        private string _imageUrl;
        [DataMember]
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                _imageUrl = value;
                RaisePropertyChanged();
            }
        }

        private string _currency;
        [DataMember]
        public string Currency
        {
            get
            {
                return _currency;
            }
            set
            {
                _currency = value;
                RaisePropertyChanged();
            }
        }

        private string _dateFormat;
        [DataMember]
        public string DateFormat
        {
            get
            {
                return _dateFormat;
            }
            set
            {
                _dateFormat = value;
                RaisePropertyChanged();
            }
        }

        private string _timeFormat;
        [DataMember]
        public string TimeFormat
        {
            get
            {
                return _timeFormat;
            }
            set
            {
                _timeFormat = value;
                RaisePropertyChanged();
            }
        }

        private bool _twelveHour;
        [DataMember]
        public bool TwelveHour
        {
            get
            {
                return _twelveHour;
            }
            set
            {
                _twelveHour = value;
                RaisePropertyChanged();
            }
        }

        private string _phonePrefix;
        [DataMember]
        public string PhonePrefix 
        { 
            get
            {
                return _phonePrefix;
            } set
            {
                _phonePrefix = value;
                RaisePropertyChanged();
            } 
        }

        private string _thousandsSeperator;
        [DataMember]
        public string ThousandsSeperator
        {
            get
            {
                return _thousandsSeperator;
            }
            set
            {
                _thousandsSeperator = value;
                RaisePropertyChanged();
            }
        }

        private string _decimalSeperator;
        [DataMember]
        public string DecimalSeperator
        {
            get { return _decimalSeperator; }
            set { 
                _decimalSeperator = value;
                RaisePropertyChanged();
            }
        }

        private int _population;
        [DataMember]
        public int Population
        {
            get { return _population; }
            set { _population = value; RaisePropertyChanged();  }
        }

        private double _size;
        [DataMember]
        public double Size
        {
            get { return _size; }
            set { _size = value; RaisePropertyChanged(); }
        }

        private string _languages;
        [DataMember]
        public string Languages
        {
            get { return _languages; }
            set { _languages = value; RaisePropertyChanged(); }
        }

        private string _interfaceDirection;
        [DataMember]
        public string InterfaceDirection
        {
            get { return _interfaceDirection; }
            set { _interfaceDirection = value; RaisePropertyChanged(); }
        }

        private string _paperSize;
        [DataMember]
        public string PaperSize
        {
            get {
                return _paperSize;
            }
            set {
                _paperSize = value;
                RaisePropertyChanged();
            }
        }

        private string _lengthUnits;
        [DataMember]
        public string LengthUnits
        {
            get {
                return _lengthUnits;
            }
            set {
                _lengthUnits = value;
                RaisePropertyChanged();
            }
        }

        private string _weightUnits;
        [DataMember]
        public string WeightUnits
        {
            get { return _weightUnits; }
            set { _weightUnits = value;  RaisePropertyChanged();  }
        }

        private string _volume;
        [DataMember]
        public string Volume
        {
            get { return _volume; }
            set { _volume = value;  RaisePropertyChanged();  }
        }

        private string _defaultKeyboard;
        [DataMember]
        public string DefaultKeyboard
        {
            get { return _defaultKeyboard; }
            set { _defaultKeyboard = value; RaisePropertyChanged(); }
        }
    }
}
