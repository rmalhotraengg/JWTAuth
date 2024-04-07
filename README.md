# Prerequisites

Docker hub account

Azure account


# JWTAuth
Dockerzied Azure Container App For JWT Authentication

# Centralized App for authentication
Standalone app for JWT Authentication.Will be used for:

1.Validating Clients for authentication example Angular app user

2.Can be used by other micro services by sharing the same signing key(single sign on)

3.This app has in memory sqllite db with user table

Two Users:
emailid:abc@gmail.com
pwd:abc

Eill throw bad request if user dont exist in db else gives out token.

# Docker
1.Created  docker file with docker support visual studio(linux and docker file on windows home edition)

2.Published and pushed image using docker hub account

Image on dockerhub: amtmal/userservice

# Azure Web Apps for containers

1.With student azure account

2.Created a resource group and added a web app for containers

3.Add image from docker hub

Use the generated link for api to authnticate

Demo :https://userapirest.azurewebsites.net/swagger/index.html
