# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
COPY ToDoListCrossPlatform.Browser/*.csproj ./ToDoListCrossPlatform.Browser/
run dotnet workload restore
RUN dotnet restore

# copy everything else and build app
COPY ToDoListCrossPlatform.Browser/. ./ToDoListCrossPlatform.Browser/
WORKDIR /source/ToDoListCrossPlatform.Browser
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "ToDoListCrossPlatform.Browser.dll"]