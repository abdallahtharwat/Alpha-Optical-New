
using Alpha.Models;
using Alpha.Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alpha.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> brands { get; set; }

        public DbSet<Lenstype>  lenstypes { get; set; }
        public DbSet<Product>  products { get; set; }
        public DbSet<ProductImage> productImages { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<OrderHeader> orderHeaders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Low Lights", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Average Light", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Strong Light", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Brand>().HasData(
             new Brand { Id = 1, Name = "Ray-Ban", DisplayOrder = 1 },
             new Brand { Id = 2, Name = "Warby Parker", DisplayOrder = 2 },
             new Brand { Id = 3, Name = "Gucci", DisplayOrder = 3 }
               
             );

            modelBuilder.Entity<Lenstype>().HasData(
           new Lenstype { Id = 1, Name = "Low Lights", DisplayOrder = 1 },
           new Lenstype { Id = 2, Name = "Average Light", DisplayOrder = 2 },
           new Lenstype { Id = 3, Name = "Strong Light", DisplayOrder = 3 }
           );


            modelBuilder.Entity<Company>().HasData(
            new Company
            {
                Id = 1,
                Name = "Tech Solution",
                StreetAddress = "123 Tech St",
                City = "Tech City",
                PostalCode = "12121",
                State = "IL",
                PhoneNumber = "6669990000"
            },
            new Company
            {
                Id = 2,
                Name = "Vivid Books",
                StreetAddress = "999 Vid St",
                City = "Vid City",
                PostalCode = "66666",
                State = "IL",
                PhoneNumber = "7779990000"
            },
            new Company
            {
                Id = 3,
                Name = "Readers Club",
                StreetAddress = "999 Main St",
                City = "Lala land",
                PostalCode = "99999",
                State = "NY",
                PhoneNumber = "1113335555"
            }
        );



            modelBuilder.Entity<Product>().HasData(

                 new Product
                 {
                     Id = 1,
                     Title = "Dalston",
                     Description = "\r\nFashion TR90 Square Computer Glasses Anti-blue Ray Eyewear Frame-5025-ShiningBlac ",
                     ISBN = "SWD9999001",
                     Color = "Black",
                     ListPrice = 2250,
                     Price = 1970,
                     Price5 = 1630,
                     Price10 = 1420,
                     CategoryId = 1,
                     BrandId = 2,
                     LenstypeId = 1
                   
                 },
                 new Product
                 {
                     Id = 2,
                     Title = "Dalston Sun",
                     Color = "Black Noir",
                     Description = "\r\nFashion TR90 Square Computer Glasses Anti-blue Ray Eyewear Frame-5025-ShiningBlac ",
                     ISBN = "CAW777777701",
                     ListPrice = 1920,
                     Price = 1830,
                     Price5 = 1660,
                     Price10 = 1350,
                     CategoryId = 2,
                     BrandId = 3,
                     LenstypeId = 3
                  
                 },
                 new Product
                 {
                     Id = 3,
                     Title = "Le Marais Sun",
                     Color = "Dark Green",
                     Description = "\r\nFashion TR90 Square Computer Glasses Anti-blue Ray Eyewear Frame-5025-ShiningBlac ",
                     ISBN = "RITO5555501",
                     ListPrice = 750,
                     Price = 690,
                     Price5 = 510,
                     Price10 = 440,
                     CategoryId = 10,
                     BrandId = 1,
                     LenstypeId =2
                 
                 },
                 new Product
                 {
                     Id = 4,
                     Title = "Osterbro",
                     Color = "Navy Blue",
                     Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                     ISBN = "WS3333333301",
                     ListPrice = 970,
                     Price = 830,
                     Price5 = 700,
                     Price10 = 580,
                     CategoryId = 2,
                     BrandId = 3,
                     LenstypeId = 3
                   
                 },
                 new Product
                 {
                     Id = 5,
                     Title = "Ginza Sun",
                     Color = "Silver Matte",
                     Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                     ISBN = "SOTJ1111111101",
                     ListPrice = 300,
                     Price = 270,
                     Price5 = 175,
                     Price10 = 120,
                     CategoryId = 10,
                     BrandId = 2,
                     LenstypeId = 2
                   
                 }
                
                 );



        }



        }
    }
