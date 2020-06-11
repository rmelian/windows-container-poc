#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

#FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2019
#ARG source
#WORKDIR /inetpub/wwwroot
#COPY ${source:-obj/Docker/publish} .

# The `FROM` instruction specifies the base image. You are
# extending the `microsoft/aspnet` image.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1
#FROM microsoft/aspnet

# The final instruction copies the site you published earlier into the container.
#COPY . /inetpub/wwwroot
