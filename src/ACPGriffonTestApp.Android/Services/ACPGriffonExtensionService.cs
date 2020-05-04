using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Runtime;
using Com.Adobe.Marketing.Mobile;

namespace ACPGriffonTestApp.Droid
{
    public class ACPGriffonExtensionService : IACPGriffonExtensionService
    {
        TaskCompletionSource<string> stringOutput;
        private string sessionUrl = "";

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
            stringOutput = new TaskCompletionSource<string>();
            ACPCore.GetPrivacyStatus(new StringCallback());
            stringOutput.SetResult("completed");
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
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("key", "value");
            ACPCore.TrackAction("action", data);
            stringOutput.SetResult("completed");
            return stringOutput;
        }

        public TaskCompletionSource<string> TrackState()
        {
            stringOutput = new TaskCompletionSource<string>();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("key", "value");
            ACPCore.TrackState("state", data);
            stringOutput.SetResult("completed");
            return stringOutput;
        }

        public TaskCompletionSource<string> UpdateConfig()
        {
            stringOutput = new TaskCompletionSource<string>();
            Dictionary<string, Java.Lang.Object> config = new Dictionary<string, Java.Lang.Object>();
            config.Add("someConfigKey", "configValue");
            config.Add("analytics.batchLimit", 5);
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
                    Console.WriteLine("String callback content: " + stringContent);
                }
                else
                {
                    Console.WriteLine("null content in string callback");
                }
            }
        }
    }

}
