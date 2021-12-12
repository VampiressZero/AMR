using AMR_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.DAL
{
    public class Repository
    {
        private readonly ApplicationContext _db;
        public Repository(ApplicationContext db)
        {
            _db = db;
        }
        public void Add(Genre genre)
        {
            _db.Add(genre);
            _db.SaveChanges();
        }
    }
}
