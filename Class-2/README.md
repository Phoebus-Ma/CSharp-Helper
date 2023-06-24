
## Cross-platform

There are cross-platform applications in this folder,
but I only verified them on Windows and Ubuntu.


## Installation

Install the SDK (which includes the runtime) if you want to develop .NET apps.
Or, If you only need to run apps, install the Runtime.
if you are installing the Runtime, we suggest you install the ASP.NET Core Runtime as it includes both
.NET and ASP.NET Core runtimes.

Use the `dotnet --list-sdks` and `dotnet --list-runtimes` commands to see which version are installed.


On Ubuntu 22:

- Install the SDK

```bash
sudo apt install dotnet-sdk-6.0
```

- Install the Runtime


The ASP.NET Core Runtime as it includes both .NET and ASP.NET Core runtimes.

```bash
sudo apt install aspnetcore-runtime-6.0
```

of course, you can install the .NET Runtime, which doesn't include ASP.NET Core support.

```bash
sudo apt install dotnet-runtime-6.0
```

For more information, see [Install .NET on Ubuntu 22.04](https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu-2204) .
