using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.Models;
using AMR_Project.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages.Admin
{
    [Authorize]
    public class AddMangaModel : PageModel
    {

        private readonly ApplicationContext _db;

        public AddMangaModel(ApplicationContext db)
        {
            _db = db;
        }
        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            public String Name { get; set; }
            [Required]
            [DataType(DataType.Text)]
            public String OriginalName { get; set; }

            [DataType(DataType.Text)]
            public String JapanName { get; set; }

            [Required]
            [DataType(DataType.MultilineText)]
            public String Description { get; set; }
            public Int32 Year { get; set; }
            public Int32 ChapterCount { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public String Status { get; set; }

            [DataType(DataType.Text)]
            public String StatusOfTranslate { get; set; }

            [Required]
            public List<String> Genres { get; set; }

            [DataType(DataType.Upload)]
            public IFormFile MainImage { get; set; }
            public List<String> Tags { get; set; }

            [DataType(DataType.Text)]
            public String AgeRating { get; set; }

            [DataType(DataType.Text)]
            public String Type { get; set; }

            [DataType(DataType.Text)]
            public String PublishType { get; set; }

            [DataType(DataType.Text)]
            public String Author { get; set; }

            [DataType(DataType.Text)]
            public String Painter { get; set; }

            [DataType(DataType.Text)]
            public String Publisher { get; set; }

            [DataType(DataType.Text)]
            public String Translator { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public String Message { get; set; }

        public List<Genre> Genres { get; set; }
        public List<Tag> Tags { get; set; }
        public void OnGet()
        {
            Genres = _db.Genres.ToList();
            Tags = _db.Tags.ToList();
        }
        public void OnPost()
        {
            Genres = _db.Genres.ToList();
            Tags = _db.Tags.ToList();

            var manga = new Manga
            {
                Name = Input.Name,
                AgeRating = Input.AgeRating,
                ChapterCount = Input.ChapterCount,
                Description = Input.Description,
                Genres = new List<Genre>(),
                Tags = new List<Tag>(),
                JapanName = Input.JapanName,
                Year = Input.Year,
                Status = Input.Status,
                StatusOfTranslate = Input.StatusOfTranslate,
                PublishType = Input.PublishType,
                Publisher = Input.Publisher,
                Painter = Input.Painter,
                Type = Input.Type,
                OriginalName = Input.OriginalName

            };

            foreach (var inputGenre in Input.Genres)
            {
                foreach (var genre in Genres.Where(genre => inputGenre == genre.Name))
                {
                    manga.Genres.Add(genre);
                }
            }

            foreach (var t in Input.Tags)
            {
                foreach (var t1 in Tags.Where(t1 => t == t1.Name))
                {
                    manga.Tags.Add(t1);
                }
            }

            if (Input.MainImage != null)
            {
                byte[] imageData;
                using (var binaryReader = new BinaryReader(Input.MainImage.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)Input.MainImage.Length);
                }
                manga.MainImage = imageData;
            }

            var author = new MangaAuthor { Name = Input.Author, Mangas = new List<Manga>() };
            if (!_db.MangaAuthors.Any(a => a.Name == Input.Author))
            {
                author.Mangas.Add(manga);
                _db.Add(author);
            }
            else
            {
                author = _db.MangaAuthors.Single(a => a.Name.Equals(Input.Author));
                _db.Entry(author).Collection(t => t.Mangas).Load();
                author.Mangas.Add(manga);
            }
            var translator = new MangaTranslator { Name = Input.Translator, Mangas = new List<Manga>() };
            if (!_db.MangaTranslators.Any(t => t.Name == Input.Translator))
            {
                translator.Mangas.Add(manga);
                _db.Add(translator);
            }
            else
            {
                translator = _db.MangaTranslators.Single(t => t.Name.Equals(Input.Translator));
                _db.Entry(translator).Collection(t => t.Mangas).Load();
                translator.Mangas.Add(manga);
            }

            manga.Author = author;
            manga.Translator = translator;
            _db.Add(manga);
            _db.SaveChanges();
            Message = "Manga added successfully";
        }
    }
}