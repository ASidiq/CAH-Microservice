# variable
ARG VERSION=5.0

# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:$VERSION AS build-env
WORKDIR /app

# RUN setx questionApiUrl http://127.0.0.1:8000/question/foodpack/
# ENV questionApiUrl http://0.0.0.0:8000/question/foodpack/

# Copy csproj and restore as distinct layers
COPY *csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish AnswerService.csproj -c Release -o out

#Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:$VERSION
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS=http://+:82
ENV answerApiUrl http://cah-api:5000/answer/foodpack/
EXPOSE 82
ENTRYPOINT [ "dotnet", "AnswerService.dll" ]