using AMR_Project.Models;
using AMR_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _db;

        public IndexModel(ApplicationContext db)
        {
            _db = db;
        }

        public List<Anime> Animes { get; set; }
        public void OnGet()
        {
            Animes = _db.Animes.ToList();
            for (var i = 0; i < Animes.Count; i++)
            {
                _db.Entry(Animes[i]).Reference(a => a.MainImage).Load();
            }
        }
    }
}
