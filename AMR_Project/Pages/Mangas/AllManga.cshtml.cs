using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.Models;
using AMR_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages.Mangas
{
    public class AllMangaModel : PageModel
    {
        private readonly ApplicationContext _db;
        public AllMangaModel(ApplicationContext db)
        {
            _db = db;
        }
        public List<Manga> Mangas { get; set; }
        public void OnGet()
        {
            Mangas = _db.Mangas.ToList();
        }

        public IActionResult OnPost()
        {
            Mangas = _db.Mangas.ToList();
            var mangas = Mangas.Where(a => a.Status.Equals("Онгоинг")).Select(a => a).ToList();
            Mangas = mangas;
            return Page();
        }
    }
}
