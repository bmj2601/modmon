# modmon
Modular monolith

**.net SDK 10**
On Windows, download and install it from the official .NET download page (select the SDK for your architecture). Alternatively, use a package manager like winget install Microsoft.DotNet.SDK.10 if available. After installation, verify with dotnet --version (should show 10.x.x).

**Dependencies**
Run ´´´dotnet restore´´´ in the project root to install NuGet packages (managed via Directory.Packages.props).

**Run Tests**
Run ´´´dotnet test´´´ in the project root to execute tests in modmon.Tests.

**Run Console App**
Run ´´´dotnet run --project modmon.Console´´´ in the project root to start the console application.