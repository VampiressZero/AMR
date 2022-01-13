using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages.Admin
{
    public class AddRanobePageModel : PageModel
    {
        private readonly ApplicationContext _db;

        public AddRanobePageModel(ApplicationContext db)
        {
            _db = db;
        }

        public class InputModel
        {
            [DataType(DataType.Text)]
            public String Name { get; set; }

            public Int32 ChapterNumber { get; set; }

            public Int32 Tome { get; set; }

            [DataType(DataType.MultilineText)]
            public String Text { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public Ranobe Ranobe { get; set; }
        public void OnGet(Int32 id)
        {
            Ranobe = _db.Find<Ranobe>(id);
            _db.Entry(Ranobe).Collection(r => r.RanobePages).Load();
        }

        public void OnPost(Int32 id)
        {
            Ranobe = _db.Find<Ranobe>(id);
            _db.Entry(Ranobe).Collection(r => r.RanobePages).Load();
            var page = new RanobePage{Name = Input.Name, ChapterNumber = Input.ChapterNumber, Tome = Input.Tome, Text = Input.Text};
            Ranobe.RanobePages.Add(page);
            _db.SaveChanges();
        }
    }
}
