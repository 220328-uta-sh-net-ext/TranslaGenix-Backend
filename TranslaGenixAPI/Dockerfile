#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TranslaGenixAPI/TranslaGenixAPI.csproj", "./"]
COPY ["DL/DL.csproj", "DL/"]
COPY ["Models/Models.csproj", "Models/"]
RUN dotnet restore "./TranslaGenixAPI.csproj"
COPY . .
WORKDIR "/src/TranslaGenixAPI"
RUN dotnet build "TranslaGenixAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TranslaGenixAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TranslaGenixAPI.dll"]