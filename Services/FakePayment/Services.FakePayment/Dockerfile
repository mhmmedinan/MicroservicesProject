FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/Course.Shared/*.csproj Shared/Course.Shared/
COPY Services/FakePayment/Services.FakePayment/*.csproj Services/FakePayment/Services.FakePayment/
RUN dotnet restore Services/FakePayment/Services.FakePayment/*.csproj
COPY . .
RUN dotnet publish Services/FakePayment/Services.FakePayment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","Services.FakePayment.dll"]
