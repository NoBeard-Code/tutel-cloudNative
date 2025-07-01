# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Tutel.EduWork/Tutel.EduWork/Tutel.EduWork.csproj", "Tutel.EduWork/Tutel.EduWork/"]
COPY ["Tutel.EduWork.BusinessLayer/Tutel.EduWork.BusinessLayer.csproj", "Tutel.EduWork.BusinessLayer/"]
COPY ["Tutel.EduWork.DataAccessLayer/Tutel.EduWork.DataAccessLayer.csproj", "Tutel.EduWork.DataAccessLayer/"]
COPY ["Tutel.EduWork/Tutel.EduWork.Client/Tutel.EduWork.Client.csproj", "Tutel.EduWork/Tutel.EduWork.Client/"]
RUN dotnet restore "./Tutel.EduWork/Tutel.EduWork/Tutel.EduWork.csproj"
COPY . .
WORKDIR "/src/Tutel.EduWork/Tutel.EduWork"
RUN dotnet build "./Tutel.EduWork.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Tutel.EduWork.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tutel.EduWork.dll"]