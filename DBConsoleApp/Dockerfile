# Stage 1: base runtime
# Stage 1: base runtime
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

# Stage 2: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy all files in current folder (DBConsoleApp/) into container
COPY . .

# Restore & publish (paths fixed)
RUN dotnet restore DBConsoleApp.csproj
RUN dotnet publish DBConsoleApp.csproj -c Release -o /app/publish

# Stage 3: final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "DBConsoleApp.dll"]



