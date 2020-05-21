/*
Copyright 2020 Adobe
All Rights Reserved.

NOTICE: Adobe permits you to use, modify, and distribute this file in
accordance with the terms of the Adobe license agreement accompanying
it. If you have received this file from a source other than Adobe,
then your use, modification, or distribution of it requires the prior
written permission of Adobe. (See LICENSE-MIT for details)
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ACPGriffonTestApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // ACPCore API
        void OnCoreExtensionVersionButtonClicked(object sender, EventArgs args)
        {
            string result = DependencyService.Get<IACPGriffonExtensionService>().GetExtensionVersionCore().Task.Result;
            handleStringResult("GetExtensionVersionCore", result);
        }

        void OnGetPrivacyStatusButtonClicked(object sender, EventArgs args)
        {
            string result = DependencyService.Get<IACPGriffonExtensionService>().GetPrivacyStatus().Task.Result;
            handleStringResult("GetPrivacyStatus", result);
        }

        void OnSetAdvertisingIdentifierButtonClicked(object sender, EventArgs args)
        {
            string result = DependencyService.Get<IACPGriffonExtensionService>().SetAdvertisingIdentifier().Task.Result;
            handleStringResult("SetAdvertisingIdentifier", result);
        }

        void OnSetLogLevelButtonClicked(object sender, EventArgs args)
        {
            string result = DependencyService.Get<IACPGriffonExtensionService>().SetLogLevel().Task.Result;
            handleStringResult("SetLogLevel", result);
        }

        void OnSetPrivacyStatusButtonClicked(object sender, EventArgs args)
        {
            string result = DependencyService.Get<IACPGriffonExtensionService>().SetPrivacyStatus().Task.Result;
            handleStringResult("SetPrivacyStatus", result);
        }

        void OnTrackActionButtonClicked(object sender, EventArgs args)
        {
            string result = DependencyService.Get<IACPGriffonExtensionService>().TrackAction().Task.Result;
            handleStringResult("TrackAction", result);
        }

        void OnTrackStateButtonClicked(object sender, EventArgs args)
        {
            string result = DependencyService.Get<IACPGriffonExtensionService>().TrackState().Task.Result;
            handleStringResult("TrackState", result);
        }

        void OnUpdateConfigurationButtonClicked(object sender, EventArgs args)
        {
            string result = DependencyService.Get<IACPGriffonExtensionService>().UpdateConfig().Task.Result;
            handleStringResult("UpdateConfig", result);
        }

        // ACPGriffon API
        void OnGriffonExtensionVersionButtonClicked(object sender, EventArgs args)
        {
            string result = DependencyService.Get<IACPGriffonExtensionService>().GetExtensionVersionGriffon().Task.Result;
            handleStringResult("GetExtensionVersionGriffon", result);
        }

        void OnStartSessionButtonClicked(object sender, EventArgs args)
        {
            string result = DependencyService.Get<IACPGriffonExtensionService>().StartSession().Task.Result;
            handleStringResult("StartSession", result);
        }

        // helper methods
        private void handleStringResult(string apiName, string result)
        {
            if (result != null)
            {
                Console.WriteLine(apiName + ": " + result);
            }
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            OnSessionUrlInput(e.NewTextValue);
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            OnSessionUrlInput(((Entry)sender).Text);
        }

        void OnSessionUrlInput(string sessionUrl)
        {
            DependencyService.Get<IACPGriffonExtensionService>().GetSessionUrlFromEntry(sessionUrl);
        }
    }
}
