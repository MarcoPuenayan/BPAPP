#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BPAPP/BPAPP.csproj", "BPAPP/"]
RUN dotnet restore "BPAPP/BPAPP.csproj"
COPY . .
WORKDIR "/src/BPAPP"
RUN dotnet build "BPAPP.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BPAPP.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BPAPP.dll"]