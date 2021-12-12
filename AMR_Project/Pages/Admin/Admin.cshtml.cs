using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly UserManager<User> _userManager;
        public AdminModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        
        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.UserName.Equals("Admin"))
            {
                return Page();
            }
            return RedirectToPage("/Index");
        }
    }
}
