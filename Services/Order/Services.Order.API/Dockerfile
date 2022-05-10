FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/

COPY Services/Order/Services.Order.API/*.csproj Services/Order/Services.Order.API/

COPY Services/Order/Services.Order.Application/*.csproj Services/Order/Services.Order.Application/

COPY Services/Order/Services.Order.Domain/*.csproj Services/Order/Services.Order.Domain/

COPY Services/Order/Services.Order.Domain.Core/*.csproj Services/Order/Services.Order.Domain.Core/

COPY Services/Order/Services.Order.Infrastructure/*.csproj Services/Order/Services.Order.Infrastructure/

RUN dotnet restore Services/Order/Services.Order.API/*.csproj
COPY . .
RUN dotnet publish Services/Order/Services.Order.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","Services.Order.API.dll"]
