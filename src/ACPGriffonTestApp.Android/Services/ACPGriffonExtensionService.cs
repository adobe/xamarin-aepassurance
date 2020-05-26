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
using System.Threading.Tasks;
using Android.Runtime;
using Com.Adobe.Marketing.Mobile;
using System.Threading;

namespace ACPGriffonTestApp.Droid
{
    public class ACPGriffonExtensionService : IACPGriffonExtensionService
    {
        TaskCompletionSource<string> stringOutput;
        private static CountdownEvent latch = null;
        private string sessionUrl = "";
        private static string callbackString = "";

        public ACPGriffonExtensionService()
        {
        }

        // ACPCore methods
        public TaskCompletionSource<string> GetExtensionVersionCore()
        {
            stringOutput = new TaskCompletionSource<string>();
            stringOutput.SetResult(ACPCore.ExtensionVersion());
            return stringOutput;
        }

        public TaskCompletionSource<string> GetPrivacyStatus()
        {
            latch = new CountdownEvent(1);
            stringOutput = new TaskCompletionSource<string>();
            ACPCore.GetPrivacyStatus(new StringCallback());
            latch.Wait(1000);
            stringOutput.SetResult(callbackString);
            return stringOutput;
        }

        public TaskCompletionSource<string> GetSDKIdentities()
        {
            latch = new CountdownEvent(1);
            stringOutput = new TaskCompletionSource<string>();
            ACPCore.GetSdkIdentities(new StringCallback());
            latch.Wait(1000);
            stringOutput.SetResult(callbackString);
            return stringOutput;
        }

        public TaskCompletionSource<string> SetAdvertisingIdentifier()
        {
            stringOutput = new TaskCompletionSource<string>();
            ACPCore.SetAdvertisingIdentifier("testAdvertisingIdentifier");
            stringOutput.SetResult("completed");
            return stringOutput;
        }

        public TaskCompletionSource<string> SetLogLevel()
        {
            stringOutput = new TaskCompletionSource<string>();
            ACPCore.LogLevel = LoggingMode.Verbose;
            stringOutput.SetResult("completed");
            return stringOutput;
        }

        public TaskCompletionSource<string> SetPrivacyStatus()
        {
            stringOutput = new TaskCompletionSource<string>();
            ACPCore.SetPrivacyStatus(MobilePrivacyStatus.OptIn);
            stringOutput.SetResult("completed");
            return stringOutput;
        }

        public TaskCompletionSource<string> TrackAction()
        {
            stringOutput = new TaskCompletionSource<string>();
            var data = new Dictionary<string, string>();
            data.Add("key", "value");
            ACPCore.TrackAction("action", data);
            stringOutput.SetResult("completed");
            return stringOutput;
        }

        public TaskCompletionSource<string> TrackState()
        {
            stringOutput = new TaskCompletionSource<string>();
            var data = new Dictionary<string, string>();
            data.Add("key", "value");
            ACPCore.TrackState("state", data);
            stringOutput.SetResult("completed");
            return stringOutput;
        }

        public TaskCompletionSource<string> UpdateConfig()
        {
            stringOutput = new TaskCompletionSource<string>();
            var config = new Dictionary<string, Java.Lang.Object>();
            config.Add("someConfigKey", "configValue");
            ACPCore.UpdateConfiguration(config);
            stringOutput.SetResult("completed");
            return stringOutput;
        }

        // ACPGriffon methods
        public TaskCompletionSource<string> GetExtensionVersionGriffon()
        {
            stringOutput = new TaskCompletionSource<string>();
            stringOutput.SetResult(ACPGriffon.ExtensionVersion());
            return stringOutput;
        }

        public TaskCompletionSource<string> StartSession()
        {
            stringOutput = new TaskCompletionSource<string>();
            if (sessionUrl.Length > 0)
            {
                ACPGriffon.StartSession(sessionUrl);
            }
            else
            {
                Console.WriteLine("Invalid session url");
            }
            stringOutput.SetResult("");
            return stringOutput;
        }

        // get text input from Entry
        public void GetSessionUrlFromEntry(string newSessionUrl)
        {
            sessionUrl = newSessionUrl;
        }

        // callbacks
        class StringCallback : Java.Lang.Object, IAdobeCallback
        {
            public void Call(Java.Lang.Object stringContent)
            {
                if (stringContent != null)
                {
                    callbackString = stringContent.ToString();
                }
                else
                {
                    callbackString = "null content in string callback";
                }
                if (latch != null)
                {
                    latch.Signal();
                }
            }
        }
    }

}
