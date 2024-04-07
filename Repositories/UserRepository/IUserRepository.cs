using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserService.Api.Model.DomainModels;
using UserService.Api.Model.DTO;

namespace UserService.Api.Repositories
{
    public interface IUserRepository
    {
        Task<ApiResponse<List<User>>> GetAll();
        bool UserExists(string emailId);
    }
}
