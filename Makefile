git pull
docker build  -t example:prod .
kill $(lsof -t -i:80)
docker run -it -p 80:80 --rm example:prod &.