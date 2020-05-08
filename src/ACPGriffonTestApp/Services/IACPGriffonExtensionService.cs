using System;
using System.Threading.Tasks;

namespace ACPGriffonTestApp
{
    public interface IACPGriffonExtensionService
    {
        // ACPCore API
        TaskCompletionSource<string> GetExtensionVersionCore();
        TaskCompletionSource<string> GetPrivacyStatus();
        TaskCompletionSource<string> SetAdvertisingIdentifier();
        TaskCompletionSource<string> SetLogLevel();
        TaskCompletionSource<string> SetPrivacyStatus();
        TaskCompletionSource<string> TrackAction();
        TaskCompletionSource<string> TrackState();
        TaskCompletionSource<string> UpdateConfig();
        // ACPGriffon API
        TaskCompletionSource<string> GetExtensionVersionGriffon();
        TaskCompletionSource<string> StartSession();
        // text input
        void GetSessionUrlFromEntry(string sessionUrl);
    }
}
