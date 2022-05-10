FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/
COPY Services/Basket/Services.Basket/*.csproj Services/Basket/Services.Basket/
RUN dotnet restore Services/Basket/Services.Basket/*.csproj
COPY . .
RUN dotnet publish Services/Basket/Services.Basket/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","Services.Basket.dll"]

