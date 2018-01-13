using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoOfUs.Domain.Infrastructure
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<DataAccess>
    {
        protected override void Seed(DataAccess db)
        {
            #region Users
            db.Users.Add( 
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Jace",
                    LastName = "Beleren",
                    Password = "Accord605",
                    UserName = "jbeleren",
                    Role = Models.Enums.Role.Admin
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Liliana",
                    LastName = "Vess",
                    Password = "Accord605",
                    UserName = "lvess",
                    Role = Models.Enums.Role.Admin
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Gideon",
                    LastName = "Jura",
                    Password = "Accord605",
                    UserName = "gjura",
                    Role = Models.Enums.Role.Cashier
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Nissa",
                    LastName = "Revane",
                    Password = "Accord605",
                    UserName = "nrevane",
                    Role = Models.Enums.Role.Cashier
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Chandra",
                    LastName = "Nalaar",
                    Password = "Accord605",
                    UserName = "cnalaar",
                    Role = Models.Enums.Role.Chef
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Sorin",
                    LastName = "Markov",
                    Password = "Accord605",
                    UserName = "smarkov",
                    Role = Models.Enums.Role.Chef
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Tamiyo",
                    LastName = "Moonsage",
                    Password = "Accord605",
                    UserName = "tmoon",
                    Role = Models.Enums.Role.InventoryController
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Garruk",
                    LastName = "Wildspeaker",
                    Password = "Accord605",
                    UserName = "gwildspeaker",
                    Role = Models.Enums.Role.InventoryController
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Koth",
                    LastName = "Hammer",
                    Password = "Accord605",
                    UserName = "chammer",
                    Role = Models.Enums.Role.Waiter
                }
            );
            db.SaveChanges();

            db.Users.Add(
                new Models.User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Elpeth",
                    LastName = "Tirel",
                    Password = "Accord605",
                    UserName = "etirel",
                    Role = Models.Enums.Role.Waiter
                }
            );
            db.SaveChanges();
            #endregion

            #region Categories
            db.Categories.Add(
                new Models.Category()
                {
                    Id = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac0"),
                    Name = "Beverages"                    
                }
            );
            db.SaveChanges();

            db.Categories.Add(
                new Models.Category()
                {
                    Id = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac1"),
                    Name = "Alcoholic",
                    ParentId = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac0")
                }
            );
            db.SaveChanges();

            db.Categories.Add(
                new Models.Category()
                {
                    Id = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac2"),
                    Name = "Non-alcoholic",
                    ParentId = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac0")
                }
            );
            db.SaveChanges();
            #endregion

            #region Products
            db.Products.Add(
                new Models.Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Beer",
                    CategoryId = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac1"),
                    Price = decimal.Parse("50")
                }
            );
            db.SaveChanges();

            db.Products.Add(
                new Models.Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Rhum",
                    CategoryId = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac1"),
                    Price = decimal.Parse("750")
                }
            );
            db.SaveChanges();

            db.Products.Add(
                new Models.Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Whiskey",
                    CategoryId = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac1"),
                    Price = decimal.Parse("550")
                }
            );
            db.SaveChanges();

            db.Products.Add(
                new Models.Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Juice",
                    CategoryId = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac2"),
                    Price = decimal.Parse("50")
                }
            );
            db.SaveChanges();

            db.Products.Add(
                new Models.Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Soda",
                    CategoryId = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac2"),
                    Price = decimal.Parse("40")
                }
            );
            db.SaveChanges();

            db.Products.Add(
                new Models.Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "Shake",
                    CategoryId = Guid.Parse("9f701a1e-e90a-4f23-8434-7c8372de0ac2"),
                    Price = decimal.Parse("80")
                }
            );
            db.SaveChanges();
            #endregion
        }
    }
}
