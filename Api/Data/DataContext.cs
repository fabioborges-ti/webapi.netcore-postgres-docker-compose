using Microsoft.EntityFrameworkCore;
using Api.Models;
using System;
using System.Collections.Generic;

namespace Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<StudentsDiscipline> StudentsDisciplines { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /* creating relationship between Students and Disciplines */
            builder
                .Entity<StudentsDiscipline>()
                .HasKey(sd => new { sd.StudentId, sd.DisciplineId });

            builder
                .Entity<Teacher>()
                .HasData(new List<Teacher>
                {
                    new(Guid.Parse("faf4e3c5-bd4a-4ef6-9280-2569e8e60b37"), "Alexandre"),
                    new(Guid.Parse("85d9ecd9-91d8-46b3-a25a-1c70509d4942"), "Lauro"),
                    new(Guid.Parse("c4df4c57-c76c-4fe6-b187-5d7d0b3d88d6"), "Roberto"),
                });

            builder
                .Entity<Discipline>()
                .HasData(new List<Discipline>
                {
                    new(Guid.Parse("240cf246-08d7-4bc9-988c-8ee543b5ac85"), "Matemática", Guid.Parse("faf4e3c5-bd4a-4ef6-9280-2569e8e60b37")),
                    new(Guid.Parse("28641b47-997e-4b67-9819-2a0011e05f87"), "Física", Guid.Parse("85d9ecd9-91d8-46b3-a25a-1c70509d4942")),
                    new(Guid.Parse("845305d3-c495-47cd-afb1-692b41b7e11a"), "Português", Guid.Parse("c4df4c57-c76c-4fe6-b187-5d7d0b3d88d6")),
                });

            builder
                .Entity<Student>()
                .HasData(new List<Student>
                {
                    new(Guid.Parse("ddcd8f2c-6b9c-4a85-b254-6241741f6a28"), "Marta", "Kent", "33225555"),
                    new(Guid.Parse("f58d0279-1ae7-4689-a789-0e58100cca9a"), "Paula", "Isabela", "3354288"),
                    new(Guid.Parse("5394b62e-4e6b-4f85-baa8-4447e3effdfb"), "Laura", "Antonia", "55668899"),
                });

            builder
                .Entity<StudentsDiscipline>()
                .HasData(new List<StudentsDiscipline>
                {
                    new() { StudentId = Guid.Parse("ddcd8f2c-6b9c-4a85-b254-6241741f6a28"), DisciplineId = Guid.Parse("240cf246-08d7-4bc9-988c-8ee543b5ac85") },
                    new() { StudentId = Guid.Parse("f58d0279-1ae7-4689-a789-0e58100cca9a"), DisciplineId = Guid.Parse("28641b47-997e-4b67-9819-2a0011e05f87") },
                    new() { StudentId = Guid.Parse("5394b62e-4e6b-4f85-baa8-4447e3effdfb"), DisciplineId = Guid.Parse("845305d3-c495-47cd-afb1-692b41b7e11a") },
                });
        }
    }
}
