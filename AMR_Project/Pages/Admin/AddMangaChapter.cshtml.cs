using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AMR_Project.DAL;
using AMR_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AMR_Project.Pages.Admin
{
    public class AddMangaChapterModel : PageModel
    {
        private readonly ApplicationContext _db;

        public AddMangaChapterModel(ApplicationContext db)
        {
            _db = db;
        }

        public class InputModel
        {
            [DataType(DataType.Text)]
            public String Name { get; set; }

            public Int32 Chapter { get; set; }

            public Int32 Tome { get; set; }

            [DataType(DataType.Upload)]
            public List<IFormFile> Images { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public Manga Manga { get; set; }
        public void OnGet(Int32 id)
        {
            Manga = _db.Find<Manga>(id);
            _db.Entry(Manga).Collection(m => m.MangaChapters).Load();
            foreach (var chapter in Manga.MangaChapters)
            {
                _db.Entry(chapter).Collection(c => c.Images).Load();
            }
        }

        public void OnPost(Int32 id)
        {
            Manga = _db.Find<Manga>(id);
            _db.Entry(Manga).Collection(m => m.MangaChapters).Load();
            foreach (var chapter in Manga.MangaChapters)
            {
                _db.Entry(chapter).Collection(c => c.Images).Load();
            }

            var mangaChapter = new MangaChapter { Chapter = Input.Chapter, Name = Input.Name, Tome = Input.Tome, Images = new List<Image>()};
            if (Input.Images != null)
            {
                for (var i = 0; i < Input.Images.Count; i++)
                {
                    byte[] imageData;

                    using (var binaryReader = new BinaryReader(Input.Images[i].OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)Input.Images[i].Length);
                    }

                    var image = new Image { Picture = imageData };
                    mangaChapter.Images.Add(image);
                }
                _db.SaveChanges();
            }
            Manga.MangaChapters.Add(mangaChapter);
            _db.SaveChanges();
        }
    }
}
