# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY *.sln .
#COPY Directory.Packages.props ./ToDoListCrossPlatform.Browser/


COPY ToDoListCrossPlatform.Browser/*.csproj ./ToDoListCrossPlatform.Browser/
COPY ToDoListCrossPlatform.iOS/*.csproj ./ToDoListCrossPlatform.iOS/
COPY ToDoListCrossPlatform.Desktop/*.csproj ./ToDoListCrossPlatform.Desktop/
COPY ToDoListCrossPlatform.Android/*.csproj ./ToDoListCrossPlatform.Android/
COPY ToDoListCrossPlatform/*.csproj ./ToDoListCrossPlatform/
run dotnet workload restore
COPY Directory.Packages.props .

RUN echo "HI"
# copy everything else and build app
COPY ToDoListCrossPlatform/. ./ToDoListCrossPlatform/
COPY ToDoListCrossPlatform.Browser/. ./ToDoListCrossPlatform.Browser/
WORKDIR /source/ToDoListCrossPlatform.Browser
RUN dotnet publish -c release -o /app

# final stage/image
FROM nginx
WORKDIR /app
COPY --from=build /app/wwwroot /usr/share/nginx/html
