# Notion
> This project is a API for a Gamestore thats purpose is to manage and retrieve information about games in the stores catalog
> The API uses CRUD operations for managing the records and using the Entity Framework for database interactions.


## Table of Contents
* [General Info](#general-information)
* [Technologies Used](#technologies-used)
* [Features](#features)
* [Screenshots](#screenshots)
* [Setup](#setup)
* [Project Status](#project-status)
* [Room for Improvement](#room-for-improvement)
* [Acknowledgements](#acknowledgements)
* [Contact](#contact)
<!-- * [License](#license) -->


## General Information
- The aim of the project was to get exercise to strengthen my skills in C# and get more knowledge with APIs


## Technologies Used
- C# and .NET Core
- Entity Framework Core
- SQLite


## Features
- Endpoints for CRUD operations
- Locally hosted Database
- Data transfer objects 
- Error handling


## Endpoint examples
### **Get All games**

`GET http://localhost:5029/games`
Return:
```
HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Sun, 03 Nov 2024 09:18:08 GMT
Server: Kestrel
Transfer-Encoding: chunked

[
  {
    "id": 1,
    "name": "Age of Empire",
    "genre": "Fighting",
    "price": 9.99,
    "releaseDate": "2011-11-18"
  },
  {
    "id": 2,
    "name": "World of warcraft",
    "genre": "Sports",
    "price": 19.99,
    "releaseDate": "2011-11-18"
  }
]
```
### **Get game by Id**

`GET http://localhost:5029/games/1`
Return:
```
HTTP/1.1 200 OK
Connection: close
Content-Type: application/json; charset=utf-8
Date: Sun, 03 Nov 2024 09:18:31 GMT
Server: Kestrel
Transfer-Encoding: chunked

{
  "id": 1,
  "name": "Age of Empire",
  "genreId": 1,
  "price": 9.99,
  "releaseDate": "2011-11-18"
}
```
### **Create new game**
`POST http://localhost:5029/games`

```
//Payload
Content-Type: application/json

{
    "name": "League of Legends",
    "genreId": 3,
    "price": 19.99,
    "releaseDate": "2011-11-18"
}
```
Return:
```
HTTP/1.1 201 Created
Connection: close
Content-Type: application/json; charset=utf-8
Date: Sun, 03 Nov 2024 09:19:50 GMT
Server: Kestrel
Location: http://localhost:5029/games/3
Transfer-Encoding: chunked

{
  "id": 3,
  "name": "League of Legends",
  "genreId": 3,
  "price": 19.99,
  "releaseDate": "2011-11-18"
}
```

### **Update a game**
`PUT http://localhost:5029/games/1`

```
//Payload
Content-Type: application/json

{
  "name": "Age of Empire",
  "genreId": 1,
  "price": 9.99,
  "releaseDate": "2011-11-18"
}
```
Return:
```
HTTP/1.1 204 No Content
Connection: close
Date: Sun, 03 Nov 2024 09:20:16 GMT
Server: Kestrel
```

### **Delete a game by Id**

`DELETE http://localhost:5029/games/3`
Return:

```
HTTP/1.1 204 No Content
Connection: close
Date: Sun, 03 Nov 2024 09:22:42 GMT
Server: Kestrel
```


## Setup
To run this project you need to:
1. Clone the repository
2. Run `dotnet run`
3. In the `games.http` file right click CRUD operations and select `Send request`


## Project Status
Project is:  _complete_


## Room for Improvement

Further development:
- Create frontend for the project


## Acknowledgements
- This project was based on [this tutorial](https://www.youtube.com/watch?v=AhAxLiGC7Pc).
  

## Contact
[LinkedIn](https://www.linkedin.com/in/lasse-h%C3%A4m%C3%A4l%C3%A4inen-09b869181/)



<!-- Optional -->
<!-- ## License -->
<!-- This project is open source and available under the [... License](). -->

<!-- You don't have to include all sections - just the one's relevant to your project -->
