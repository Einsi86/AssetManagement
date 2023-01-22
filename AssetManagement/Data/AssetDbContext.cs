using Microsoft.EntityFrameworkCore;
using AssetManagement.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;

namespace AssetManagement.Data
{
    public class AssetDbContext : DbContext
    {

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<AssetType> AssetTypes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AssetDB;Trusted_Connection=true;Encrypt=False");

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            User u1 = new User { UserId = 1, Email = "abc@email.com", Name = "Einar", Location = "RVK", Phone = "1111111", };
            User u2 = new User { UserId = 2, Email = "abc2@email.com", Name = "Jón", Location = "RVK", Phone = "2222222", };

            modelBuilder.Entity<User>().HasData(u1);
            modelBuilder.Entity<User>().HasData(u2);



            AssetType at1 = new AssetType { AssetTypeId = 1, Description = "Fartölva" };
            AssetType at2 = new AssetType { AssetTypeId = 2, Description = "Borðtölva" };

            modelBuilder.Entity<AssetType>().HasData(at1);
            modelBuilder.Entity<AssetType>().HasData(at2);



            Status s1 = new Status { StatusId = 1, Description = "Í lagi" };
            Status s2 = new Status { StatusId = 2, Description = "Bilað" };

            modelBuilder.Entity<Status>().HasData(s1);
            modelBuilder.Entity<Status>().HasData(s2);


            
            Asset as1 = new Asset { AssetId = 1, Description = "Dell Fartölva", LongDescription = "Dell latitude 7420", AssetTypeId = 1, StatusId = 1, UserId = 1 };

            modelBuilder.Entity<Asset>().HasData(as1);
           

        }


    }

 }
    