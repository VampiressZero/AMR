using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Models
{
    public class Anime
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String Studio { get; set; }
        public String Description { get; set; }
        public Int32 CountEpisodes { get; set; }
        public String Status { get; set; }
        public List<Genre> Genres { get; set; }
        public Byte[] MainImage { get; set; }
        // public List<Byte[]> Screenshots { get; set; }
        public Int32 Year { get; set; }
        public List<DubStudio> DubStudios { get; set; }
        public List<Tag> Tags { get; set; }
        public String AgeRating { get; set; }
        public Int32 Rating { get; set; }
        public Int32 RatingPeopleCount { get; set; }
        public String Source { get; set; }
        public String Type { get; set; }
        public String Duration { get; set; }
    }
}
