using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using tdAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace tdAPI.Data
{
    public class ToDoDbContext : IdentityDbContext
    {
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Settings> Settings { get; set; }

        public string DbPath { get; }

        public ToDoDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "todo.db");
            Console.WriteLine(DbPath);
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");



        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=ToDoDatabase;Trusted_Connection=True");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            ToDo td1 = new ToDo
            {
                ToDoId = 1,
                Title = "First todo",
                DueBy = DateTime.UtcNow,
                CreatedTime = DateTime.UtcNow,
                Importance = 1
            };
            ToDo td2 = new ToDo
            {
                ToDoId = 2,
                Title = "Second todo",
                DueBy = DateTime.UtcNow,
                CreatedTime = DateTime.UtcNow,
                Importance = 9
            };

            modelBuilder.Entity<ToDo>().HasData(td1);
            modelBuilder.Entity<ToDo>().HasData(td2);

            ToDoList list1 = new ToDoList
            {
                ToDoListId = 1
            };

            modelBuilder.Entity<ToDoList>().HasData(list1);

            Settings defaultSettings = new Settings
            {
                SettingsId = 1,
                NumToDos = 1

            };
            modelBuilder.Entity<Settings>().HasData(defaultSettings);
        }

    }


}

