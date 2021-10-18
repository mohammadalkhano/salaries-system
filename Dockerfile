#Use commands from Rickard to install docker on VM.
FROM ubuntu:20.04

RUN apt-get -y update

RUN apt-get -y install nginx
# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /salaries-system

# copy csproj and restore as distinct layers
COPY *.sln .
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build app
COPY . ./
WORKDIR /salaries-system/
RUN dotnet publish -c release -o /salaries-system --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /salaries-system
COPY --from=build-env/salaries-system ./salaries-system /salaries-system/
ENTRYPOINT ["dotnet", "cicd-1-salaries.dll"]

#lstat /home/runner/work/salaries-system/salaries-system/Dockerfile: no such #file or directory ===> Solved by renameing the file