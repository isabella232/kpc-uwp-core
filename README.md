# uwp-utils

A collection of [Universal Windows Platform](https://docs.microsoft.com/en-us/windows/uwp/get-started/universal-application-platform-guide)
(UWP) libraries used in applications for [Kano PC](https://kano.me/uk/store/products/kano-pc).

### NuGet Packaging

Each library is packaged with NuGet and published on [nuget.org](https://nuget.org)
under the MIT license. This means that you can make use of the default
Visual Studio package source to install libraries for your UWP app.

### (Temporary) NuGet Builds

For the time being, the packages are built and uploaded manually but rest 
assured - an automated pipeline is on its way.

Do to this, first you'll need the [nuget.exe](https://www.nuget.org/downloads) 
downloaded. You'll then built each project with a Release configuration.
Lastly, run the `make-nugets.ps1` to build each package individually. All 
that is left is to then login to nuget.org and upload the packages
individually.
