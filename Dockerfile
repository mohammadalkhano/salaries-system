#Use commands from Rickard to install docker on VM.
FROM ubuntu:20.04

RUN apt-get -y update

RUN apt-get -y install nginx
