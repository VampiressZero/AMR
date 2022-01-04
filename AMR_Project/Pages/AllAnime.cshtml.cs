using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.Models;
using AMR_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages
{
    public class AllAnimeModel : PageModel
    {
        private readonly ApplicationContext _db;
        public AllAnimeModel(ApplicationContext db)
        {
            _db = db;
        }
        public List<Anime> Animes { get; set; }
        public void OnGet()
        {
            Animes = _db.Animes.ToList();
            foreach(var a in Animes)
            {
                _db.Entry(a).Reference(a => a.MainImage).Load();
            }
        }
    }
}
