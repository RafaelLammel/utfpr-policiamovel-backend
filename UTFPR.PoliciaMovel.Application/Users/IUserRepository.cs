﻿using UTFPR.PoliciaMovel.Application.Interfaces.Repositories;
using UTFPR.PoliciaMovel.Domain.Entities;

namespace UTFPR.PoliciaMovel.Application.Users
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByLoginAsync(string login);
        Task<User> FindByLoginAndPasswordAsync(string login, string password);
        Task<User> FindById(string userId);
    }
}