﻿using BreweryMaster.API.User.Models.Users;
using BreweryMaster.API.User.Models.Users.DB;
using System.Security.Claims;

namespace BreweryMaster.API.User.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>?> GetUsers();
        Task<UserResponse?> GetUserById(string id);
        Task<UserResponse> GetCurrentUser(ClaimsPrincipal? user);
        Task<UserResponse> CreateUser(UserRegisterRequest request);
        Task<UserResponse> UpdateUser(UserUpdateRequest request, string userId);

        Task<bool> CreateTestUsers();
    }
}
