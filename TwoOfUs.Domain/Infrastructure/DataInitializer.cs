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


        }
    }
}
