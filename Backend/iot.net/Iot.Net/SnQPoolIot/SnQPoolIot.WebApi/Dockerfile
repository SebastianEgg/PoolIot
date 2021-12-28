#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SnQPoolIot.WebApi/SnQPoolIot.WebApi.csproj", "SnQPoolIot.WebApi/"]
COPY ["SnQPoolIot.Logic/SnQPoolIot.Logic.csproj", "SnQPoolIot.Logic/"]
COPY ["SnQPoolIot.Contracts/SnQPoolIot.Contracts.csproj", "SnQPoolIot.Contracts/"]
COPY ["CommonBase/CommonBase.csproj", "CommonBase/"]
COPY ["SnQPoolIot.Transfer/SnQPoolIot.Transfer.csproj", "SnQPoolIot.Transfer/"]
RUN dotnet restore "SnQPoolIot.WebApi/SnQPoolIot.WebApi.csproj"
COPY . .
WORKDIR "/src/SnQPoolIot.WebApi"
RUN dotnet build "SnQPoolIot.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnQPoolIot.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnQPoolIot.WebApi.dll"]
