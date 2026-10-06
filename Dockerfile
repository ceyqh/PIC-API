# Etapa de compilació
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiem el projecte
COPY ["WebAplicationAPDemo/WebAplicationAPIRestDemo.csproj", "WebAplicationAPIDemo/"]
RUN dotnet restore "WebAplicationAPDemo/WebAplicationAPIRestDemo.csproj"

# Copiem la resta del codi
COPY . .
WORKDIR "/src/WebAplicationAPIDemo"

# Compilem i publiquem
RUN dotnet publish "WebAplicationAPIRestDemo.csproj" -c Release -o /app/publish

# Etapa final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000
EXPOSE 10000

ENTRYPOINT ["dotnet", "WebAplicationAPIRestDemo.dll"]
