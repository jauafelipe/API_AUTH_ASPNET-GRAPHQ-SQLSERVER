using graphql_sql_server.src.Context;
using graphql_sql_server.src.Dto;
using graphql_sql_server.src.Schemas;
using graphql_sql_server.src.Service;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Data;
using System.Runtime.Serialization.Json;

namespace graphql_sql_server.src.Querys
{
    public class UserQuery
    {
        public  async Task<List<UserModel>> GetUsers([Service] UserService userService)
        {
            return await userService.GetUsers();
        }
    }

    public class UserMutation
    {
     
        public async Task<GetDatasUserDto> CreateUser([Service] UserService service, GetDatasUserDto user)
        {
            return await service.CreateUser(user);
        }
    }


    public class UserMutationType : ObjectType<UserMutation>
    {
        private readonly UserService _userService;
        private readonly GetDatasUserDto _inputdto;
        public UserMutationType(UserService userService, GetDatasUserDto userDtoInput)
        {
            _userService = userService;
            this._inputdto = userDtoInput;
        }

        protected override void Configure(IObjectTypeDescriptor<UserMutation> descriptor)
        {

            descriptor.Field(u => u.CreateUser(this._userService, this._inputdto))
                .Name("createUser")
                .Argument("user", arg => arg.Type<NonNullType<GetDatasUserDtoInputType>>())
                .Use(next => async context =>
                {
                    var userService = context.Service<UserService>();
                    var userDto = context.ArgumentValue<GetDatasUserDto>("user");

                    if (userDto == null ||
                        string.IsNullOrEmpty(userDto.Name) ||
                        string.IsNullOrEmpty(userDto.Surname) ||
                        string.IsNullOrEmpty(userDto.Email) ||
                        string.IsNullOrEmpty(userDto.Password))
                    {
                        throw new GraphQLException("Preencha todos os campos");
                    }

                    var createdUser = await userService.CreateUser(userDto);
                    context.Result = createdUser;

                    await next(context);
                });
        }
    }
}
