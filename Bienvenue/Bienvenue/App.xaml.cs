﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Diagnostics; 
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.SpeechRecognition;
using Windows.ApplicationModel.VoiceCommands;
using Windows.Storage;
using Windows.UI.Popups; 

using Bienvenue.ViewModel;

namespace Bienvenue
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (e.PrelaunchActivated == false)
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                // Ensure the current window is active
                Window.Current.Activate(); 
            }

            try
            {
                StorageFile ccd = await Package.Current.InstalledLocation.GetFileAsync(@"CortanaCommandDefinitions.xml");
                await VoiceCommandDefinitionManager.InstallCommandDefinitionsFromStorageFileAsync(ccd); 
            } catch (Exception ex)
            {
                Debug.Write("Failed to load voice commands because: " + ex.Message); 
            }

            var viewModel = new CountrySelectionViewModel();
        }

        protected async override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);

            MessageDialog dialog = new MessageDialog("");
            var modelLocator = Resources["ViewModelLocator"] as ViewModelLocator;
            MainPageViewModel model = modelLocator?.MainViewModel;

            if (args.Kind == ActivationKind.VoiceCommand)
            {
                VoiceCommandActivatedEventArgs cmd = args as VoiceCommandActivatedEventArgs;
                SpeechRecognitionResult result = cmd.Result;

                string commandName = result.RulePath[0];
                switch (commandName) // we can add as many commands as need to execute here 
                {
                    case "Exit":
                        dialog.Content = "Exiting now..."; 
                        model.ExitCommand(); 
                        break;
                    case "Reset":
                        dialog.Content = "Reseting...";
                        model.ResetCountriesCommand();
                        break;
                    case "AddCountry":
                        dialog.Content = "Adding...";
                        model.AddCountryCommand();
                        break;
                    case "CompareCountries":
                        dialog.Content = "Getting the differences between the countries...";
                        var countryA = SemanticInterpretation("countryA", result);
                        var countryB = SemanticInterpretation("countryB", result);
                        model.AddCountryCommand(countryA);
                        model.AddCountryCommand(countryB);
                         break;
                    default:
                        Debug.WriteLine("Could not find command.");
                        break; 
                }
            }
            await dialog.ShowAsync(); 
        }

        private string SemanticInterpretation(string interpretationKey, SpeechRecognitionResult speechRecognitionResult)
        {
            return speechRecognitionResult.SemanticInterpretation.Properties[interpretationKey].FirstOrDefault();
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}
