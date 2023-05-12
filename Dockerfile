# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal as build
WORKDIR /source
COPY . .
RUN dotnet restore "./Expenses.Server/Expenses.Server.API/Expenses.Server.API.csproj" --disable-parallel
RUN dotnet publish "./Expenses.Server/Expenses.Server.API/Expenses.Server.API.csproj" -c release -o /app --no-restore

#Serve Stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal as build
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000
ENTRYPOINT ["dotnet", "Expenses.Server.API.dll"]
