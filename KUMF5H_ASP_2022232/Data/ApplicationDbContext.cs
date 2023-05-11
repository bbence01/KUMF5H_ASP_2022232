using KUMF5H_ASP_2022232.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Emit;


namespace KUMF5H_ASP_2022232.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
      
            public DbSet<FoodUser> Users { get; set; }
            public DbSet<FoodRequest> Foodrequests { get; set; }
            public DbSet<Offer> Offers { get; set; }

            public DbSet<Comment> Comments { get; set; }

            public DbSet<Ingredient> Ingredients { get; set; }

            public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
            {
            }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                // Connections
                builder.Entity<FoodRequest>().HasOne(p => p.Requestor)
                    .WithMany(u => u.FoodRequests)
                    .HasForeignKey(p => p.RequestorId)
                    .OnDelete(DeleteBehavior.NoAction);


                builder.Entity<Offer>().HasOne(p => p.Request)
                        .WithMany(u => u.Offers)
                        .HasForeignKey(p => p.FoodId)
                        .OnDelete(DeleteBehavior.Cascade);

                builder.Entity<Offer>().HasOne(p => p.User)
                        .WithMany(u => u.Offers)
                        .HasForeignKey(p => p.ContractorId)
                        .OnDelete(DeleteBehavior.Cascade);

                builder.Entity<Comment>().HasOne(p => p.Request)
                      .WithMany(u => u.Comments)
                      .HasForeignKey(p => p.RequestId)
                      .OnDelete(DeleteBehavior.Cascade);

                builder.Entity<Comment>().HasOne(p => p.User)
                       .WithMany(u => u.Comments)
                       .HasForeignKey(p => p.ContractorId)
                       .OnDelete(DeleteBehavior.Cascade);

                builder.Entity<Ingredient>().HasOne(p => p.Requests)
                      .WithMany(u => u.Ingridients)
                      .HasForeignKey(p => p.FoodId)
                      .OnDelete(DeleteBehavior.Cascade);



                builder.Entity<IdentityRole>().HasData(
                     new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                     new { Id = "2", Name = "User", NormalizedName = "USER" }
                );

                PasswordHasher<FoodUser> ph = new PasswordHasher<FoodUser>();
                FoodUser seed = new FoodUser
                {
                    Id = Guid.NewGuid().ToString(),
                    Email = "seedplayer@gmail.com",
                    EmailConfirmed = true,
                    UserName = "seedplayer@gmail.com",
                    FoodUserName = "SeedPlayer",
                    NormalizedUserName = "SEEDPLAYER@gmail.com"
                };
                seed.PasswordHash = ph.HashPassword(seed, "almafa123");
                var hasher = new PasswordHasher<FoodUser>();

                var bence = new FoodUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    UserName = "bence@gmail.com",
                    NormalizedUserName = "BENCE@GMAIL.COM",
                    FoodUserName = "bence@gmail.com",
                    FirstName = "Bence",
                    LastName = "Bognár",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                };

                var anita = new FoodUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = "anita@gmail.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "ANITA@GMAIL.COM",
                    FoodUserName = "anita@gmail.com",
                    FirstName = "Anita",
                    LastName = "Koczó",
                    PasswordHash = hasher.HashPassword(null, "password")
                };

                var tibi = new FoodUser()
                {

                    Id = Guid.NewGuid().ToString(),
                    UserName = "tibi@gmail.com",
                    EmailConfirmed = true,
                    NormalizedUserName = "TIBI@GMAIL.COM",
                    FoodUserName = "tibi@gmail.com",

                    FirstName = "Tibor",
                    LastName = "Bognár",
                    PasswordHash = hasher.HashPassword(null, "password")
                };

                //Seeding the FoodUser to AspNetUsers table
                builder.Entity<FoodUser>().HasData(bence, anita, tibi);

                FoodRequest f = new FoodRequest()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Susi",
                    Description = "Nyers hal",
                    RequestorId = bence.Id,
                    Picture = this.LoadSeedPicture("Seed/susi.jpg"),
                    PictureContentType = "Image/jpeg",
                    //Ingridients = new List<string> { "Hal","Rizs"}

                };

                FoodRequest p2 = new FoodRequest()
                {
                    Id = Guid.NewGuid().ToString(),

                    Name = "Stake",
                    Description = "Sülthus",
                    RequestorId = bence.Id,
                    Picture = this.LoadSeedPicture("Seed/steak.jpg"),
                    PictureContentType = "Image/jpeg",
                    // Ingridients = new List<string> { "Marha", "Bors" }
                };

                FoodRequest f3 = new FoodRequest()
                {
                    Id = "3",

                    Name = "Toast",
                    Description = "Tosted.",
                    RequestorId = anita.Id,
                    Picture = this.LoadSeedPicture("Seed/toast.jpg"),
                    PictureContentType = "Image/jpeg",
                    // Ingridients = new List<string> { "Tojás", "Kenyér" }
                };

                FoodRequest f4 = new FoodRequest()
                {
                    Id = "4",

                    Name = "Chocklate ckae",
                    Description = "All the chocklate",
                    RequestorId = anita.Id,
                    Picture = this.LoadSeedPicture("Seed/chokocake.jpg"),
                    PictureContentType = "Image/png",
                    // Ingridients = new List<string> { "Chokolate", "vaj","List" }
                };

                FoodRequest f5 = new FoodRequest()
                {
                    Id = "5",

                    Name = "Mirror ckae",
                    Description = "I want to see myself eating",
                    RequestorId = anita.Id,
                    Picture = this.LoadSeedPicture("Seed/mirrorcake.jpg"),
                    PictureContentType = "Image/jpeg",
                    // Ingridients = new List<string> { "vaj", "List" }
                };

                builder.Entity<FoodRequest>().HasData(f, p2, f3, f4, f5);

                Offer o1 = new Offer()
                {

                    FoodId = f3.Id,
                    ContractorId = bence.Id
                };

                Offer o2 = new Offer()
                {

                    FoodId = f3.Id,
                    ContractorId = tibi.Id
                };

                Offer o3 = new Offer()
                {

                    FoodId = f4.Id,
                    ContractorId = tibi.Id
                };



                Comment c1 = new Comment()
                {
                    Text = "Hi",
                    RequestId = f3.Id,
                    ContractorId = tibi.Id
                };

                Comment c2 = new Comment()
                {
                    Text = "Hello",
                    RequestId = f4.Id,
                    ContractorId = tibi.Id
                };


                Ingredient i1 = new Ingredient()
                {
                    Name = "Hal",
                    FoodId = f.Id,
                    Description = "Tuna"
                };

                Ingredient i2 = new Ingredient()
                {
                    Name = "Rizs",
                    FoodId = f.Id,
                    Description = "Rizs"
                };


                Ingredient i3 = new Ingredient()
                {
                    Name = "Choko",
                    FoodId = f4.Id,
                    Description = "Dark"
                };




                builder.Entity<Offer>().HasData(o1, o2, o3);



                builder.Entity<Comment>().HasData(c1, c2);

                builder.Entity<Ingredient>().HasData(i1, i2, i3);

                base.OnModelCreating(builder);
            }

            private byte[] LoadSeedPicture(string path)
            {
                return File.ReadAllBytes(path);
            }
        }
    }
