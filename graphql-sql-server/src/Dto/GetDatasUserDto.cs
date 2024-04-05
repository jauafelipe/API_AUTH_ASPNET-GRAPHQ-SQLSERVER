namespace graphql_sql_server.src.Dto
{
    [GraphQLName("GetDataUser")]
    public class GetDatasUserDto
    {
        [GraphQLName("name")]
        [GraphQLType(typeof(string))]
        public string Name { get; set; }
        [GraphQLName("surname")]
        [GraphQLType(typeof(string))]
        public string Surname { get; set; }
        [GraphQLName("email")]
        [GraphQLType(typeof(string))]
        public string Email { get; set; }
        
        [GraphQLName("password")]
        [GraphQLType(typeof(string))]
        public string Password { get; set; }

    }
}
