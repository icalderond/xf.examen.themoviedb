using System.Collections.Generic;
using Newtonsoft.Json;

namespace xf.examen.themoviedb.Models
{
    public class MovieDetail
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("overview")]
        public string Description { get; set; }

        [JsonProperty("poster_path")]
        public string PosterImage { get; set; }

        [JsonProperty("genres")]
        public List<Genre> Genres { get; set; }

        [JsonProperty("release_date")]
        public string Release { get; set; }

        [JsonProperty("production_companies")]
        public List<Productions> Studio { get; set; }

        public List<Cast> Casts { get; set; }
    }

    public class Cast : GenericBase
    {
        [JsonProperty("profile_path")]
        public string ProfileImage { get; set; }
    }

    public class Productions : GenericBase { }

    public class Genre : GenericBase { }

    public class GenericBase
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
