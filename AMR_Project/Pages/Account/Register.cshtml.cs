using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AMR_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public RegisterModel(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            public string UserName { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Пароли не совпадают")]
            public string PasswordConfirm { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = Input.UserName,
                    Email = Input.Email,
                    Lists
                    = new List<ListAnimes> 
                    {
                        new ListAnimes { Name = "Watched" },
                        new ListAnimes { Name = "Dropped" },
                        new ListAnimes { Name = "Watching" },
                        new ListAnimes { Name = "Planned" }
                    },
                    ListMangas = new List<ListMangas>
                    {
                        new ListMangas { Name = "Watched" },
                        new ListMangas { Name = "Dropped" },
                        new ListMangas { Name = "Watching" },
                        new ListMangas { Name = "Planned" }
                    },

                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToPage("/Index");
                }
            }
            return Page();
        }
    }
}
