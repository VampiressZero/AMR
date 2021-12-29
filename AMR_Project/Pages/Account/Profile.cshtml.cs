using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AMR_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using AMR_Project.DAL;

namespace AMR_Project.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext _db;
        
        public ProfileModel(UserManager<User> userManager, ApplicationContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            public string CurrentPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string NewPassword { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("NewPassword", ErrorMessage = "Пароли не совпадают")]
            public string NewPasswordConfirm { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public User CurrentUser { get; set; }
        public async Task OnGetAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            _db.Entry(CurrentUser).Collection(u => u.Lists).Load();
            foreach(var l in CurrentUser.Lists)
            {
                _db.Entry(l).Collection(l => l.Animes).Load();
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            CurrentUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                var result = await _userManager.ChangePasswordAsync(CurrentUser, Input.CurrentPassword, Input.NewPassword);
            }
            return Page();
        }
    }
}
