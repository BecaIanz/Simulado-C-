using Microsoft.EntityFrameworkCore;

namespace FanficAPP.Models;

// Context do banco de dados, herda DbContext do EF Core
public class ThePixelerDbContext(DbContextOptions options) : DbContext(options)
{
    // DbSets representam as tabelas do banco, uma para cada entidade/modelo

    public DbSet<User> Users => Set<User>();
    public DbSet<Fanfic> Fanfics => Set<Fanfic>();
    public DbSet<ReadingList> ReadingLists => Set<ReadingList>();

    // Aqui definimos configurações avançadas, como relacionamentos entre tabelas
    protected override void OnModelCreating(ModelBuilder model)
    { 
        model.Entity<Fanfic>()
            .HasOne(f => f.User)
            .WithMany(u => u.Fanfics)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}