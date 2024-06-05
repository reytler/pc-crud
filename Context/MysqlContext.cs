using crudpcapi.Models;
using Microsoft.EntityFrameworkCore;

namespace crudpcapi;

public class MysqlContext: DbContext
{
    public MysqlContext(DbContextOptions<MysqlContext> ipOptions) : base(ipOptions)
    {
    }

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Sujeito> Sujeitos { get; set; } = null!;
    public DbSet<Photo> Photos { get; set; } = null!;
}
