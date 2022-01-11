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
    public class AddAnimeModel : PageModel
    {
        private readonly ApplicationContext _db;
        
        public AddAnimeModel(ApplicationContext db)
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
            [Required]
            [DataType(DataType.Text)]
            public String JapanName { get; set; }
            [DataType(DataType.Text)]
            public String EnglishName { get; set; }

            [DataType(DataType.Text)]
            public String Studio { get; set; }

            [Required]
            [DataType(DataType.MultilineText)]
            public String Description { get; set; }
            public Int32 CountEpisodes { get; set; }

            [Required]
            [DataType(DataType.Text)]
            public String Status { get; set; }

            [Required]
            public List<String> Genres { get; set; }

            [DataType(DataType.Upload)]
            public IFormFile MainImage { get; set; }
            public List<String> DubStudios { get; set; }
            public List<String> Tags { get; set; }

            [DataType(DataType.Text)]
            public String AgeRating { get; set; }

            [DataType(DataType.Text)]
            public String Source { get; set; }

            [DataType(DataType.Text)]
            public String Type { get; set; }

            [DataType(DataType.Text)]
            public String Duration { get; set; }
            [DataType(DataType.DateTime)]
            public DateTime StartDate { get; set; }
            [DataType(DataType.DateTime)]
            public DateTime EndDate { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public String Message { get; set; }

        public List<Genre> Genres { get; set; }
        public List<DubStudio> DubStudios { get; set; }
        public List<Tag> Tags { get; set; }
        public void OnGet()
        {
            Genres = _db.Genres.ToList();
            DubStudios = _db.DubStudios.ToList();
            Tags = _db.Tags.ToList();
        }
        public void OnPost()
        {
            Genres = _db.Genres.ToList();
            DubStudios = _db.DubStudios.ToList();
            Tags = _db.Tags.ToList();

            var anime = new Anime
            {
                Name = Input.Name,
                OriginalName = Input.OriginalName,
                JapanName = Input.JapanName,
                EnglishName = Input.EnglishName,
                Studio = Input.Studio,
                Description = Input.Description,
                CountEpisodes = Input.CountEpisodes,
                Genres = new List<Genre>(),
                Status = Input.Status,
                DubStudios = new List<DubStudio>(),
                Tags = new List<Tag>(),
                AgeRating = Input.AgeRating,
                Source = Input.Source,
                Type = Input.Type,
                Duration = Input.Duration,
                StartDate = Input.StartDate,
                EndDate = Input.EndDate,
                NextEpisodeTime = Input.StartDate,
                MainImage = new Image(),
            };
            if (anime.Status.Equals("¬ышел"))
            {
                anime.CountEpisodesForNow = anime.CountEpisodes;
            }

            for(Int32 i = 0; i < Input.Genres.Count; i++)
            {
                for(Int32 j = 0; j < Genres.Count; j++)
                {
                    if (Input.Genres[i] == Genres[j].Name)
                    {
                        anime.Genres.Add(Genres[j]);
                        break;
                    }
                }
            }

            if (Input.DubStudios != null)
            {
                for (Int32 i = 0; i < Input.DubStudios.Count; i++)
                {
                    for (Int32 j = 0; j < DubStudios.Count; j++)
                    {
                        if (Input.DubStudios[i] == DubStudios[j].Name)
                        {
                            anime.DubStudios.Add(DubStudios[j]);
                            break;
                        }
                    }
                }
            }

            if (Input.Tags != null)
            {
                foreach (var t in Input.Tags)
                {
                    foreach (var t1 in Tags.Where(t1 => t == t1.Name))
                    {
                        anime.Tags.Add(t1);
                        break;
                    }
                }
            }

            if (Input.MainImage != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(Input.MainImage.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)Input.MainImage.Length);
                }
                // установка массива байтов
                anime.MainImage.Picture = imageData;
            }
            _db.Add(anime);
            _db.SaveChanges();
            Message = "Anime added successfully";
        }
    }
}
