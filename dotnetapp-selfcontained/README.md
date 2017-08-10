# .NET Core self-contained application Docker Production Sample

This .NET Core Docker sample demonstrates a best practice pattern for building Docker images for [self-contained .NET Core applications](https://docs.microsoft.com/dotnet/core/deploying/). This is the type of image you would want to use in production if you want the smallest possible container and do not see a [benefit from sharing .NET base images between containers](https://docs.docker.com/engine/userguide/storagedriver/imagesandcontainers/) (you would still potentially share lower Docker layers). The sample works with both Linux and Windows containers.

This [sample Dockerfile for Linux](Dockerfile) creates an .NET Core application image based off the [.NET Core Runtime Dependencies Docker base image](https://hub.docker.com/r/microsoft/dotnet/), which is based on [Debian 9 (Stretch) base image](https://hub.docker.com/_/debian/).

This [sample Dockerfile for Windows Nanoserver](Dockerfile.nano) creates an .NET Core application image based off the [Windows Nanoserver base image](https://hub.docker.com/r/microsoft/nanoserver/).

The sample uses the [Docker multi-stage build feature](https://github.com/dotnet/announcements/issues/18) for Linux and Windows to build the sample in a container based on the larger [.NET Core SDK Docker base image](https://hub.docker.com/r/microsoft/dotnet/) and then copies the final build result into a smaller Docker image based on the appropriate base image mentioned above (based whether you are using Windows or Linux containers).

This sample requires [Docker 17.05](https://docs.docker.com/release-notes/docker-ce/#17050-ce-2017-05-04) or later of the [Docker client](https://www.docker.com/products/docker). You need the latest Windows 10 or Windows Server 2016 to use [Windows containers](http://aka.ms/windowscontainers). The instructions assume you have the [Git](https://git-scm.com/downloads) client installed.

The sample uses an experimental linker for removing code that your final application does not need. The final Docker images are singificantly smaller. The linker is not required and can be removed from the sample or disabled on the commandline if you do not want to use it.

## Getting the sample

The easiest way to get the sample is by cloning the samples repository with git, using the following instructions. You can also just download the repository (it is small) as a zip from the [.NET Core Docker samples](https://github.com/dotnet/dotnet-docker-samples/) respository.

```console
git clone https://github.com/dotnet/dotnet-docker-samples/
```

## Build and run the sample with Docker for Linux containers

You can build and run the sample in Docker using Linux containers using the following commands. They assume that you are in the root of the repository.

```console
cd dotnetapp-selfcontained
docker build -t dotnetapp .
docker run --rm dotnetapp Hello .NET Core from Docker
```

## Build and run the sample with Docker for Windows containers

You can build and run the sample in Docker using Windows containers using the following commands. The instructions assume that you are in the root of the repository.

```console
cd dotnetapp-selfcontained
docker build -t dotnetapp -f Dockerfile.nano .
docker run dotnetapp Hello .NET Core from Docker
```

## Build, Run and Publish the sample locally

You can build and run the sample locally with the [.NET Core 2.0 SDK](https://www.microsoft.com/net/download/core) using the following instructions. The instructions assume that you are in the root of the repository.

```console
cd dotnetapp-selfcontained
dotnet run
```

### Publishing on Windows

You can publish an application locally that is ready to deploy to production using the following commands.

```console
dotnet publish -c release -r win-x64 -o published-selfcontained-win-x64
published-selfcontained-win-x64\dotnetapp.exe
```

Note: The `-c release` argument builds the application in release mode (the default is debug mode). See the [dotnet run reference](https://docs.microsoft.com/dotnet/core/tools/dotnet-run) for more information on commandline parameters.

### Publishing on Linux

You can publish an application locally that is ready to deploy to production using the following commands.

```console
dotnet publish -c release -r linux-x64 -o selfcontained-linux-x64
./selfcontained-linux-x64/dotnetapp
```

Note: The `-r` argument specifies which runtime target the application should be built and published for. See the [dotnet run reference](https://docs.microsoft.com/dotnet/core/tools/dotnet-run) for more information on commandline parameters.

Note: You can publish for other architectures with .NET Core. For example, you can publish for `linux-x64` on Windows or macOS. You can use the `linux-arm` runtime ID you are targeting the Raspberry Pi on Linux, for example.

### Publishing on macOS

You can publish an application locally that is ready to deploy to production using the following commands.

```console
dotnet publish -c release -r osx-x64 -o selfcontained-osx-x64
./selfcontained-osx-x64/dotnetapp
```

## Docker Images used in this sample

The following Docker images are used in this sample

* [microsoft/dotnet:2.0-sdk](https://hub.docker.com/r/microsoft/dotnet)
* [microsoft/dotnet:2.0-runtime-deps](https://hub.docker.com/r/microsoft/dotnet)
* [microsoft/nanoserver](https://hub.docker.com/r/microsoft/nanoserver)

## Related Resources

* [Self-contained .NET Core applications](https://docs.microsoft.com/dotnet/core/deploying/)
* [ASP.NET Core Production Docker sample](../aspnetapp/README.md)
* [.NET Core Production Docker sample](../dotnetapp-prod/README.md)
* [.NET Core Docker samples](../README.md)
* [.NET Framework Docker samples](https://github.com/Microsoft/dotnet-framework-docker-samples)
