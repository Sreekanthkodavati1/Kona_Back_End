#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["Core_APIService/Core_APIService.csproj", "Core_APIService/"]
RUN dotnet restore "Core_APIService/Core_APIService.csproj"
COPY . .
WORKDIR "/src/Core_APIService"
RUN dotnet build "Core_APIService.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Core_APIService.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Core_APIService.dll"]