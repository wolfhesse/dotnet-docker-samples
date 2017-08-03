# .NET Core Docker Production Sample

This .NET Core Docker sample demonstrates how to use .NET Core apps in Docker. It works with both Linux and Windows containers.

The [sample Dockerfile](Dockerfile) creates an .NET Core application container based off of the [.NET Core Runtime Docker base image](https://hub.docker.com/r/microsoft/dotnet/). This is the type of container you would want to use in production. It uses the [Docker multi-stage build feature](https://github.com/dotnet/announcements/issues/18) to build the sample with the larger [.NET Core SDK Docker base image](https://hub.docker.com/r/microsoft/dotnet/) and then copies the final build result into a Docker image based on the smaller [.NET Core Docker Runtime base image](https://hub.docker.com/r/microsoft/dotnet/). The SDK image contains tools that are required to build applications while the runtime image does not.

This sample requires [Docker 17.05](https://docs.docker.com/release-notes/docker-ce/#17050-ce-2017-05-04) or later of the [Docker client](https://www.docker.com/products/docker). You need the latest Windows 10 or Windows Server 2016 to use [Windows containers](http://aka.ms/windowscontainers). The instructions assume you have the [Git](https://git-scm.com/downloads) client installed.

## Getting the sample

The easiest way to get the sample is by cloning the samples repository with git, using the following instructions. You can also just download the repository (it is small) as a zip from the [.NET Core Docker samples](https://github.com/dotnet/dotnet-docker-samples/) respository.

```console
git clone https://github.com/dotnet/dotnet-docker-samples/
```

## Build and run the sample locally

You can build and run the sample locally with the [.NET Core 2.0 SDK](https://www.microsoft.com/net/download/core) using the following instructions. The instructions assume that you are in the root of the repository.

```console
cd dotnetapp-prod
dotnet run -c release Hello .NET Core
```

Note: The `-c release` argument builds the application in release mode (the default is debug mode). See the [dotnet run reference](https://docs.microsoft.com/dotnet/core/tools/dotnet-run) for more information on commandline parameters.

## Build and run the sample with Docker

You can build and run the sample in Docker with the following commands. The instructions assume that you are in the root of the repository.

```console
cd dotnetapp-prod
docker build -t dotnetapp .
docker run dotnetapp Hello .NET Core from Docker
```

Note: The instructions above work for both Linux and Windows containers. The .NET Core docker images use [multi-arch tags](https://github.com/dotnet/announcements/issues/14), which abstract away different operating system choices for most use-cases.

## Docker Images used in this sample

The following Docker images are used in this sample

* [microsoft/dotnet:2.0-sdk](https://hub.docker.com/r/microsoft/dotnet)
* [microsoft/dotnet:2.0-runtime](https://hub.docker.com/r/microsoft/dotnet)

## Related Resources

* [ASP.NET Core Production Docker sample](../aspnetapp/README.md)
* [.NET Core Docker samples](../README.md)
* [.NET Framework Docker samples](https://github.com/Microsoft/dotnet-framework-docker-samples)
