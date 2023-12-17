FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HackerNews/HackerNews.csproj", "HackerNews/"]
RUN dotnet restore "HackerNews/HackerNews.csproj"
COPY . .
WORKDIR "/src/HackerNews"
RUN dotnet build "HackerNews.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HackerNews.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HackerNews.dll"]