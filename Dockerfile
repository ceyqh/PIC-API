FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["WebApplicationAPIRestDemo.csproj", "./"]

RUN dotnet restore "WebApplicationAPIRestDemo.csproj"

COPY . .

RUN dotnet publish "WebApplicationAPIRestDemo.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:10000

EXPOSE 10000

ENTRYPOINT ["dotnet", "WebApplicationAPIRestDemo.dll"]