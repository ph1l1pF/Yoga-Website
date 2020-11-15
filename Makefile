default: run

run:
	git pull
	docker-compose down
	docker build  -t yoga-website .
	docker run -it -p 80:80 --rm yoga-website &