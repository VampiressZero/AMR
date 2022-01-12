using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Models
{
    public class User : IdentityUser
    {
        public List<ListAnimes> Lists { get; set; }
        public List<ListMangas> ListMangas { get; set; }
    }
}
