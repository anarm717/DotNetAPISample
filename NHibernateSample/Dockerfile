# Use the official .NET 8.0 SDK image as a base
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY *.csproj ./
RUN dotnet restore
# Copy the remaining source code
COPY . .

# Build the application
RUN dotnet publish -c Release -o out

# Build the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 5051
COPY --from=build /app/out ./
ENTRYPOINT ["dotnet", "NHibernateSample.dll"]