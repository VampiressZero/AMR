using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Models
{
    public class RanobePage
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public Int32 ChapterNumber { get; set; }
        public Int32 Tome { get; set; }
        public String Text { get; set; }
    }
}
