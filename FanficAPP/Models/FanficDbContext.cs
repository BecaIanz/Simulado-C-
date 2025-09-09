using Microsoft.EntityFrameworkCore;

namespace FanficAPP.Models;

public class FanficAPPDbContext(DbContextOptions options) : DbContext(options)
{
    // DbSets representam as tabelas do banco, uma para cada entidade/modelo

    public DbSet<User> Users => Set<User>();



    public DbSet<Fanfic> Fanfics => Set<Fanfic>();
    public DbSet<ReadingList> ReadingLists => Set<ReadingList>();
    public DbSet<FanficReadingList> FanficReadingLists => Set<FanficReadingList>();

    // Aqui definimos configurações avançadas, como relacionamentos entre tabelas
    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Fanfic>()
            .HasOne(f => f.User)
            .WithMany(u => u.Fanfics)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<FanficReadingList>()
            .HasOne(fr => fr.Fanfic)
            .WithMany(f => f.FanficReadingLists)
            .HasForeignKey(fr => fr.FanficID)
            .OnDelete(DeleteBehavior.NoAction);

         model.Entity<FanficReadingList>()
            .HasOne(fr => fr.ReadingList)
            .WithMany(f => f.FanficReadingLists)
            .HasForeignKey(fr => fr.ReadingListID)
            .OnDelete(DeleteBehavior.NoAction);
          
        model.Entity<ReadingList>()
            .HasOne(r => r.User)
            .WithMany(u => u.ReadingLists)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}