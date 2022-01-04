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
    public class AddScreenshotsModel : PageModel
    {
        private readonly ApplicationContext _db;
        public AddScreenshotsModel(ApplicationContext db)
        {
            _db = db;
        }
        public class InputModel
        {
            [DataType(DataType.Upload)]
            public List<IFormFile> Images { get; set; }
        }
        [BindProperty]
        public InputModel Input { get; set; }
        public void OnGet()
        {
        }
        public void OnPost(Int32 Id)
        {
            var anime = _db.Find<Anime>(Id);
            _db.Entry(anime).Collection(a => a.Screenshots).Load();
            if (Input.Images != null)
            {
                for (var i = 0; i < Input.Images.Count; i++)
                { 
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(Input.Images[i].OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)Input.Images[i].Length);
                }
                // установка массива байтов
                var image = new Image { Picture = imageData };
                anime.Screenshots.Add(image);
                }
                _db.SaveChanges();
            }
    }
    }
}
