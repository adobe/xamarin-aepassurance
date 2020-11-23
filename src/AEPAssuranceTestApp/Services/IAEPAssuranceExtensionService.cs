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
using System.Threading.Tasks;

namespace AEPAssuranceTestApp
{
    public interface IAEPAssuranceExtensionService
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
        TaskCompletionSource<string> GetExtensionVersionAssurance();
        TaskCompletionSource<string> StartSession();
        // text input
        void GetSessionUrlFromEntry(string sessionUrl);
    }
}
