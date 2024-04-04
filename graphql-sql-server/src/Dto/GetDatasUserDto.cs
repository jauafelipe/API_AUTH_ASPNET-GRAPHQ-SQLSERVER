namespace graphql_sql_server.src.Dto
{
    public class GetDatasUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class GetDatasUserDtoInputType : InputObjectType<GetDatasUserDto>
    {
        protected override void Configure(IInputObjectTypeDescriptor<GetDatasUserDto> descriptor)
        {
            descriptor.Name("GetDatasUserInput");
            descriptor.Field(u => u.Name).Name("name").Type<NonNullType<StringType>>();
            descriptor.Field(u => u.Surname).Name("surname").Type<NonNullType<StringType>>();
            descriptor.Field(u => u.Email).Name("email").Type<NonNullType<StringType>>();
            descriptor.Field(u => u.Password).Name("password").Type<NonNullType<StringType>>();
        }
    }
}
