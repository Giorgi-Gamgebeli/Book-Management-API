# Book Management API

## Overview
This web api is built in .Net 9.0.2.

Run this command to start and go to /swagger 
```terminal
dotnet run
```

## Features
- Complete CRUD operations for books
- Pagination support for listing books
- Book view count tracking
- Soft deletion (books are marked as deleted but not removed from database)
- Bulk creation and deletion support 
- Automatic reactivation of soft-deleted books when re-adding

## Endpoints

### GET /api/books
Returns books names paginated and sorted by popularity score.

**Response 200**
```json
{
  "status": 200,
  "success": "Sucessfully retrieved books!",
  "data": [
    {
      "id": 1,
      "title": "The Knight in the Panther's Skin"
    },
    {
      "id": 7,
      "title": "Davitiani"
    },
    {
      "id": 8,
      "title": "Spring in Kartli"
    },
    {
      "id": 3,
      "title": "The First Step"
    },
    {
      "id": 14,
      "title": "Whispers of the Past"
    }
  ],
  "currentPage": 1,
  "totalPages": 3,
  "pageSize": 5,
  "totalCount": 13,
  "hasPrevious": false,
  "hasNext": true
}
```

### POST /api/books
To create new book or books I decided instead of adding 2 different api endpoints for single and multiple I would combine them, I think less endpoints means less confusing api.

**Response 200**
```json
{
  "status": 200,
  "success": "Sucessfully added new Books!",
  "data": [
    {
      "id": 21,
      "title": "Shadows of the Valley",
      "authorName": "Levan Kharadze",
      "publicationYear": 1995,
      "bookViews": 0
    },
    {
      "id": 22,
      "title": "The Forgotten Kingdom",
      "authorName": "Irakli Tvalchrelidze",
      "publicationYear": 1980,
      "bookViews": 0
    }
  ]
}
```

### DELETE /api/books
Again here instead of adding 2 api endpoints I combined single and multiple deletion.

**Response 204**

### GET /api/books/{id}
Now here I decied to leave this single GET api endpoint, becouse /api/books and this endpoint are recieving and returning completely different things combining would make it less understandable.

**Response 200**
```json
{
  "status": 200,
  "success": "Sucessfully retrieved book!",
  "data": {
    "id": 5,
    "title": "The Father of Soldiers",
    "authorName": "David Kldiashvili",
    "publicationYear": 1964,
    "bookViews": 182
  }
}
```

### PATCH /api/books/{id}
I choose this to be patch instead of put, because im not updating entire book with this endpoint.

**Response 200**
```json
{
  "status": 200,
  "success": "Successfully updated book!",
  "data": {
    "id": 5,
    "title": "The Father of Soldiers",
    "authorName": "David Kldiashvili",
    "publicationYear": 1965,
    "bookViews": 182
  }
}
```