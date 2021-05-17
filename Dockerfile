FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers

## There are two projects in sln file MusicAnalyser and MusicAnalyser.Tests 
COPY *.sln .
COPY MusicAnalyser/*.csproj ./MusicAnalyser/
## Without this line the project crashes because it cannot find the needed files to do a dotnet restore for the MusicAnalyser.Tests
COPY MusicAnalyser.Tests/*.csproj ./MusicAnalyser.Tests/
## 
RUN dotnet restore

# copy everything else and build app
COPY MusicAnalyser/. ./MusicAnalyser/
WORKDIR /source/MusicAnalyser

## Could try doing this in a different dir. 
### Maybe there is no need for the path to be so complicated?? 
CMD 'mkdir' '-p' '/bin/release/net5.0/publish' 
###
RUN dotnet publish -c release -o /bin/release/net5.0/publish --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /bin/release/net5.0/publish ./ 
ENV ASPNETCORE_URLS=http://+:44371  
ENTRYPOINT ["dotnet", "MusicAnalyser.dll"]