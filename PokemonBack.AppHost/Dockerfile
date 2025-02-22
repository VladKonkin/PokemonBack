FROM mcr.microsof.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# Установка рабочей нагрузки Aspire
RUN dotnet workload install aspire

# Копируем файлы проектов
COPY ["PokemonBack.AppHost/PokemonBack.AppHost.csproj", "PokemonBack.AppHost/"]
COPY ["PokemonBack.ServiceDefaults/PokemonBack.ServiceDefaults.csproj", "PokemonBack.ServiceDefaults/"]
COPY ["PokemonBack.BotBattleAPI/PokemonBack.BotBattleAPI.csproj", "PokemonBack.BotBattleAPI/"]
COPY ["PokemonBack.Battle/PokemonBack.Battle.csproj", "PokemonBack.Battle/"]

# Восстанавливаем зависимости
RUN dotnet restore "PokemonBack.AppHost/PokemonBack.AppHost.csproj"

# Копируем все остальные файлы
COPY . .

# Создаем директорию для публикации
RUN mkdir -p /source/publish

# Публикуем приложение
RUN dotnet publish "PokemonBack.AppHost/PokemonBack.AppHost.csproj" \
    --configuration Release \
    --output /source/publish \
    /p:PublishSingleFile=false

# Проверяем наличие файлов
RUN ls -la /source/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /source/publish .

# Проверяем наличие файлов
RUN ls -la /app

ENV ASPNETCORE_URLS=http://+:6000
ENV DOTNET_ENVIRONMENT=Production
EXPOSE 6000

#ENTRYPOINT ["dotnet", "PokemonBack.AppHost.dll"]
ENTRYPOINT ["bash"]