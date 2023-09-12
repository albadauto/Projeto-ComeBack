using ComeBack.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ComeBack.API.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users { get; set; }
    }
}
