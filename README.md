# Sample App to Experiment with Redis

## Setup Redis with Docker
* `docker pull redis`
* Start new container: `docker run --name redis-book-app -d -p 6379:6379 redis`
* Check that it's running: `docker ps`
* View the logs: `docker logs redis-book-app`

## Run Redis CLI
* Start new interactive session (`-it`) inside the running container
  * `docker exec -it redis-book-app sh`
* Start Redis CLI once we've attached to our container:
  * `redis-cli`

## Run Application
* Clone this repo
* Run in Visual Studio

## View Redis Cache in Redis CLI
* List all keys: `KEYS *`
* After running the project, a `books` key should be inserted for 30 seconds. To view contents, run:
    * `get books`

## View Redis Cache in Redis Desktop Manager
* Download and install [Redis Desktop Manager](https://redisdesktop.com/)
* Connect with:
  * Address: localhost
  * Port: 6379