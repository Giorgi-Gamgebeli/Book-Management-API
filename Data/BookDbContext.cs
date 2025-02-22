using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Data
{
    public class BooksDbContext(DbContextOptions<BooksDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Book>()
                .HasData(
                    new Book
                    {
                        Id = 1,
                        Title = "The Knight in the Panther's Skin",
                        PublicationYear = 1189,
                        AuthorName = "Shota Rustaveli",
                        BookViews = 500,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 2,
                        Title = "Data Tutashkhia",
                        PublicationYear = 1975,
                        AuthorName = "Chabua Amirejibi",
                        BookViews = 300,
                        IsDeleted = true,
                    },
                    new Book
                    {
                        Id = 3,
                        Title = "The First Step",
                        PublicationYear = 1890,
                        AuthorName = "Vazha-Pshavela",
                        BookViews = 250,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 4,
                        Title = "Me, Grandma, Iliko and Ilarioni",
                        PublicationYear = 1960,
                        AuthorName = "Nodar Dumbadze",
                        BookViews = 400,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 5,
                        Title = "The Father of Soldiers",
                        PublicationYear = 1964,
                        AuthorName = "David Kldiashvili",
                        BookViews = 180,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 6,
                        Title = "The Right Hand of the Grand Master",
                        PublicationYear = 1939,
                        AuthorName = "Konstantine Gamsakhurdia",
                        BookViews = 350,
                        IsDeleted = true,
                    },
                    new Book
                    {
                        Id = 7,
                        Title = "Davitiani",
                        PublicationYear = 1787,
                        AuthorName = "David Guramishvili",
                        BookViews = 200,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 8,
                        Title = "Spring in Kartli",
                        PublicationYear = 1881,
                        AuthorName = "Alexander Kazbegi",
                        BookViews = 275,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 9,
                        Title = "The Wine-Cellar",
                        PublicationYear = 1890,
                        AuthorName = "Ilia Chavchavadze",
                        BookViews = 320,
                        IsDeleted = true,
                    },
                    new Book
                    {
                        Id = 10,
                        Title = "The Conductor",
                        PublicationYear = 1962,
                        AuthorName = "Otar Chiladze",
                        BookViews = 290,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 11,
                        Title = "The Dream of the Mountain",
                        PublicationYear = 1985,
                        AuthorName = "Zviad Kharadze",
                        BookViews = 290,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 12,
                        Title = "The Homeland of the Brave",
                        PublicationYear = 1950,
                        AuthorName = "Temur Aghiashvili",
                        BookViews = 350,
                        IsDeleted = true,
                    },
                    new Book
                    {
                        Id = 13,
                        Title = "Echoes of the Mountains",
                        PublicationYear = 1925,
                        AuthorName = "Otar Chiladze",
                        BookViews = 300,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 14,
                        Title = "Whispers of the Past",
                        PublicationYear = 1934,
                        AuthorName = "Sandro Shanshiashvili",
                        BookViews = 410,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 15,
                        Title = "The Last Song of the Wind",
                        PublicationYear = 1870,
                        AuthorName = "Akvani Lomaia",
                        BookViews = 370,
                        IsDeleted = true,
                    },
                    new Book
                    {
                        Id = 16,
                        Title = "Journey Through the Forgotten Lands",
                        PublicationYear = 1960,
                        AuthorName = "Levan Lomidze",
                        BookViews = 420,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 17,
                        Title = "A Mother's Love",
                        PublicationYear = 1950,
                        AuthorName = "Giorgi Kharshiladze",
                        BookViews = 260,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 18,
                        Title = "Through the Eyes of the Brave",
                        PublicationYear = 1920,
                        AuthorName = "Giorgi Nikoladze",
                        BookViews = 300,
                        IsDeleted = true,
                    },
                    new Book
                    {
                        Id = 19,
                        Title = "The Silent River",
                        PublicationYear = 1945,
                        AuthorName = "Niko Gvetadze",
                        BookViews = 250,
                        IsDeleted = false,
                    },
                    new Book
                    {
                        Id = 20,
                        Title = "Winds of Destiny",
                        PublicationYear = 1910,
                        AuthorName = "Soslan Geleishvili",
                        BookViews = 330,
                        IsDeleted = true,
                    }
                );
        }
    }
}
