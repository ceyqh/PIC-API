# Etapa de compilació
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiem el projecte
COPY ["WebApplicationAPIDemo/WebApplicationAPIDemo.csproj", "WebApplicationAPIDemo/"]
RUN dotnet restore "WebApplicationAPIDemo/WebApplicationAPIDemo.csproj"

# Copiem la resta del codi
COPY . .
WORKDIR "/src/WebApplicationAPIDemo"

# Compilem i publiquem
RUN dotnet publish "WebApplicationAPIDemo.csproj" -c Release -o /app/publish

# Etapa final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "WebApplicationAPIDemo.dll"]
