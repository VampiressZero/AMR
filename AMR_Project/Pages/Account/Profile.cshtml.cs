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

namespace AMR_Project.Pages
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        
        public ProfileModel(UserManager<User> userManager)
        {
            _userManager = userManager;
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
