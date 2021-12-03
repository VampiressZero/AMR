using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages
{
    public class AdminModel : PageModel
    {
        private readonly ApplicationContext _db;

        public AdminModel(ApplicationContext db)
        {
            _db = db;
        }
        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            public String Name { get; set; }

            [DataType(DataType.Text)]
            public String Studio { get; set; }

            [Required]
            [DataType(DataType.MultilineText)]
            public String Description { get; set; }

            public Int32 CountEpisodes { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public String Status { get; set; }
            public List<Genre> Genres { get; set; }

            [DataType(DataType.Upload)]
            public IFormFile MainImage { get; set; }
            // public List<Byte[]> Screenshots { get; set; }
            public Int32 Year { get; set; }
            public List<DubStudio> DubStudios { get; set; }
            public List<Tag> Tags { get; set; }

            [DataType(DataType.Text)]
            public String AgeRating { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            var anime = new Anime {Name = Input.Name,
                                   Studio = Input.Studio,
                                   Description = Input.Description,
                                   CountEpisodes = Input.CountEpisodes,
                                   Status = Input.Status,
                                   Genres = Input.Genres,
                                   Year = Input.Year,
                                   AgeRating = Input.AgeRating
            };
            if (Input.MainImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(Input.MainImage.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)Input.MainImage.Length);
                }
                // установка массива байтов
                anime.MainImage = imageData;
            }
            _db.Add(anime);
            _db.SaveChanges();
        }
    }
}
