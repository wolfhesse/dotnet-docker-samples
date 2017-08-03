# .NET Core self-contained application Docker Production Sample

This .NET Core Docker sample demonstrates how to produce [self-contained applications](https://docs.microsoft.com/dotnet/core/deploying/) with Docker. It works with both Linux and Windows containers.

The [sample Dockerfile](Dockerfile) creates an .NET Core application container based off of the [.NET Core Runtime Dependencies Docker base image](https://hub.docker.com/r/microsoft/dotnet/). This is the type of container you would want to use in production if you want the smallest possible container and do not see a [benefit from sharing base images between containers](https://docs.docker.com/engine/userguide/storagedriver/imagesandcontainers/). It uses the [Docker multi-stage build feature](https://github.com/dotnet/announcements/issues/18) to build the sample with the larger [.NET Core SDK Docker base image](https://hub.docker.com/r/microsoft/dotnet/) and then copies the final build result into a Docker image based on the smaller [.NET Core Docker Runtime Depedendencies base image](https://hub.docker.com/r/microsoft/dotnet/) in the case of Linux, and the [Windows Server 2016 Nano Server base OS image](https://hub.docker.com/r/microsoft/nanoserver/) in the case of Windows.

This sample requires [Docker 17.05](https://docs.docker.com/release-notes/docker-ce/#17050-ce-2017-05-04) or later of the [Docker client](https://www.docker.com/products/docker). You need the latest Windows 10 or Windows Server 2016 to use [Windows containers](http://aka.ms/windowscontainers). The instructions assume you have the [Git](https://git-scm.com/downloads) client installed.

## Getting the sample

The easiest way to get the sample is by cloning the samples repository with git, using the following instructions. You can also just download the repository (it is small) as a zip from the [.NET Core Docker samples](https://github.com/dotnet/dotnet-docker-samples/) respository.

```console
git clone https://github.com/dotnet/dotnet-docker-samples/
```

## Build and run the sample locally

You can build and run the sample locally with the [.NET Core 2.0 SDK](https://www.microsoft.com/net/download/core) using the following instructions. The instructions assume that you are in the root of the repository.

```console
cd dotnetapp-selfcontained
dotnet publish -c Release -o out
./out/dotnetapp Hello .NET Core
```

Note: The `-c release` argument builds the application in release mode (the default is debug mode). See the [dotnet run reference](https://docs.microsoft.com/dotnet/core/tools/dotnet-run) for more information on commandline parameters.

## Build and run the sample with Docker for Linux containers

You can build and run the sample in Docker using Linux containers with the following commands. They assume that you are in the root of the repository.

```console
cd dotnetapp-selfcontained
docker build -t dotnetapp .
docker run dotnetapp Hello .NET Core from Docker
```

## Build and run the sample with Docker for Windows containers

You can build and run the sample in Docker using Windows containers with the following commands. The instructions assume that you are in the root of the repository.

```console
cd dotnetapp-selfcontained
docker build -t dotnetapp -f Dockerfile.nano .
docker run dotnetapp Hello .NET Core from Docker
```

## Docker Images used in this sample

The following Docker images are used in this sample

* [microsoft/dotnet:2.0-sdk](https://hub.docker.com/r/microsoft/dotnet)
* [microsoft/dotnet:2.0-runtime-deps](https://hub.docker.com/r/microsoft/dotnet)

## Related Resources

* [Self-contained .NET Core applications](https://docs.microsoft.com/dotnet/core/deploying/)
* [ASP.NET Core Production Docker sample](https://github.com/dotnet/dotnet-docker-samples/blob/master/aspnetapp/README.md)
* [.NET Core Production Docker sample](https://github.com/dotnet/dotnet-docker-samples/blob/master/dotnetapp-prod/README.md)
* [.NET Core Docker samples](https://github.com/dotnet/dotnet-docker-samples/blob/master/README.md)
* [.NET Framework Docker samples](https://github.com/Microsoft/dotnet-framework-docker-samples)
