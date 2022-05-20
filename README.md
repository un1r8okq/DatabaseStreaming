# DatabaseStreaming
A project for playing around with streaming data from the database

Right now it just creates a tonne of data, hopefully soon I can play with IAsyncEnumerable

## Current output
```
Iteration 0: GET /PeopleAsEnumerable 5483ms
Iteration 1: GET /PeopleAsEnumerable 4249ms
Iteration 2: GET /PeopleAsEnumerable 4094ms
Average: GET /PeopleAsEnumerable 4609ms

Iteration 0: GET /PeopleAsList 2538ms
Iteration 1: GET /PeopleAsList 2291ms
Iteration 2: GET /PeopleAsList 2389ms
Average: GET /PeopleAsList 2406ms

Iteration 0: GET /PeopleAsArray 2392ms
Iteration 1: GET /PeopleAsArray 2284ms
Iteration 2: GET /PeopleAsArray 2450ms
Average: GET /PeopleAsArray 2375ms
```
