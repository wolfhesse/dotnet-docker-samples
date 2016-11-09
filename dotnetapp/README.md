# Supported tags and respective `Dockerfile` links

-       [`dotnetapp`, `latest` (*dotnetapp/Dockerfile*)](https://github.com/dotnet/dotnet-docker-samples/blob/dockerhub/dotnetapp/Dockerfile)
-       [`dotnetapp-nanoserver` (*dotnetapp/Dockerfile.nano*)](https://github.com/dotnet/dotnet-docker-samples/blob/dockerhub/dotnetapp/Dockerfile.nano)

For more information about these images and their history, please see [the relevant Dockerfile (`dotnet/dotnet-docker-samples`)](https://github.com/dotnet/dotnet-docker-samples/search?utf8=%E2%9C%93&q=FROM&type=Code). These images are updated via [pull requests to the `dotnet/dotnet-docker-samples` GitHub repo](https://github.com/dotnet/dotnet-docker-samples/pulls?utf8=%E2%9C%93&q=).

[![Downloads from Docker Hub](https://img.shields.io/docker/pulls/microsoft/dotnet-samples.svg)](https://hub.docker.com/r/microsoft/dotnet-samples)
[![Stars on Docker Hub](https://img.shields.io/docker/stars/microsoft/dotnet-samples.svg)](https://hub.docker.com/r/microsoft/dotnet-samples)

# .NET Core Docker Samples

This repo contains samples (one so far) that demonstrate various .NET Core Docker configurations.

You can see the source for these samples at [dotnet/dotnet-docker-samples](https://github.com/dotnet/dotnet-docker-samples/tree/dockerhub) on GitHub.

# What is .NET Core?

.NET Core is a general purpose development platform maintained by Microsoft and the .NET community on [GitHub](https://github.com/dotnet/core). It is cross-platform, supporting Windows, macOS and Linux, and can be used in device, cloud, and embedded/IoT scenarios. 

.NET has several capabilities that make development easier, including automatic memory management, (runtime) generic types, reflection, asynchrony, concurrency, and native interop. Millions of developers take advantage of these capabilities to efficiently build high-quality applications.

You can use C# to write .NET Core apps. C# is simple, powerful, type-safe, and object-oriented while retaining the expressiveness and elegance of C-style languages. Anyone familiar with C and similar languages will find it straightforward to write in C#.

[.NET Core](https://github.com/dotnet/core) is open source (MIT and Apache 2 licenses) and was contributed to the [.NET Foundation](http://dotnetfoundation.org) by Microsoft in 2014. It can be freely adopted by individuals and companies, including for personal, academic or commercial purposes. Multiple companies use .NET Core as part of apps, tools, new platforms and hosting services.

> https://docs.microsoft.com/dotnet/articles/core/

![logo](https://avatars0.githubusercontent.com/u/9141961?v=3&amp;s=100)

# How to use these Images

## Run a sample .NET Core application within a container

The dotnetapp image (Linux image) is a sample application that depends on the [.NET Core Runtime image](https://hub.docker.com/r/microsoft/dotnet). You can run it in a container by running the following command.

```console
docker run microsoft/dotnet-samples
```

## Image variants

The `microsoft/dotnet-sample` images come in one flavor.

### `microsoft/dotnet-samples:dotnetapp`

This image demonstrates the minimal use of the [.NET Core Runtime image](https://hub.docker.com/r/microsoft/dotnet). It is not intended to be used as the base of another image, but purely used for demonstration purposes.

## Related Repos

See the following related repos for other application types:

- [microsoft/dotnet](https://hub.docker.com/r/microsoft/dotnet/) for .NET Core images.
- [microsoft/aspnetcore](https://hub.docker.com/r/microsoft/aspnetcore/) for ASP.NET Core images.
- [microsoft/aspnet](https://hub.docker.com/r/microsoft/aspnet/) for ASP.NET Web Forms and MVC images.
- [microsoft/dotnet-framework](https://hub.docker.com/r/microsoft/dotnet-framework/) for .NET Framework images (for web applications, see microsoft/aspnet).

# License

View [license information](https://www.microsoft.com/net/dotnet_library_license.htm) for the software contained in this image. 

.NET Core source code is separately licensed as [MIT LICENSE](https://github.com/dotnet/core/blob/master/LICENSE).

# Supported Docker versions

This image is officially supported on Docker version 1.12.2.

Please see [the Docker installation documentation](https://docs.docker.com/installation/) for details on how to upgrade your Docker daemon.

# User Feedback

## Issues

If you have any problems with or questions about this image, please contact us through a [GitHub issue](https://github.com/dotnet/dotnet-docker-samples/issues).

## Contributing

You are invited to contribute new features, fixes, or updates, large or small; we are always thrilled to receive pull requests, and do our best to process them as fast as we can.

## Documentation

You can read documentation for .NET Core, including Docker usage in the [.NET Core docs](https://docs.microsoft.com/dotnet/articles/core/). The docs are [open source on GitHub](https://github.com/dotnet/core-docs). Contributions are welcome!
