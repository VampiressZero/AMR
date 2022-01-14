using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages.Mangas
{
    public class MangaModel : PageModel
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;
        public MangaModel(ApplicationContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public Manga Manga { get; set; }
        public Double AvgRating { get; set; }
        public void OnGet(Int32 mangaId)
        {
            Manga = _db.Find<Manga>(mangaId);
            _db.Entry(Manga).Collection(a => a.Genres).Load();
            _db.Entry(Manga).Collection(a => a.Tags).Load();
            _db.Entry(Manga).Collection(m => m.MangaChapters).Load();
            _db.Entry(Manga).Reference(a => a.Author).Load();
            _db.Entry(Manga).Reference(a => a.Translator).Load();
            if (Manga.RatingPeopleCount == 0)
            {
                AvgRating = 0;
            }
            else
            {
                AvgRating = Math.Round((Double)Manga.Rating / (Double)Manga.RatingPeopleCount, 2);
            }
        }
        public IActionResult OnPost(Int32 mangaId)
        {
            Manga = _db.Find<Manga>(mangaId);
            var rate = Int32.Parse(Request.Form["Rate"]);
            Manga.Rating += rate;
            Manga.RatingPeopleCount += 1;
            _db.SaveChanges();
            return RedirectToPage();
        }
        public string SelectedList { get; set; }
        public IActionResult OnPostSelect(Int32 mangaId)
        {
            Manga = _db.Find<Manga>(mangaId);
            var list = Request.Form["selectList"];
            var user = _userManager.GetUserAsync(User).Result;
            _db.Entry(user).Collection(u => u.ListMangas).Load();
            var selectedList = user.ListMangas.Find(l => l.Name == list);
            if (selectedList != null)
            {
                _db.Entry(selectedList).Collection(l => l.Mangas).Load();
                selectedList.Mangas.Add(Manga);
            }
            _db.SaveChanges();
            return RedirectToPage();
        }
    }
}
