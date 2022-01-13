using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AMR_Project.Pages.Ranobes
{
    public class RanobeModel : PageModel
    {
        private readonly ApplicationContext _db;
        private readonly UserManager<User> _userManager;
        public RanobeModel(ApplicationContext db, UserManager<User> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public Ranobe Ranobe { get; set; }
        public Double AvgRating { get; set; }
        public void OnGet(Int32 ranobeId)
        {
            Ranobe = _db.Find<Ranobe>(ranobeId);
            _db.Entry(Ranobe).Collection(r => r.Genres).Load();
            _db.Entry(Ranobe).Collection(r => r.Tags).Load();
            _db.Entry(Ranobe).Reference(r => r.Author).Load();
            _db.Entry(Ranobe).Reference(r => r.Translator).Load();
            _db.Entry(Ranobe).Collection(r => r.RanobePages).Load();
            if (Ranobe.RatingPeopleCount == 0)
            {
                AvgRating = 0;
            }
            else
            {
                AvgRating = Math.Round((Double)Ranobe.Rating / (Double)Ranobe.RatingPeopleCount, 2);
            }
        }
        public IActionResult OnPost(Int32 ranobeId)
        {
            Ranobe = _db.Find<Ranobe>(ranobeId);
            var rate = Int32.Parse(Request.Form["Rate"]);
            Ranobe.Rating += rate;
            Ranobe.RatingPeopleCount += 1;
            _db.SaveChanges();
            return RedirectToPage();
        }
        public string SelectedList { get; set; }
        public IActionResult OnPostSelect(Int32 ranobeId)
        {
            Ranobe = _db.Find<Ranobe>(ranobeId);
            var list = Request.Form["selectList"];
            var user = _userManager.GetUserAsync(User).Result;
            _db.Entry(user).Collection(u => u.ListMangas).Load();
            var selectedList = user.ListRanobes.Find(l => l.Name == list);
            if (selectedList != null)
            {
                _db.Entry(selectedList).Collection(l => l.Ranobes).Load();
                selectedList.Ranobes.Add(Ranobe);
            }
            _db.SaveChanges();
            return RedirectToPage();
        }
    }
}
