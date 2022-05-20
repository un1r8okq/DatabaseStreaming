# DatabaseStreaming
A project for playing around with streaming data from the database

Right now it just creates a tonne of data, hopefully soon I can play with IAsyncEnumerable

## Current output
```
Iteration 0: GET /PeopleAsEnumerable 6571ms
Iteration 1: GET /PeopleAsEnumerable 4385ms
Iteration 2: GET /PeopleAsEnumerable 4324ms
Average: GET /PeopleAsEnumerable 5093ms

Iteration 0: GET /PeopleAsList 3135ms
Iteration 1: GET /PeopleAsList 2718ms
Iteration 2: GET /PeopleAsList 3001ms
Average: GET /PeopleAsList 2951ms

Iteration 0: GET /PeopleAsArray 2665ms
Iteration 1: GET /PeopleAsArray 2782ms
Iteration 2: GET /PeopleAsArray 2851ms
Average: GET /PeopleAsArray 2766ms

Iteration 0: GET /PeopleAsAsyncEnumerable 4188ms
Iteration 1: GET /PeopleAsAsyncEnumerable 4789ms
Iteration 2: GET /PeopleAsAsyncEnumerable 4466ms
Average: GET /PeopleAsAsyncEnumerable 4481ms
```
