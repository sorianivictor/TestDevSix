using Microsoft.EntityFrameworkCore;

namespace SoriProjectV2.Infra;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {

    }
}
