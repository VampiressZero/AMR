using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Models
{
    public class ListMangas
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public List<Manga> Mangas { get; set; }
    }
}
