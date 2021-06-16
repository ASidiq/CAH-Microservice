### STAGE 1: Build ###
# syntax=docker/docker:1
FROM alpine AS build-stage

RUN apk add --update npm

#Switching working directory to app
WORKDIR /app

COPY ./nginx.conf /nginx.conf

COPY package*.json /app/

RUN npm install

COPY ./ /app/

RUN npm run build -- --output-path=./dist/out

# Stage 1, based on Nginx, to have only the compiled app, ready for production with Nginx

FROM nginx:latest

COPY --from=build-stage /app/dist/out/ /usr/share/nginx/html

COPY --from=build-stage /nginx.conf /etc/nginx/conf.d/default.conf