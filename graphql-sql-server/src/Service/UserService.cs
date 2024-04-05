using graphql_sql_server.src.Context;
using graphql_sql_server.src.Dto;
using graphql_sql_server.src.Schemas;
using Microsoft.EntityFrameworkCore;

namespace graphql_sql_server.src.Service
{
    public class UserService
    {
        private readonly DataBaseContext _context;
        public UserService(DataBaseContext context)
        {
            this._context = context;
        }
        public async Task<List<UserModel>> GetUsers()
        {
            return await this._context.Users.ToListAsync();
        }

        public async Task<GetDatasUserDto> CreateUser(GetDatasUserDto userDto)
        {
            var user = new UserModel()
            {
                Name = userDto.Name,
                Surname =userDto.Surname,
                Email =userDto.Email,   
                Password=userDto.Password,
            };
            await this._context.AddAsync(user);
            await this._context.SaveChangesAsync();
            return userDto;
        
        }



        public async Task<bool> UserExist(GetDatasUserDto userDto)
        {
            var user = await this._context.Users.SingleOrDefaultAsync(u =>
                u.Name == userDto.Name &&
                u.Surname == userDto.Surname &&
                u.Email == userDto.Email
           );
            return user != null;
        }
    }
}
