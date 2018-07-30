# Hiscores

An ASP.NET Core project for logging game high scores.

## Docker
This project can be run as a Docker container:

```
docker build -t hiscores:latest .
docker volume create hiscores
docker run -d -v hiscores:/var/hiscore -p 8084:80 --name hiscores hiscores:latest
```
