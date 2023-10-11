
using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using OskiTest.Models;
using OskiTest.Services;
using System;
using System.Collections.Generic;


namespace OskiTest.Data
{
    public class DBContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { set; get; }
        public DbSet<Anser> Ansers { set; get; }
        public DbSet<Question> Questions { set; get; }
        public DbSet<Test> Tests { set; get; }


        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            Role adminRole = new Role { Id = Guid.NewGuid().ToString(), RoleName = adminRoleName };
            Role userRole = new Role { Id = Guid.NewGuid().ToString(), RoleName = userRoleName };

            string adminEmail = "admin@gmail.com";
            string adminPassword = Crypto.HashPassword("123456");
            string userEmail = "user@gmail.com";
            string userPassword = Crypto.HashPassword("123456");

            User adminUser = new User { Id = Guid.NewGuid().ToString(), UserName = "Alex", Email = adminEmail, Password = adminPassword, RoleId = adminRole.Id };
            User simpleUser = new User { Id = Guid.NewGuid().ToString(), UserName = "user", Email = userEmail, Password = userPassword, RoleId = userRole.Id };

            

           /* Topic topic1 = new Topic
            {
                Id = Guid.NewGuid().ToString(),
                RoleName = "Test topic 1",
                
            };

            Topic topic2 = new Topic
            {
                Id = Guid.NewGuid().ToString(),
                RoleName = "Test topic 2",
            };

            Post post1 = new Post
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. ",
                DateCreation = DateTime.Now,
                UserId = adminUser.Id,
                TopicId = topic1.Id
            };

            Post post2 = new Post
            {
                Id = Guid.NewGuid().ToString(),
                Text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. ",
                DateCreation = DateTime.Now,
                UserId = simpleUser.Id,
                TopicId = topic2.Id

            };*/

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser, simpleUser });
            /*modelBuilder.Entity<Topic>().HasData(new Topic[] { topic1, topic2 });
            modelBuilder.Entity<Post>().HasData(new Post[] { post1, post2 });*/
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
