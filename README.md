# StreamingService API

## About the Project
StreamingService is an API developed in C# and ASP.NET Core. The API allows clients to access and stream movies stored in a MongoDB database.

The API provides four endpoints for retrieving, streaming and uploading movies.

## Features
- **Get All Movies** – Retrieve a list of all available movies.
- **Get Movie** – Retrieve file name about a specific movie.
- **Stream Movie** – Stream a movie
- **Upload Movie** – Upload a movie file to the MongoDB database.

## Technologies
- C#
- ASP.NET Core Minimal API
- MongoDB
- MongoDB GridFS
- REST API

## Getting Started

### Prerequisites
- .NET SDK
- MongoDB
- Postman

## API Endpoints in StreamingService

| Method | Endpoint | Description |
| GET | `/movie/getall` | Get all movies |
| GET | `/movie/{fileName}` | Get a specific movie |
| GET | `/movie/stream/{fileName}` | Stream a movie |
| POST | `/movie/upload` | Upload a movie |

## Purpose
The purpose of this project is to develop experience working with an API that allows clients to interact with a movie database and stream stored movie files.
