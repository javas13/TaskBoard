using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Core.Models;
using TaskBoard.DataAccess.Entities;

namespace TaskBoard.DataAccess
{
    public class TaskBoardDbContext : DbContext
    {
        public TaskBoardDbContext(DbContextOptions<TaskBoardDbContext> options)
            : base(options) 
        {
            //Нужно чтобы не было ошибки Cannot write DateTime with Kind=UTC to PostgreSQL type 'timestamp without time zone'
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<ProjectMemberEntity> ProjectMembers { get; set; }
        public DbSet<ObjectiveEntity> Objectives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Уникальность email пользователя
            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Отношения для ProjectMember
            modelBuilder.Entity<ProjectMemberEntity>()
                .HasIndex(pm => new { pm.ProjectId, pm.UserId })
                .IsUnique();

            // Каскадное удаление
            modelBuilder.Entity<ProjectEntity>()
                .HasMany(p => p.Objectives)
                .WithOne(t => t.Project)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
