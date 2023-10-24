﻿using Hotel.Interfaces;
using Hotel.Models;

namespace Hotel.Services;

public class UserService : IUsers
{
    private readonly DataContext context;
    public UserService(DataContext context)
    {
        this.context = context;
    }


    public List<User> ShowAllUsers()
    {
        return context.Users.ToList();
    }

    public async Task<User> AddNewUser(NewUserRequest request)
    {
        User user = new User {
            Login = request.Login,
            Password = request.Password,
            UserName = request.UserName,
            Email = request.Email,
        };
        var tracking = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return tracking.Entity;
    }
}
