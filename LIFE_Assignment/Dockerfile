#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LIFE_Assignment.csproj", "LIFE_Assignment/"]
RUN dotnet restore "LIFE_Assignment/LIFE_Assignment.csproj"
COPY . ./LIFE_Assignment
WORKDIR "/src/LIFE_Assignment"
RUN dotnet build "LIFE_Assignment.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LIFE_Assignment.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LIFE_Assignment.dll"]