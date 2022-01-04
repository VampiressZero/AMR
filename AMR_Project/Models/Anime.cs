using AMR_Project.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Models
{
    
    public class Anime
    {
        private ApplicationContext _db;
        public Anime()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            var options = optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = AMR; Trusted_Connection = True").Options;
            _db = new ApplicationContext(options);
        }

        private Int32 _countEpidsodesForNow;
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Studio { get; set; }
        public String Description { get; set; }
        public Int32 CountEpisodesForNow 
        {
            get
            {
                while (StartDate.Subtract(DateTime.Now).TotalDays < 0 && _countEpidsodesForNow != CountEpisodes)
                {
                    _countEpidsodesForNow++;
                    StartDate = StartDate.AddDays(7);
                    _db.Entry(this).State = EntityState.Modified;
                    _db.SaveChanges();
                }
                return _countEpidsodesForNow;
            }
            set
            { 
                _countEpidsodesForNow = value; 
            }
        }
        public Int32 CountEpisodes { get; set; }
        public String Status { get; set; }
        public List<Genre> Genres { get; set; }
        public Image MainImage { get; set; }
        public List<Image> Screenshots { get; set; }
        public Int32 Year { get; set; }
        public List<DubStudio> DubStudios { get; set; }
        public List<Tag> Tags { get; set; }
        public String AgeRating { get; set; }
        public Int32 Rating { get; set; }
        public Int32 RatingPeopleCount { get; set; }
        public String Source { get; set; }
        public String Type { get; set; }
        public String Duration { get; set; }
        public List<ListAnimes> List { get; set; }
        public DateTime StartDate { get; set; }
    }
}
