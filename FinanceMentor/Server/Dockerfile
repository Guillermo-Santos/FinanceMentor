#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["FinanceMentor/Server/FinanceMentor.Server.csproj", "FinanceMentor/Server/"]
COPY ["FinanceMentor/Client/FinanceMentor.Client.csproj", "FinanceMentor/Client/"]
COPY ["FinanceMentor/Shared/FinanceMentor.Shared.csproj", "FinanceMentor/Shared/"]
RUN dotnet restore "FinanceMentor/Server/FinanceMentor.Server.csproj"
COPY . .
WORKDIR "/src/FinanceMentor/Server"
RUN dotnet build "FinanceMentor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FinanceMentor.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FinanceMentor.Server.dll"]
