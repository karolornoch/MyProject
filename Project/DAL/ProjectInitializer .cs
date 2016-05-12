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
                new Category {Name="Kategoria 1" , Description="opis1" }
            };
            categories.ForEach(c => context.Categories.Add(c));
            var books = new List<Book>
            {
                new Book{Title = "Ogniem i mieczem",Author="Henryk Sienkiewicz",Category= categories[0]}
            };
            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}