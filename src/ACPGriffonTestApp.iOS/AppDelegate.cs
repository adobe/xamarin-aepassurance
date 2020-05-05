using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Com.Adobe.Marketing.Mobile;

namespace ACPGriffonTestApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            // set the wrapper type
            ACPCore.SetWrapperType(ACPMobileWrapperType.Xamarin);

            // set log level
            ACPCore.LogLevel = ACPMobileLogLevel.Verbose;

            // register SDK extensions
            ACPLifecycle.RegisterExtension();
            ACPIdentity.RegisterExtension();
            ACPGriffon.RegisterExtension();

            // start core
            ACPCore.Start(startCallback);

            // register dependency service to link interface from ACPCoreTestApp base project
            DependencyService.Register<IACPGriffonExtensionService, ACPGriffonExtensionService>();

            return base.FinishedLaunching(app, options);
        }

        // Called when the application is launched and every time the app returns to the foreground.
        public override void OnActivated(UIApplication uiApplication)
        {
            base.OnActivated(uiApplication);
            ACPCore.LifecycleStart(null);
        }

        // Called when the application is about to enter the background, be suspended, or when the user receives an interruption such as a phone call or text.
        public override void OnResignActivation(UIApplication uiApplication)
        {
            base.OnResignActivation(uiApplication);
            ACPCore.LifecyclePause();
        }
        // Handle app open from url scheme of acpgriffontestapp://link
        public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            ACPGriffon.StartSession(url);
            return false;
        }

        private void startCallback()
        {
            // set launch config
            ACPCore.ConfigureWithAppId("launch-ENf8ed5382efc84d5b81a9be8dcc231be1-development");
        }
    }
}
