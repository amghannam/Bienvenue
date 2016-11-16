using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Bienvenue.Views
{
    public sealed partial class CountryUserControl : UserControl
    {
        private ViewModel.CountrySelectionViewModel _viewModel;

        public CountryUserControl()
        {
            this.InitializeComponent();

            CountryScroll.ViewChanging += CountryScroll_ViewChanging;
        }

        private void CountryScroll_ViewChanging(object sender, ScrollViewerViewChangingEventArgs e)
        {
            if(_viewModel != null) _viewModel.VerticalOffset = e.NextView.VerticalOffset;
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "VerticalOffset") {
                CountryScroll.ChangeView(null, _viewModel.VerticalOffset, null);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void UserControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            var viewModel = args.NewValue as ViewModel.CountrySelectionViewModel;

            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }
    }
}
