using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Models
{
    public class ListRanobes
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public List<Ranobe> Ranobes { get; set; }
    }
}
