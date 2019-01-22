FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 58367
EXPOSE 44340

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ContractsManagementAPI/ContractsManagementAPI.csproj", "ContractsManagementAPI/"]
RUN dotnet restore "ContractsManagementAPI/ContractsManagementAPI.csproj"
COPY . .
WORKDIR "/src/ContractsManagementAPI"
RUN dotnet build "ContractsManagementAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ContractsManagementAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContractsManagementAPI.dll"]