FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/
COPY Services/Catalog/Services.Catalog/*.csproj Services/Catalog/Services.Catalog/
RUN dotnet restore Services/Catalog/Services.Catalog/*.csproj
COPY . .
RUN dotnet publish Services/Catalog/Services.Catalog/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","Services.Catalog.dll"]

