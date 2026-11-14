# StreamingService API

## About the Project
StreamingService is an API developed in C# and ASP.NET Core. The API allows clients to access and stream movies stored in a MongoDB database.

The API provides four endpoints for retrieving, streaming and uploading movies.

## Features
- **Get All Movies** – Retrieve a list of all available movies.
- **Get Specific Movie** – Retrieve file name about a specific movie.
- **Stream Movie** – Stream a movie
- **Upload Movie** – Upload a movie file to the MongoDB database.

## Technologies
- C#
- ASP.NET Core Minimal API
- MongoDB
- MongoDB GridFS

### Prerequisites
- .NET SDK
- MongoDB
- Postman

## Purpose
The purpose of this project is to develop experience working with an API that allows clients to interact with a movie database and stream stored movie files.



# Netflix Clone API

**Version:** 1.0

**Description:** A REST API for uploading, retrieving, searching, and streaming movies. Movie metadata is stored in MongoDB.


## Endpoint 1: Upload Movie

**Method:** [POST]

**URL:** `/movie/upload`

**Description:** Uploads a movie file and stores its metadata in MongoDB.

**Response (200 OK):**

{
  "fileName": "file_example_MP4_640_3MG.mp4",
  "message": "Successfully uploaded movie"
}


## Endpoint 2: Get All Movies

**Method:** [GET]

**URL:** `/movie/getall`

**Description:** Retrieves all movie metadata from MongoDB.

**Response (200 OK):**

[
  {
    "id": {
      "timestamp": 1794510272,
      "creationTime": "2026-11-12T19:04:32Z"
    },
    "fileName": "file_example_MP4_640_3MG.mp4",
    "fileLength": 3114374
  },
  {
    "id": {
      "timestamp": 1794511277,
      "creationTime": "2026-11-12T19:21:17Z"
    },
    "fileName": "sample-10s-360p.mp4",
    "fileLength": 2185013
  }
]


## Endpoint 3: Stream Movie

**Method:** [GET]

**URL:** `/movie/stream/{fileName}`

**Description:** Streams the selected movie using its filename.

**Response:** Movie video stream (`video/mp4`).


## Endpoint 4: Search Movie

**Method:** [GET]

**URL:** `/movie/{fileName}`

**Description:** Searches MongoDB for a specific movie using its filename.

**Response (200 OK):**

{
  "id": {
    "timestamp": 1794510272,
    "creationTime": "2026-11-12T19:04:32Z"
  },
  "fileName": "file_example_MP4_640_3MG.mp4",
  "fileLength": 3114374
}
