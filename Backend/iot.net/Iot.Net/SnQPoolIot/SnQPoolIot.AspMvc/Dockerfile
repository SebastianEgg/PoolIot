#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SnQPoolIot.AspMvc/SnQPoolIot.AspMvc.csproj", "SnQPoolIot.AspMvc/"]
COPY ["SnQPoolIot.Adapters/SnQPoolIot.Adapters.csproj", "SnQPoolIot.Adapters/"]
COPY ["SnQPoolIot.Logic/SnQPoolIot.Logic.csproj", "SnQPoolIot.Logic/"]
COPY ["SnQPoolIot.Contracts/SnQPoolIot.Contracts.csproj", "SnQPoolIot.Contracts/"]
COPY ["CommonBase/CommonBase.csproj", "CommonBase/"]
COPY ["SnQPoolIot.Transfer/SnQPoolIot.Transfer.csproj", "SnQPoolIot.Transfer/"]
RUN dotnet restore "SnQPoolIot.AspMvc/SnQPoolIot.AspMvc.csproj"
COPY . .
WORKDIR "/src/SnQPoolIot.AspMvc"
RUN dotnet build "SnQPoolIot.AspMvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnQPoolIot.AspMvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnQPoolIot.AspMvc.dll"]
