FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
RUN apt-get update && apt-get install -y curl
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM node:lts-alpine AS build-node
WORKDIR /src
COPY ["src/Cnblogs.Fluss.Web/wwwroot/package.json", "src/Cnblogs.Fluss.Web/wwwroot/yarn.lock", "src/Cnblogs.Fluss.Web/wwwroot/"]
WORKDIR /src/src/Cnblogs.Fluss.Web/wwwroot/
RUN yarn install --forzen-lockfile
COPY ["src/Cnblogs.Fluss.Web/wwwroot/", "."]
RUN yarn build

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY *.props src/*/*.csproj ./
RUN for file in $(ls *.csproj); do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
RUN dotnet restore src/Cnblogs.Fluss.Web
COPY . .
RUN dotnet build src/Cnblogs.Fluss.Web -c Release --no-restore

FROM build AS publish
WORKDIR /src/src/Cnblogs.Fluss.Web
RUN rm -rf ./wwwroot
COPY --from=build-node /src/src/Cnblogs.Fluss.Web/wwwroot/dist ./wwwroot/dist
RUN dotnet publish -c Release -o /app/publish --no-build

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cnblogs.Fluss.Web.dll"]
