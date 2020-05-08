/*
 Copyright 2020 Adobe. All rights reserved.
 This file is licensed to you under the Apache License, Version 2.0 (the "License");
 you may not use this file except in compliance with the License. You may obtain a copy
 of the License at http://www.apache.org/licenses/LICENSE-2.0
 Unless required by applicable law or agreed to in writing, software distributed under
 the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR REPRESENTATIONS
 OF ANY KIND, either express or implied. See the License for the specific language
 governing permissions and limitations under the License.
*/

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

	// @interface ACPGriffonEvent : NSObject
	[BaseType(typeof(NSObject))]
	interface ACPGriffonEvent
	{
		// @property (readonly, nonatomic) NSString * _Nonnull eventID;
		[Export("eventID")]
		string EventID { get; }

		// @property (nonatomic, strong) NSString * _Nonnull clientID;
		[Export("clientID", ArgumentSemantic.Strong)]
		string ClientID { get; set; }

		// @property (readonly, nonatomic) NSString * _Nonnull vendor;
		[Export("vendor")]
		string Vendor { get; }

		// @property (readonly, nonatomic) NSString * _Nonnull type;
		[Export("type")]
		string Type { get; }

		// @property (readonly, nonatomic) NSDictionary * _Nullable payload;
		[NullAllowed, Export("payload")]
		NSDictionary Payload { get; }

		// @property (readonly, nonatomic) NSString * _Nullable pairID;
		[NullAllowed, Export("pairID")]
		string PairID { get; }

		// @property (readonly, nonatomic) long timestamp;
		[Export("timestamp")]
		nint Timestamp { get; }

		// @property (readonly, nonatomic) int eventNumber;
		[Export("eventNumber")]
		int EventNumber { get; }

		// -(instancetype _Nullable)initWithJSONData:(NSData * _Nullable)json;
		[Export("initWithJSONData:")]
		IntPtr Constructor([NullAllowed] NSData json);

		// -(instancetype _Nonnull)initWithVendor:(NSString * _Nonnull)vendor type:(NSString * _Nonnull)type payload:(NSDictionary * _Nullable)payload;
		[Export("initWithVendor:type:payload:")]
		IntPtr Constructor(string vendor, string type, [NullAllowed] NSDictionary payload);

		// -(instancetype _Nonnull)initWithVendor:(NSString * _Nonnull)vendor type:(NSString * _Nonnull)type pairID:(NSString * _Nullable)pairID payload:(NSDictionary * _Nullable)payload timestamp:(long)timestamp;
		[Export("initWithVendor:type:pairID:payload:timestamp:")]
		IntPtr Constructor(string vendor, string type, [NullAllowed] string pairID, [NullAllowed] NSDictionary payload, nint timestamp);

		// -(NSData * _Nonnull)jsonRepresentation;
		[Export("jsonRepresentation")]
		NSData JsonRepresentation { get; }
	}

	// @protocol ACPGriffonEventListener
	/*
	  Check whether adding [Model] to this declaration is appropriate.
	  [Model] is used to generate a C# class that implements this protocol,
	  and might be useful for protocols that consumers are supposed to implement,
	  since consumers can subclass the generated class instead of implementing
	  the generated interface. If consumers are not supposed to implement this
	  protocol, then [Model] is redundant and will generate code that will never
	  be used.
	*/
	[Protocol]
	interface ACPGriffonEventListener
	{
		// @required -(void)hear:(ACPGriffonEvent * _Nonnull)remoteEvent;
		[Abstract]
		[Export("hear:")]
		void Hear(ACPGriffonEvent remoteEvent);
	}
}
