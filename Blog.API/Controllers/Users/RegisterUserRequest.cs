﻿namespace Blog.API.Controllers.Users;

public record RegisterUserRequest(string firstName, string lastName, string email, string password);
