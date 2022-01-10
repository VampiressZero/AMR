using AMR_Project.Models;
using AMR_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Pages.Animes
{
    public class MainAnimeModel : PageModel
    {
        private readonly ApplicationContext _db;

        public MainAnimeModel(ApplicationContext db)
        {
            _db = db;
        }

        public List<Anime> Animes { get; set; }
        public void OnGet()
        {
            Animes = _db.Animes.ToList();
        }
    }
}
