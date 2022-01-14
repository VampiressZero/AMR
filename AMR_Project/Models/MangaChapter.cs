using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Models
{
    public class MangaChapter
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 Tome { get; set; }
        public Int32 Chapter { get; set; }
        public List<Image> Images { get; set; }
    }
}
