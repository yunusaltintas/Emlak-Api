
FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /app
COPY ./Emlak.API/*.csproj ./Emlak.API/
COPY ./Emlak.Data/*.csproj ./Emlak.Data/
COPY ./Emlak.Repository/*.csproj ./Emlak.Repository/
COPY ./Emlak.Service/*.csproj ./Emlak.Service/
COPY *.sln .
RUN dotnet restore
COPY . .
RUN dotnet publish ./Emlak.API/*.csproj -o /publish/

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPy --from=build /publish .
ENV ASPNETCORE_URLS="http://*:4000"
ENTRYPOINT ["dotnet","Emlak.API.dll"]