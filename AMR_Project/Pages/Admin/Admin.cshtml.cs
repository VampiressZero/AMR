using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages
{
    [Authorize]
    public class AdminModel : PageModel
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;
        public AdminModel(ApplicationContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public List<Anime> Animes;
        public async Task<IActionResult> OnGetAsync()
        {
            Animes = _db.Animes.ToList();
            var user = await _userManager.GetUserAsync(User);
            if (user.UserName.Equals("Admin"))
            {
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}
