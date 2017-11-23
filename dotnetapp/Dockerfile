#FROM microsoft/dotnet:2.0-sdk
#WORKDIR /app

### copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore -s http://nuget.base.wolfspool.at -s https://api.nuget.org/v3/index.json

### copy and build everything else
#COPY . ./
#RUN dotnet publish -c Release -o out
#ENTRYPOINT ["dotnet", "out/dotnetapp.dll"]

FROM microsoft/dotnet-nightly:2.1-sdk as builder  
 
RUN mkdir -p /root/src/app/dotnetapp
WORKDIR /root/src/app/dotnetapp
 
COPY dotnetapp.csproj . 
#RUN dotnet restore ./dotnetapp.csproj
RUN dotnet restore -s http://nuget.base.wolfspool.at -s https://api.nuget.org/v3/index.json


COPY . .
RUN dotnet publish -c release -o published 

FROM microsoft/dotnet-nightly:2.1-runtime-alpine

WORKDIR /app  
COPY --from=builder /root/src/app/dotnetapp/published .
CMD ["dotnet", "./dotnetapp.dll"] 