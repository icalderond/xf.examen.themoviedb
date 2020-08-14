using Newtonsoft.Json;

namespace xf.examen.themoviedb.Models
{
    public class Movie
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("poster_path")]
        public string PosterImage { get; set; }
    }
}
