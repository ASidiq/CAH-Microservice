# variable
ARG VERSION=5.0

# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish MergedService.csproj -c Release -o out

#Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:$VERSION
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:83
ENV questionService http://question-service:81/api/Question
ENV answerService http://answer-service:82/api/Answer

EXPOSE 83
ENTRYPOINT [ "dotnet", "MergedService.dll" ]