﻿using BreweryMaster.API.Shared.Models;
using BreweryMaster.API.User.Models.Requests;
using BreweryMaster.API.User.Models.Responses;
using BreweryMaster.API.User.Models.Users;
using System.Security.Claims;

namespace BreweryMaster.API.User.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserResponse>> GetUsers(UserFilterRequest? request);
        Task<IEnumerable<EntityStringIdResponse>> GetUserDropDownList();
        Task<IEnumerable<EntityStringIdResponse>> GetRolesDropDownList();
        Task<UserDetailsResponse?> GetUserById(string id);
        Task<UserResponse> GetCurrentUser(ClaimsPrincipal? user);
        Task<UserDetailsResponse> GetCurrentUserDetails(ClaimsPrincipal? user);
        Task<UserResponse?> CreateUser(UserRegisterRequest request);
        Task<UserResponse?> UpdateUser(UserUpdateRequest request, string userId);
        Task<bool> UpdatePassword(UserPasswordRequest request, ClaimsPrincipal? claims);
        Task<bool> UpdateUserRoles(UserRolesUpdateRequest request);

        Task<bool> CreateTestUsers();
    }
}
