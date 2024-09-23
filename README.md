# Blog API

Welcome to the Blog API repository! This API provides various functionalities for managing posts with user authentication and authorization. It is a project in progress!

## Features

- **Post Management:**
  - Add, edit, delete, and retrieve posts
- **User Authentication:**
  - Register and login with username and password
  - JWT token authentication and authorization

## Technologies Used

- ASP.NET Core 8 Web API, MongoDB, FluentValidation, MediatR
- Architecture Patterns: Clean architecture, Domain-driven design (DDD), CQRS by implementing Mediator pattern using MediatR package

## Getting Started

To get started with the Ecommerce API, follow these steps:

1. Clone this repository to your local machine.
2. Install MongoDB.
3. Run the API project

## API Endpoints


### Users

- **POST /api/users/register**: Registers a new user.
  - Request Body:
    ```json
    {
      "firstName": "John",
      "lastName": "Doe",
      "email": "john.doe@example.com",
      "password": "Password123!"
    }
    ```
  - Response: Success (200)

- **POST /api/users/login**: Logs in a user.
  - Request Body:
    ```json
    {
      "email": "john.doe@example.com",
      "password": "Password123!"
    }
    ```
  - Response: Success (200)

### Posts

**Posts**
- GET /api/posts: Retrieves all blog posts.

  - Response Example:
   ```json
    [
      {
        "id": "fa63c930-e4e1-48f9-b7be-bb4f80ee82c3",
        "title": "update post",
        "content": "update adsfasdfsadf",
        "createdOn": "2024-06-01T13:24:44.032Z"
      }
    ]
    ```

- **POST /api/posts**: Creates a new blog post.
  - Request Body:
    ```json
    {
      "title": "My First Blog Post",
      "content": "This is the content of my blog post.",
      "authorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
    }
    ```

- **PUT /api/posts/{id}**: Updates an existing blog post.
  - Request Parameters:
    id (string, format: uuid) - ID of the post to update.
  - Request Body:
     ```json
    {
      "title": "Updated Title",
      "content": "Updated content."
    }
    ```

- **DELETE /api/posts/{id}**: Deletes a blog post.
  - Request Parameters:
    id (string, format: uuid) - ID of the post to delete.
