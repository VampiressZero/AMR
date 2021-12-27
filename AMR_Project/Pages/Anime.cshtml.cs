using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages
{
    public class AnimeModel : PageModel
    {
        private readonly ApplicationContext _db;
        public AnimeModel(ApplicationContext db)
        {
            _db = db;
        }
        public Anime Anime { get; set; }
        public Double AvgRating { get; set; }
        public void OnGet(Int32 AnimeId)
        {
            Anime = _db.Find<Anime>(AnimeId);
            _db.Entry(Anime).Collection(a => a.Genres).Load();
            _db.Entry(Anime).Collection(a => a.DubStudios).Load();
            _db.Entry(Anime).Collection(a => a.Tags).Load();
            if (Anime.RatingPeopleCount == 0)
            {
                AvgRating = 0;
            }
            else
            {
                AvgRating = Math.Round((Double)Anime.Rating / (Double)Anime.RatingPeopleCount, 2);
            }
        }
        public IActionResult OnPost(Int32 AnimeId)
        {
            Anime = _db.Find<Anime>(AnimeId);
            _db.Entry(Anime).Collection(a => a.Genres).Load();
            _db.Entry(Anime).Collection(a => a.DubStudios).Load();
            _db.Entry(Anime).Collection(a => a.Tags).Load();
            var rate = Int32.Parse(Request.Form["Rate"]);
            Anime.Rating += rate;
            Anime.RatingPeopleCount += 1;
            _db.SaveChanges();
            return RedirectToPage();
        }
    }
}
