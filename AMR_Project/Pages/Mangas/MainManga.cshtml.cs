using AMR_Project.Models;
using AMR_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Pages.Mangas
{
    public class MainMangaModel : PageModel
    {
        private readonly ApplicationContext _db;

        public MainMangaModel(ApplicationContext db)
        {
            _db = db;
        }

        public List<Manga> Mangas { get; set; }
        public void OnGet()
        {
            Mangas = _db.Mangas.ToList();
        }
    }
}
