using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages.Admin
{
    public class AddGenreModel : PageModel
    {
        private readonly Repository _db;

        public AddGenreModel(ApplicationContext context)
        {
            _db = new Repository(context);
        }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Text)]
            public String Name { get; set; }

            [Required]
            [DataType(DataType.MultilineText)]
            public String Description { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            var genre = new Genre
            {
                Name = Input.Name,
                Description = Input.Description
            };
            _db.Add(genre);
            return RedirectToPage();
        }
    }
}
