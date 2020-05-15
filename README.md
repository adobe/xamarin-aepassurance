# Adobe Experience Platform - Griffon plugin for Xamarin apps

![CI](https://github.com/adobe/xamarin-acpgriffon/workflows/CI%20on%20push%20and%20pull/badge.svg)

[![GitHub](https://img.shields.io/github/license/adobe/xamarin-acpgriffon)](https://github.com/adobe/xamarin-acpgriffon/blob/master/LICENSE)

- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Usage](#usage)
- [Running Tests](#running-tests)
- [Sample App](#sample-app)
- [Contributing](#contributing)
- [Licensing](#licensing)

## Prerequisites

Xamarin development requires the installation of [Microsoft Visual Studio](https://visualstudio.microsoft.com/downloads/). An Apple developer account and the latest version of Xcode (available from the App Store) are required if you are [building an iOS app](https://docs.microsoft.com/en-us/visualstudio/mac/installation?view=vsmac-2019).

## Installation

# TODO (update after NuGet package is available on nuget.org)

**Package Manager Installation**

TODO

**Manual installation**

A local ACPGriffon NuGet package can be created via the included Makefile. If building for the first time, run:

```
make setup
```

followed by:

```
make release
```

The created NuGet packages can be found in the `bin` directory and can be added as a reference to a Xamarin project.

## Usage
### [Griffon](https://aep-sdks.gitbook.io/docs/beta/project-griffon)

The following usage instructions assume [Xamarin Forms](https://dotnet.microsoft.com/apps/xamarin/xamarin-forms) is being used to develop a multiplatform mobile app.

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

iOS and Android unit tests are included within the ACPGriffon binding solution. Currently they must be built from within Visual Studio then manually triggered from the unit test app that is deployed to an iOS or Android device.

## Sample App

A Xamarin Forms sample app is provided in the Xamarin ACPGriffon solution file.

## Contributing

Looking to contribute to this project? Please review our [Contributing guidelines](.github/CONTRIBUTING.md) prior to opening a pull request.  

We look forward to working with you!

## Licensing
This project is licensed under the Apache V2 License. See [LICENSE](LICENSE) for more information.
