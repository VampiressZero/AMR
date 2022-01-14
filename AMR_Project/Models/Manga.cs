using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMR_Project.Models
{
    public class Manga
    {
        public Int32 Id { get; set; }
        public String Name { get; set; }
        public String OriginalName { get; set; }
        public String JapanName { get; set; }
        public String Description { get; set; }
        public DateTime NextChapterTime { get; set; }
        public Int32 Year { get; set; }
        public Int32 ChapterCount { get; set; }
        public String Status { get; set; }
        public String StatusOfTranslate { get; set; }
        public List<Genre> Genres { get; set; }
        public byte[] MainImage { get; set; }
        public List<Tag> Tags { get; set; }
        public String AgeRating { get; set; }
        public Int32 Rating { get; set; }
        public Int32 RatingPeopleCount { get; set; }
        public String Type { get; set; }
        public String PublishType { get; set; }
        public List<ListMangas> List { get; set; }
        public MangaAuthor Author { get; set; }
        public String Painter { get; set; }
        public String Publisher { get; set; }
        public MangaTranslator Translator { get; set; }
        public List<MangaChapter> MangaChapters { get; set; }
    }
}
