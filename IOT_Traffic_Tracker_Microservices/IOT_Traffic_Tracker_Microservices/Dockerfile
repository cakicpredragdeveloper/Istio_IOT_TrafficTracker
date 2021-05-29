#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["IOT_Traffic_Tracker_Microservices/Sensor_Device_Service.csproj", "IOT_Traffic_Tracker_Microservices/"]
RUN dotnet restore "IOT_Traffic_Tracker_Microservices/Sensor_Device_Service.csproj"
COPY . .
WORKDIR "/src/IOT_Traffic_Tracker_Microservices"
RUN dotnet build "Sensor_Device_Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sensor_Device_Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sensor_Device_Service.dll"]
