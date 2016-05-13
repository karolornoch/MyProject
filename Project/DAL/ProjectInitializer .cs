using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Project.Models;
using Projekt.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project.DAL
{
    public class ProjectInitializer : DropCreateDatabaseIfModelChanges<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            var roleManger = new RoleManager<IdentityRole>(
                           new RoleStore<IdentityRole>(new ApplicationDbContext()));
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(new ApplicationDbContext()));

            roleManger.Create(new IdentityRole("Admin"));

            var user = new ApplicationUser { UserName = "karol@gmail.com" };
            string password = "Complex.Password.123";

            userManager.Create(user, password);
            userManager.AddToRole(user.Id, "Admin");

            var categories = new List<Category>
            {
                new Category {Name="Kategoria 1" , Description="opis1" },
                new Category {Name="Kategoria 2" , Description="opis2" },
                new Category {Name="Kategoria 3" , Description="opis3" },
                new Category {Name="Kategoria 4" , Description="opis4" }
            };
            categories.ForEach(c => context.Categories.Add(c));
            var books = new List<Book>
            {
                new Book{Title = "Ogniem i mieczem",Author="Henryk Sienkiewicz",Category= categories[0]},
                new Book{Title = "Tytul1",Author="Autor1",Category= categories[0]},
                new Book{Title = "Tytul2",Author="Autor2",Category= categories[0]},
                new Book{Title = "Tytul3",Author="Autor3",Category= categories[0]},
                new Book{Title = "Tytul4",Author="Autor4",Category= categories[0]},
                new Book{Title = "Tytul5",Author="Autor5",Category= categories[0]},
                new Book{Title = "Tytul6",Author="Autor6",Category= categories[0]},
                new Book{Title = "Tytul7",Author="Autor7",Category= categories[0]}
            };
            books.ForEach(b => context.Books.Add(b));
            var readers = new List<Reader>
            {
                new Reader {Name="Karol", Surname="Matyszewski" },
                new Reader {Name="Andrzej", Surname="Nowak" },
                new Reader {Name="Maciej", Surname="Kot" },
                new Reader {Name="Robert", Surname="Kowalski" },
                new Reader {Name="Janusz", Surname="Nowicki" }
            };
            readers.ForEach(r => context.Readers.Add(r));
            var rents = new List<Rent>
            {
                new Rent {BookID= 1, ReaderID=1,DateOfRent=new DateTime(2016,05,11), DateOfReturn = new DateTime(2016,05,25)}
            };
            rents.ForEach(r => context.Rents.Add(r));
            context.SaveChanges();
        }
    }
}