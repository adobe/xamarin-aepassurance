using System;
using Foundation;
using ObjCRuntime;

namespace Com.Adobe.Marketing.Mobile
{
	// @interface ACPGriffon : NSObject
	[BaseType(typeof(NSObject))]
	interface ACPGriffon
	{
		// +(void)registerExtension;
		[Static]
		[Export("registerExtension")]
		void RegisterExtension();

		// +(NSString * _Nonnull)extensionVersion;
		[Static]
		[Export("extensionVersion")]
		string ExtensionVersion { get; }

		// +(void)startSession:(NSURL * _Nonnull)url;
		[Static]
		[Export("startSession:")]
		void StartSession(NSUrl url);
	}
}
