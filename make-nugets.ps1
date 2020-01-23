# make-nugets.ps1
#
# Copyright (c) 2020 Kano Computing Ltd.
# License: https://opensource.org/licenses/MIT
#
# A simple script to build the NuGet packages for all libraries in this
# project. Requires nuget.exe from https://www.nuget.org/downloads


Set-PSDebug -Trace 1

function Build-Verify {
	param([string]$Spec, [string]$OutputDir)

	nuget pack $Spec -OutputDirectory $OutputDir -NonInteractive -Verbosity detailed
	nuget verify -All $OutputDir\*.nupkg
}

Build-Verify `
	AppUpdate\AppUpdate.nuspec `
	AppUpdate\bin\Release\Package

Build-Verify `
	KanoPlatformDetection\KanoPlatformDetection.nuspec `
	KanoPlatformDetection\bin\Release\Package

Build-Verify `
	PackageManagement\PackageManagement.nuspec `
	PackageManagement\bin\Release\Package

Build-Verify `
	SystemNotifications\SystemNotifications.nuspec `
	SystemNotifications\bin\Release\Package

Set-PSDebug -Trace 0
