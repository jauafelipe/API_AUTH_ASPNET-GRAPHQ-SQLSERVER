using graphql_sql_server.src.Schemas;
using Microsoft.EntityFrameworkCore;

namespace graphql_sql_server.src.Context
{
    public class DataBaseContext:DbContext
    {
        public DbSet<UserModel> Users { get; set; } 
        public DataBaseContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
