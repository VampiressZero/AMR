using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages.Admin
{
    public class MangasModel : PageModel
    {
        private readonly ApplicationContext _db;

        public MangasModel(ApplicationContext db)
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
