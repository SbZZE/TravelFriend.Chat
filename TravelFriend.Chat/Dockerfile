FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["TravelFriend.Chat/TravelFriend.Chat.csproj", "TravelFriend.Chat/"]
RUN dotnet restore "TravelFriend.Chat/TravelFriend.Chat.csproj"
COPY . .
WORKDIR "/src/TravelFriend.Chat"
RUN dotnet build "TravelFriend.Chat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelFriend.Chat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelFriend.Chat.dll"]
