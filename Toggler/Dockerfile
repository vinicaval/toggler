FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["Toggler/Toggler.csproj", "Toggler/"]
COPY ["Toggler.Core/Toggler.Core.csproj", "Toggler.Core/"]
RUN dotnet restore "Toggler/Toggler.csproj"
COPY . .
WORKDIR "/src/Toggler"
RUN dotnet build "Toggler.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Toggler.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Toggler.dll"]