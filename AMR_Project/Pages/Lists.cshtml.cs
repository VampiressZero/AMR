using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages
{
    public class ListsModel : PageModel
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;
        public ListsModel(ApplicationContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public User CurrentUser { get; set; }
        public void OnGet()
        {
            CurrentUser = _userManager.GetUserAsync(User).Result;
            _db.Entry(CurrentUser).Collection(u => u.Lists).Load();
            foreach (var l in CurrentUser.Lists)
            {
                _db.Entry(l).Collection(l => l.Animes).Load();
            }
        }
    }
}
