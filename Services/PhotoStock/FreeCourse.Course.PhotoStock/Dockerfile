FROM mcr.microsoft.com/dotnet/sdk:6.0-bookworm-slim as build
WORKDIR /app
EXPOSE 80
COPY Shared/FreeCourse.Shared/*.csproj Shared/FreeCourse.Shared/
COPY Services/PhotoStock/FreeCourse.Course.PhotoStock/*.csproj Services/PhotoStock/FreeCourse.Course.PhotoStock/
RUN dotnet restore Services/PhotoStock/FreeCourse.Course.PhotoStock/*.csproj
COPY . .
RUN dotnet publish Services/PhotoStock/FreeCourse.Course.PhotoStock/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:6.0-bookworm-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","FreeCourse.Course.PhotoStock.dll" ]