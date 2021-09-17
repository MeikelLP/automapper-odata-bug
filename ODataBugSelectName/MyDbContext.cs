using System;
using Microsoft.EntityFrameworkCore;

namespace ODataBugSelectName
{
    public class MyDbContext : DbContext
    {
        public DbSet<MyEntity> Entities { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyEntity>().HasData(
                new MyEntity { Id = Guid.NewGuid(), Name = "MyEntity 1", Number = 1},
                new MyEntity { Id = Guid.NewGuid(), Name = "MyEntity 2", Number = 2}
            );
        }
    }

    public class MyEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
    }
}