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
    public class AddRanobeModel : PageModel
    {
        private readonly ApplicationContext _db;

        public AddRanobeModel(ApplicationContext db)
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

            var ranobe = new Ranobe
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
                Publisher = Input.Publisher,
                Type = Input.Type,
                PublishType = Input.PublishType,
                OriginalName = Input.OriginalName

            };

            foreach (var inputGenre in Input.Genres)
            {
                foreach (var genre in Genres.Where(genre => inputGenre == genre.Name))
                {
                    ranobe.Genres.Add(genre);
                }
            }

            foreach (var t in Input.Tags)
            {
                foreach (var t1 in Tags.Where(t1 => t == t1.Name))
                {
                    ranobe.Tags.Add(t1);
                }
            }

            if (Input.MainImage != null)
            {
                byte[] imageData;
                using (var binaryReader = new BinaryReader(Input.MainImage.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)Input.MainImage.Length);
                }
                ranobe.MainImage = imageData;
            }

            var author = new RanobeAuthor { Name = Input.Author, Ranobes = new List<Ranobe>() };
            if (!_db.RanobeAuthors.Any(a => a.Name == Input.Author))
            {
                author.Ranobes.Add(ranobe);
                _db.Add(author);
            }
            else
            {
                author = _db.RanobeAuthors.Single(a => a.Name.Equals(Input.Author));
                _db.Entry(author).Collection(t => t.Ranobes).Load();
                author.Ranobes.Add(ranobe);
            }
            var translator = new RanobeTranslator { Name = Input.Translator, Ranobes = new List<Ranobe>() };
            if (!_db.RanobeTranslators.Any(t => t.Name == Input.Translator))
            {
                translator.Ranobes.Add(ranobe);
                _db.Add(translator);
            }
            else
            {
                translator = _db.RanobeTranslators.Single(t => t.Name.Equals(Input.Translator));
                _db.Entry(translator).Collection(t => t.Ranobes).Load();
                translator.Ranobes.Add(ranobe);
            }

            ranobe.Author = author;
            ranobe.Translator = translator;
            _db.Add(ranobe);
            _db.SaveChanges();
            Message = "Ranobe added successfully";
        }
    }
}
