using System.Collections.Generic;
using Newtonsoft.Json;

namespace xf.examen.themoviedb.Models
{
    public class BaseResponse
    {
        [JsonProperty("results")]
        public List<Movie> Movies { get; set; }
    }
}
