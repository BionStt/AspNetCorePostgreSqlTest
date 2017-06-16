FROM microsoft/dotnet:1.1.1-sdk

MAINTAINER Dan Wahlin, Shayne Boyer

ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_URLS=http://*:5000

WORKDIR /var/www/AspNetCorePostgreSql

CMD ["/bin/bash", "-c", "dotnet restore && dotnet ef database update && dotnet run"]