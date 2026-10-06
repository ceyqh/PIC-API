# Etapa de compilación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copiar el proyecto
COPY ["WebApplicationAPIRestDemo.csproj", "./"]

# Restaurar dependencias
RUN dotnet restore "WebApplicationAPIRestDemo.csproj"

# Copiar el resto del código
COPY . .

# Compilar y publicar
RUN dotnet publish "WebApplicationAPIRestDemo.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore


# Etapa final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "WebApplicationAPIRestDemo.dll"]