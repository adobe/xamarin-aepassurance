# Adobe Experience Platform - Griffon plugin for Xamarin apps

![CI](https://github.com/adobe/xamarin-acpgriffon/workflows/CI/badge.svg)

[![GitHub](https://img.shields.io/github/license/adobe/xamarin-acpgriffon)](https://github.com/adobe/xamarin-acpgriffon/blob/master/LICENSE)

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Running Tests](#running-tests)
- [Sample App](#sample-app)
- [Contributing](#contributing)
- [Licensing](#licensing)

## Prerequisites

Xamarin development requires the installation of [Microsoft Visual Studio](https://visualstudio.microsoft.com/downloads/). An [Apple developer account](https://developer.apple.com/programs/enroll/) and the latest version of Xcode (available from the App Store) are required if you are [building an iOS app](https://docs.microsoft.com/en-us/visualstudio/mac/installation?view=vsmac-2019).

## Installation

**Package Manager Installation**

The ACPGriffon Xamarin NuGet package for Android or iOS can be added to your project by right clicking the *_"Packages"_* folder within the project you are working on then selecting *_"Manage NuGet Packages"_*. In the window that opens, ensure that your selected source is `nuget.org` and search for *_"Adobe.ACP"_*. After selecting the Xamarin AEP SDK packages that are required, click on the *_"Add Packages"_* button. After exiting the "Add Packages" menu, right click the main solution or the "Packages" folder and select "Restore" to ensure the added packages are downloaded.

**Manual installation**

Local ACPGriffon NuGet packages can be created via the included Makefile. If building for the first time, run:

```
make setup
```

followed by:

```
make release
```

The created NuGet packages can be found in the bin directory. This directory can be added as a local nuget source and packages within the directory can be added to a Xamarin project following the steps in the "Package Manager Installation" above.

## Usage
### [Griffon](https://aep-sdks.gitbook.io/docs/beta/project-griffon)
##### Getting Griffon version:

**iOS and Android**

```c#
Console.WriteLine(ACPGriffon.ExtensionVersion());
```

##### Registering the extension with ACPCore:  

  ##### **iOS** and Android

```c#
using Com.Adobe.Marketing.Mobile;

ACPGriffon.RegisterExtension();
ACPCore.Start(null);
```

##### Starting the Griffon session:

**iOS**

```c#
NSUrl url = new NSUrl("acpgriffontestapp://link?adb_validation_sessionid=session_id");
ACPGriffon.StartSession(url);
```

**Android**

```c#
ACPGriffon.StartSession("acpgriffontestapp://link?adb_validation_sessionid=session_id");
```

## Running Tests

iOS and Android unit tests are included within the ACPGriffon binding solution. They must be built from within Visual Studio then manually triggered from the unit test app that is deployed to an iOS or Android device.

## Sample App

A Xamarin Forms sample app is provided in the Xamarin ACPGriffon solution file.

## Contributing

Looking to contribute to this project? Please review our [Contributing guidelines](.github/CONTRIBUTING.md) prior to opening a pull request.  

We look forward to working with you!

## Licensing
This project is licensed under the Apache V2 License. See [LICENSE](LICENSE) for more information.
