# ASP.NET Core Docker Sample

This ASP.NET Core Docker sample demonstrates how to use ASP.NET Core apps in Docker. It works with both Linux and Windows containers.

The [sample Dockerfile](Dockerfile) creates an ASP.NET Core application container based off of the [ASP.NET Core Runtime Docker base image](https://hub.docker.com/r/microsoft/aspnetcore/). It uses the [Docker multi-stage build feature](https://github.com/dotnet/announcements/issues/18) to build the sample with the larger [ASP.NET Core Build Docker base image](https://hub.docker.com/r/microsoft/aspnetcore-build/) and then copy the final build result into a Docker image based on smaller [ASP.NET Core Docker Runtime base image](https://hub.docker.com/r/microsoft/aspnetcore/). The build image contains tools that are required to build applications while the runtime image does not.

This sample requires [Docker 17.05](https://docs.docker.com/release-notes/docker-ce/#17050-ce-2017-05-04) or later of the [Docker client](https://www.docker.com/products/docker). You need the latest Windows 10 or Windows Server 2016 to use [Windows containers](http://aka.ms/windowscontainers). The instructions assume you have the [Git](https://git-scm.com/downloads) client installed.

## Getting the sample

The easiest way to get the sample is by cloning the samples repository with git, using the following instructions. You can also just download the repository (it is small) as a zip from the [.NET Core Docker samples](https://github.com/dotnet/dotnet-docker-samples/) respository.

```console
git clone https://github.com/dotnet/dotnet-docker-samples/
```

## Build and run the sample locally

You can build and run the sample locally with the [.NET Core 2.0 SDK](https://www.microsoft.com/net/download/core) using the following instructions. They assume that you are in the root of the repository.

```console
cd aspnetapp
docker run -c release
```

After the application starts, visit `http://localhost:8000` in your web browser.

Note: The `-c release` argument builds the application in release mode. See the [dotnet run reference](https://docs.microsoft.com/dotnet/core/tools/dotnet-run) for more information on commandline paramaters.

## Build and run the sample with Docker for Linux containers

You can build and run the sample in Docker using Linux containers with the following commands. They assume that you are in the root of the repository.

```console
cd aspnetapp
docker build -t aspnetapp .
docker run -it --rm -p 8000:80 aspnetapp
```

After the application starts, visit `http://localhost:8000` in your web browser.

Note: The `-p` argument maps port 8000 on you local machine to port 80 in the container (the form is `host:container`). See the [Docker run reference](https://docs.docker.com/engine/reference/commandline/run/) for more information on commandline paramaters.

## Build and run the sample with Docker for Windows containers

You can build and run the sample in Docker using Windows containers with the following commands. They assume that you are in the root of the repository.

```console
cd aspnetapp
docker build -t aspnetapp .
docker run -d --rm aspnetapp
```

You must navigate to the container IP (as opposed to http://localhost) in your browser directly when using Windows containers. You can get the IP address of your container with the following steps:

1. Run `docker ps` to get the hash for the sample container.
1. Run `docker exec HASH ipconfig` where `HASH` is replaced with your container hash.
1. Copy the container IP address and paste into your browser (for example, 172.29.245.43).

See the example below of how to use Docker commands to get the IP address of a container.

```console
C:\git\dotnet-docker-samples\aspnetapp>docker ps
CONTAINER ID        IMAGE               COMMAND                  CREATED              STATUS              PORTS                  NAMES
bb9eb9446863        aspnetapp           "dotnet aspnetapp.dll"   About a minute ago   Up About a minute   0.0.0.0:8000->80/tcp   gifted_euclid

C:\git\dotnet-docker-samples\aspnetapp>docker exec bb9eb9446863 ipconfig

Windows IP Configuration


Ethernet adapter Ethernet:

   Connection-specific DNS Suffix  . : contoso.com
   Link-local IPv6 Address . . . . . : fe80::1967:6598:124:cfa3%4
   IPv4 Address. . . . . . . . . . . : 172.29.245.43
   Subnet Mask . . . . . . . . . . . : 255.255.240.0
   Default Gateway . . . . . . . . . : 172.29.240.1
```

Note: `Docker exec` runs a new command in a running command. See the [Docker exec reference](https://docs.docker.com/engine/reference/commandline/exec/) for more information on commandline paramaters.

## Docker Images used in this sample

The following Docker images are used in this sample

* [microsoft/aspnetcore-build:2.0](https://hub.docker.com/r/microsoft/aspnetcore-build)
* [microsoft/aspnetcore:2.0](https://hub.docker.com/r/microsoft/aspnetcore/)

## Related Resources

* [ASP.NET Core Getting Started Tutorials](https://www.asp.net/get-started)
* [.NET Framework Docker samples](https://github.com/Microsoft/dotnet-framework-docker-samples)
