using AMR_Project.Models;
using AMR_Project.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Pages.Ranobes
{
    public class MainRanobeModel : PageModel
    {
        private readonly ApplicationContext _db;

        public MainRanobeModel(ApplicationContext db)
        {
            _db = db;
        }

        public List<Ranobe> Ranobes { get; set; }
        public void OnGet()
        {
            Ranobes = _db.Ranobes.ToList();
        }
    }
}
