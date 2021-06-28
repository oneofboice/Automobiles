using AutomobilesApi.Models;
using AutomobilesApi.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace AutomobilesCore.Database
{
    public class AutomobilesDbContext : DbContext
    {
        public DbSet<Body> Bodies { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Automobile> Automobiles { get; set; }

        public AutomobilesDbContext(DbContextOptions<AutomobilesDbContext> options)
            : base(options)
        {
            if (!Database.CanConnect())
            {
                try
                {
                    Database.EnsureDeleted();
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Database.EnsureCreated();
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand[]
                {
                    new Brand(1, "Audi"),
                    new Brand(2, "Ford"),
                    new Brand(3, "Jeep"),
                    new Brand(4, "Nissan"),
                    new Brand(5, "Toyota")
                });

            modelBuilder.Entity<Dealer>().HasData(
                new Dealer[]
                {
                    new Dealer(1, "https://www.audi.ru/"),
                    new Dealer(2, "https://www.ford.ru/"),
                    new Dealer(3, "https://www.jeep-russia.ru/"),
                    new Dealer(4, "https://www.nissan.ru/"),
                    new Dealer(5, "https://www.toyota.ru/"),
                });

            modelBuilder.Entity<Model>().HasData(
                new Model[]
                {
                    new Model(1, 1, "A3"),
                    new Model(2, 1, "A5"),
                    new Model(3, 2, "Fiesta"),
                    new Model(4, 2, "Focus"),
                    new Model(5, 3, "Renegade"),
                    new Model(6, 4, "Serena"),
                    new Model(7, 5, "RAV4")
                });

            modelBuilder.Entity<Body>().HasData(
                new Body[]
                {
                    new Body(BodyType.Sedan),
                    new Body(BodyType.Hatchback),
                    new Body(BodyType.StationWagon),
                    new Body(BodyType.Minivan),
                    new Body(BodyType.SUV),
                    new Body(BodyType.Coupe)
                });

            long id = 1;

            var imagesDirectory = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images");

            modelBuilder.Entity<Automobile>().HasData(
                new Automobile[]
                {
                    new Automobile(id++, 1, (int)BodyType.Sedan, 4, File.ReadAllBytes(Path.Combine(imagesDirectory, "audi-a3.jpg")), 1),
                    new Automobile(id++, 1, (int)BodyType.Hatchback, 4, File.ReadAllBytes(Path.Combine(imagesDirectory, "audi-a3-sportback.jpg"))),
                    new Automobile(id++, 2, (int)BodyType.Coupe, 2, File.ReadAllBytes(Path.Combine(imagesDirectory, "audi-a5-coupe.jpg")), 1),
                    new Automobile(id++, 2, (int)BodyType.Hatchback, 4, File.ReadAllBytes(Path.Combine(imagesDirectory, "audi-a5-sportback.jpg"))),
                    new Automobile(id++, 3, (int)BodyType.Sedan, 4, File.ReadAllBytes(Path.Combine(imagesDirectory, "ford-fiesta.jpg")), 2),
                    new Automobile(id++, 4, (int)BodyType.StationWagon, 4, File.ReadAllBytes(Path.Combine(imagesDirectory, "ford-focus.jpg")), 3),
                    new Automobile(id++, 4, (int)BodyType.Hatchback, 4, File.ReadAllBytes(Path.Combine(imagesDirectory, "ford-focus.jpg"))),
                    new Automobile(id++, 5, (int)BodyType.SUV, 4, File.ReadAllBytes(Path.Combine(imagesDirectory, "jeep-renegade-suv.png")), 4),
                    new Automobile(id++, 5, (int)BodyType.SUV, 5, File.ReadAllBytes(Path.Combine(imagesDirectory, "jeep-renegade-suv.png"))),
                    new Automobile(id++, 6, (int)BodyType.Minivan, 7, File.ReadAllBytes(Path.Combine(imagesDirectory, "nissan-serena.jpg")), 5),
                    new Automobile(id++, 7, (int)BodyType.StationWagon, 6, File.ReadAllBytes(Path.Combine(imagesDirectory, "toyota-rav4.png"))),
                });
        }
    }
}
