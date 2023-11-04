FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LogMeIn/LogMeIn.csproj", "LogMeIn/"]
COPY ["LogMeIn.Data/LogMeIn.Data.csproj", "LogMeIn.Data/"]
COPY ["LogMeIn.Models/LogMeIn.Models.csproj", "LogMeIn.Models/"]
COPY ["LogMeIn.Utility/LogMeIn.Utility.csproj", "LogMeIn.Utility/"]
RUN dotnet restore "LogMeIn/LogMeIn.csproj"
COPY . .
WORKDIR "/src/LogMeIn"
RUN dotnet build "LogMeIn.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LogMeIn.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LogMeIn.dll"]
