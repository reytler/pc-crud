using Microsoft.EntityFrameworkCore;

namespace crudpcapi;

public class MysqlContext: DbContext
{
    public MysqlContext(DbContextOptions ipOptions) : base(ipOptions)
    {
    }
}
