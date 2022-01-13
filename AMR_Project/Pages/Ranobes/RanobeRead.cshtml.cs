using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages.Ranobes
{
    public class RanobeReadModel : PageModel
    {
        private readonly ApplicationContext _db;

        public RanobeReadModel(ApplicationContext db)
        {
            _db = db;
        }

        public Ranobe Ranobe { get; set; }
        public RanobePage RanobePage { get; set; }
        public void OnGet(Int32 ranobeId, Int32 chapterNumber)
        {
            Ranobe = _db.Find<Ranobe>(ranobeId);
            _db.Entry(Ranobe).Collection(r => r.RanobePages).Load();
            RanobePage = Ranobe.RanobePages.Find(p => p.ChapterNumber == chapterNumber);

        }
    }
}
