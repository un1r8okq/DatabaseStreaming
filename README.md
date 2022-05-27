# DatabaseStreaming
A project for playing around with streaming data from the database

Right now it just creates 100,000 people records in a PostgreSQL database, then times how long different implementations of a GET People endpoint perform.

## Running the project
Start a Postgres database in Docker
`docker run --rm --env POSTGRES_PASSWORD=xJqf1aAUCZkOHr7Z --publish 5432:5432 -it postgres`

Start the API
`dotnet run --configuration Release --project .\DatabaseStreaming.API`

Run the tests
`dotnet run --configuration Release --project .\DatabaseStreaming.Tests`

## Current output
```
Iteration 0: GET /PeopleAsEnumerable 214ms
Iteration 1: GET /PeopleAsEnumerable 4ms
Iteration 2: GET /PeopleAsEnumerable 3ms
Average: GET /PeopleAsEnumerable 74ms

Iteration 0: GET /PeopleAsList 2ms
Iteration 1: GET /PeopleAsList 2ms
Iteration 2: GET /PeopleAsList 3ms
Average: GET /PeopleAsList 2ms

Iteration 0: GET /PeopleAsArray 4ms
Iteration 1: GET /PeopleAsArray 2ms
Iteration 2: GET /PeopleAsArray 2ms
Average: GET /PeopleAsArray 3ms

Iteration 0: GET /PeopleAsAsyncEnumerable 3ms
Iteration 1: GET /PeopleAsAsyncEnumerable 5ms
Iteration 2: GET /PeopleAsAsyncEnumerable 3ms
Average: GET /PeopleAsAsyncEnumerable 4ms
```
