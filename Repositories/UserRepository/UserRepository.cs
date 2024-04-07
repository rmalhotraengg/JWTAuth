using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Api.Data;
using UserService.Api.Model.DomainModels;
using UserService.Api.Model.DTO;

namespace UserService.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        } 

        /// <summary>
        /// Asynchronous call to db to get all users
        /// </summary>
        /// <returns></returns>
        public async Task<ApiResponse<List<User>>> GetAll()
        {
            ApiResponse<List<User>> response = new ApiResponse<List<User>>();
            try
            {    response.Data = await _context.Users.ToListAsync();
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Success = false;

            }
            return response;
        }
         

        /// <summary>
        /// check if user exists based on email id
        /// </summary>
        /// <param name="emailId"></param>
        /// <returns></returns>
        public bool UserExists(string emailId)
        {

            _context.Database.EnsureCreated();
            return _context.Users.Any(x => x.EmailId == emailId);
        }
         
    }
}
