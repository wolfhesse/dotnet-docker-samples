FROM microsoft/dotnet:2.2-sdk as builder  
 
RUN mkdir -p /root/src/app/dotnetapp
WORKDIR /root/src/app/dotnetapp
 
COPY AseFrameworkApp.csproj . 
#RUN dotnet restore ./dotnetapp.csproj
RUN dotnet restore -s http://nuget.base.wolfspool.at -s https://api.nuget.org/v3/index.json


COPY . .
RUN dotnet publish -c release -o published 

FROM microsoft/dotnet:2.2-runtime

WORKDIR /app  
COPY --from=builder /root/src/app/dotnetapp/published .
CMD ["dotnet", "./AseFrameworkApp.dll"] 