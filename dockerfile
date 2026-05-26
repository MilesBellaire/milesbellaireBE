# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder
WORKDIR /app
COPY milesbellaireBE/*.csproj ./milesbellaireBE/
RUN dotnet restore milesbellaireBE/milesbellaireBE.csproj
COPY . .
RUN dotnet publish milesbellaireBE/milesbellaireBE.csproj -c Release -o /out

# Stage 2: Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=builder /out .
EXPOSE 8080
ENTRYPOINT ["dotnet", "milesbellaireBE.dll"]