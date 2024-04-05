using HotChocolate.AspNetCore;
using Microsoft.EntityFrameworkCore;
using graphql_sql_server.src.Context;
using graphql_sql_server.src.Querys;
using graphql_sql_server.src.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQLServer()
    .AddQueryType<UserQuery>()
    .AddMutationType<UserMutation>();


//db
var connectionString = builder.Configuration.GetConnectionString("dbconnect");
builder.Services.AddDbContext<DataBaseContext>(op => op.UseSqlServer(connectionString));

//
builder.Services.AddScoped<UserService>();



var app = builder.Build();
app.MapGraphQL("/graphql");
app.Run();
