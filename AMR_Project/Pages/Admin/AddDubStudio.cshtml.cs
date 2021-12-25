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
    public class AddDubStudioModel : PageModel
    {
        private readonly ApplicationContext _db;

        public AddDubStudioModel(ApplicationContext db)
        {
            _db = db;
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
            var dubStudio = new DubStudio
            {
                Name = Input.Name
            };
            _db.Add(dubStudio);
            _db.SaveChanges();
            return RedirectToPage();
        }
    }
}
