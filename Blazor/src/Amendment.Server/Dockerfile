#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Amendment.Server/Amendment.Server.csproj", "src/Amendment.Server/"]
RUN dotnet restore "src/Amendment.Server/Amendment.Server.csproj"
COPY . .
WORKDIR "/src/src/Amendment.Server"
RUN dotnet build "Amendment.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Amendment.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Amendment.Server.dll"]