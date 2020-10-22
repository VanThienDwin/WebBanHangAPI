using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SaleWebsiteAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaleWebsiteAPI.Extention
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category
               {
                   id = 1,
                   generalityName = "Quần Áo",
                   name = "Áo Sơ Mi",
                   status = Enums.ActionStatus.Display
               },
               new Category
               {
                   id = 2,
                   generalityName = "Quần Áo",
                   name = "Quần Tây",
                   status = Enums.ActionStatus.Display
               },
               new Category
               {
                   id = 3,
                   generalityName = "Quần Áo",
                   name = "Áo Thun",
                   status = Enums.ActionStatus.Display
               },
               new Category
               {
                   id = 4,
                   generalityName = "Quần Áo",
                   name = "Quần Kaki",
                   status = Enums.ActionStatus.Display
               }
           );

            //Provider
            modelBuilder.Entity<Provider>().HasData(
                new Provider { id = 1, name = "Việt Tiến", status = Enums.ActionStatus.Display },
                new Provider { id = 2, name = "Cty May Sông Hồng", status = Enums.ActionStatus.Display },
                new Provider { id = 3, name = "Cty May Nhà Bè", status = Enums.ActionStatus.Display },
                new Provider { id = 4, name = "Cty Giditex", status = Enums.ActionStatus.Display },
                new Provider { id = 5, name = "Cty Vinatex", status = Enums.ActionStatus.Display }
                );

            //Product
            modelBuilder.Entity<Product>().HasData(new Product
            {
                id = 1,
                name = "Áo Sơ Mi",
                importPrice = 100000,
                price = 150000,

                rating = 5,
                description = "mô tả sản phẩm 1",
                status = Enums.ActionStatus.Display,
                color = Color.blue,
                size = Size.L,
                categoryId = 1,
                providerId = 1
            },
             new Product
             {
                 id = 2,
                 name = "Áo Sơ Mi Tay Ngắn",
                 importPrice = 80000,
                 price = 120000,
                 rating = 5,

                 description = "mô tả sản phẩm 2",
                 status = Enums.ActionStatus.Display,
                 color = Color.red,
                 size = Size.X,
                 categoryId = 1,
                 providerId = 2
             },
             new Product
             {
                 id = 3,
                 name = "Quần Tây",
                 importPrice = 200000,
                 price = 250000,
                 rating = 5,

                 description = "mô tả sản phẩm 3",
                 status = Enums.ActionStatus.Display,
                 color = Color.blue,
                 size = Size.L,
                 categoryId = 2,
                 providerId = 3
             },
             new Product
             {
                 id = 4,
                 name = "Áo Thun",
                 importPrice = 50000,
                 price = 75000,
                 rating = 5,

                 description = "mô tả sản phẩm 4",
                 status = Enums.ActionStatus.Display,
                 color = Color.black,
                 size = Size.L,
                 categoryId = 3,
                 providerId = 4
             },
             new Product
             {
                 id = 5,
                 name = "Quần Kaki",
                 importPrice = 180000,
                 price = 220000,
                 rating = 5,

                 description = "mô tả sản phẩm 5",
                 status = Enums.ActionStatus.Display,
                 color = Color.gray,
                 size = Size.L,
                 categoryId = 4,
                 providerId = 5
             }
             );
            // user - role
            var adminId = new Guid("4557893F-1F56-4B6F-BB3B-CAEFD62C8C49");
            var roleId = new Guid("078269D8-1A12-4592-B92E-7FF1A876A5F2");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "Admin",
                Description = "Administrator role",
            },
                new AppRole
                {
                    Id = new Guid("6D9186BA-2CD6-4B6C-B729-4E605DE1019F"),
                    Name = "User",
                    NormalizedName = "User",
                    Description = "User role",
                }
            );

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                displayname = "Admin",
                Email = "thienvovan0112@gmail.com",
                NormalizedEmail = "some-admin-email@nonce.fake",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "vanthiendwin@1998"),

                status = Enums.ActionStatus.Display,
                SecurityStamp = string.Empty,
                birthDay = new DateTime(1998, 12, 01)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

        }
    }
}
