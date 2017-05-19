using System.Collections.Generic;
using BLS.Core.Data;
using BLS.Data.BLDbContext;

namespace BLS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BlDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BlDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            var books = new List<Book>
            {
                new Book
                {
                    Title = "The History of England",
                    Author = "William de Normandie",
                    Isbn = "123456789",
                    Edition = "1st Edition",
                    Publisher = "England",
                    PublishedDate = new DateTime(2017,5,18),
                    AddedDate = new DateTime(2017,5,18),
                    ModifiedDate = new DateTime(2017,5,18)
                },
                new Book
                {
                    Title = "The History of France",
                    Author = "Philip de Capet",
                    Isbn = "987654321",
                    Edition = "2nd Edition",
                    Publisher = "France",
                    PublishedDate = new DateTime(2017,5,19),
                    AddedDate = new DateTime(2017,5,19),
                    ModifiedDate = new DateTime(2017,5,19)
                },
                new Book
                {
                    Title = "The History of Spain",
                    Author = "Alfonso de Castille",
                    Isbn = "789654321",
                    Edition = "3rd Edition",
                    Publisher = "Spain",
                    PublishedDate = new DateTime(2017,5,20),
                    AddedDate = new DateTime(2017,5,20),
                    ModifiedDate = new DateTime(2017,5,20)
                }
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}
