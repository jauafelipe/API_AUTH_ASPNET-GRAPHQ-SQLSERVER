using graphql_sql_server.src.Context;
using graphql_sql_server.src.Dto;
using graphql_sql_server.src.Schemas;
using graphql_sql_server.src.Service;
using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;

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
      
        public async Task<GetDatasUserDto> CreateUser([Service] UserService service,GetDatasUserDto user)
        {
            var userExist = await service.UserExist(user); // metodo do service que verificar se usuario existe
            //se usuario existe lança exceçao
            if(userExist) throw new GraphQLException("usuario ja existe");
            //verificar se email é valido
            if(!VerificationEmail.IsEmail(user.Email)) throw new GraphQLException("email invalido");

            // faz verificaçao se campos estao vazios
            if(string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Surname) ||
                string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password)
                ){
                throw new GraphQLException("preencha todos os campos");
            }
            // cria usuario caso ele nao existir
            return await service.CreateUser(user);
        }
    }
    public static class VerificationEmail { 
        public static bool IsEmail(string email)
        {
            string regex = @"^[\w-\.]+@(gmail\.com|hotmail\.com|outlook\.com)$";
            return Regex.IsMatch(email, regex);
        }
    }
}
