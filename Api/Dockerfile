# Build Stage

# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /PadelIT
RUN ls 
COPY PadelIT/*.csproj .
RUN dotnet restore
COPY PadelIT .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80

ENTRYPOINT ["dotnet", "PadelIT.dll"]
