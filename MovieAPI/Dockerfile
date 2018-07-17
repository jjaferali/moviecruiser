FROM microsoft/aspnetcore-build:latest AS build-env
WORKDIR /app

# Copy csproj
COPY *.csproj ./
RUN dotnet restore

# Copy everything else
COPY . ./
RUN dotnet publish -c Release -o out

#Build run time image
FROM microsoft/aspnetcore:latest
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","MovieAPI.dll"]