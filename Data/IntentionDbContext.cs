using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data;
public partial class IntentionDbContext: DbContext
{
    public IntentionDbContext(DbContextOptions<IntentionDbContext> options): base(options)
    {

    }

    public virtual DbSet<Challenge> Challenges { get; set; } = null!;


}
