FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DesafioPicPay.Api/DesafioPicPay.Api.csproj", "DesafioPicPay.Api/"]
COPY ["DesafioPicPay.Infrastructure/DesafioPicPay.Infrastructure.csproj", "DesafioPicPay.Infrastructure/"]
COPY ["DesafioPicPay.Core/DesafioPicPay.Core.csproj", "DesafioPicPay.Core/"]

#RUN dotnet tool install --global dotnet-ef

RUN dotnet restore "./DesafioPicPay.Infrastructure/DesafioPicPay.Infrastructure.csproj"
RUN dotnet restore "./DesafioPicPay.Api/DesafioPicPay.Api.csproj"

COPY . .
WORKDIR "/src/DesafioPicPay.Api"
RUN dotnet build "./DesafioPicPay.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DesafioPicPay.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app


COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "DesafioPicPay.Api.dll"]