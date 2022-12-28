# Stage 1
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /build
COPY . .
RUN dotnet publish -c Release -o /app
# Stage 2
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
WORKDIR /app
COPY --from=build /app .
COPY --from=build /build/entrypoint.sh .
RUN chmod +x entrypoint.sh

EXPOSE 82
ENTRYPOINT ["/app/entrypoint.sh"]
 
