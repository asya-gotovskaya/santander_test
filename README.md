## Service running

Service can be run in Docker container.
To run do (in ./HackerNews dir):
- docker build --tag hacker-news .
- docker run -p 8080:80 hacker-news

For getting best 10 stories use:

http://localhost:8080/hacker-news/best-stories?count=10

## Improvements

1. AutoMapper for mapping Dtos objects.
2. Add more Unit Tests.