using Microsoft.EntityFrameworkCore;
using ReadingIsGood.Core.Entities.Concrete;
using System;

namespace ReadingIsGood.DataAccess.Extensions
{
    public static class SeedExtensions
    {
        public static void AddSeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author
            {
                Id = "6aaf0cc9-0595-4b51-9331-d1618a594bd1",
                FirstName = "Berk",
                LastName = "Berk",
                IsActive = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            });


            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = "b36be2c3-8e51-41c5-a5e2-328f7dba4d83",
                Name = "Programlama",
                ParentId = ""
            });

            modelBuilder.Entity<Book>().HasData(new Book
            {
                Id = "09c8704f-c7cf-4144-a456-c22d1100c0bd",
                Name = "ASP.Net",
                ISBN = "9786052118689",
                AuthorId = "6aaf0cc9-0595-4b51-9331-d1618a594bd1",
                CreatedAt = DateTime.Now,
                Description = "Lorem ipsum dolar sit amet",
                Pages = 200,
                IsActive = true,
                UnitPrice = 25,
                UnitsInStock = 100,
                UpdatedAt = DateTime.Now,
                YearOfPublication = 1950

            });

            modelBuilder.Entity<BookCategory>().HasData(new BookCategory
            {
                Id = "23b13dd2-0805-489b-bd8f-9a3046bac6db",
                BookId = "09c8704f-c7cf-4144-a456-c22d1100c0bd",
                CategoryId = "b36be2c3-8e51-41c5-a5e2-328f7dba4d83"
            });
        }
    }
}
