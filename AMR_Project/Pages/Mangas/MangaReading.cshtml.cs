using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages.Mangas
{
    public class MangaReadingModel : PageModel
    {
        private readonly ApplicationContext _db;

        public MangaReadingModel(ApplicationContext db)
        {
            _db = db;
        }
        public Manga Manga { get; set; }
        public MangaChapter Chapter { get; set; }
        public void OnGet(Int32 mangaId, Int32 chapter)
        {
            Manga = _db.Find<Manga>(mangaId);
            _db.Entry(Manga).Collection(m => m.MangaChapters).Load();
            Chapter = Manga.MangaChapters.Find(c => c.Chapter == chapter);
            if (Chapter != null)
            {
                _db.Entry(Chapter).Collection(c => c.Images).Load();
            }
        }
    }
}
