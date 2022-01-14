using AMR_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.DAL
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        // DbSets
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<Ranobe> Ranobes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DubStudio> DubStudios { get; set; }
        public DbSet<ListAnimes> ListAnimes { get; set; }
        public DbSet<ListMangas> ListMangas { get; set; }
        public DbSet<ListRanobes> ListRanobes { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<MangaAuthor> MangaAuthors { get; set; }
        public DbSet<MangaTranslator> MangaTranslators { get; set; }
        public DbSet<MangaChapter> MangaChapters { get; set; }
        public DbSet<RanobeAuthor> RanobeAuthors { get; set; }
        public DbSet<RanobeTranslator> RanobeTranslators { get; set; }
        public DbSet<RanobePage> RanobePages { get; set; }
    }
}