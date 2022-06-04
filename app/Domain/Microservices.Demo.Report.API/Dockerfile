#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["app/Domain/Microservices.Demo.Report.API/Microservices.Demo.Report.API.csproj", "app/Domain/Microservices.Demo.Report.API/"]
RUN dotnet restore "app/Domain/Microservices.Demo.Report.API/Microservices.Demo.Report.API.csproj"
COPY . .
WORKDIR "/src/app/Domain/Microservices.Demo.Report.API"
RUN dotnet build "Microservices.Demo.Report.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservices.Demo.Report.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservices.Demo.Report.API.dll"]