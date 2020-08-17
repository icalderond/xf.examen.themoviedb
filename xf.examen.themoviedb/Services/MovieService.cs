using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using xf.examen.themoviedb.Models;

namespace xf.examen.themoviedb.Services
{
    public class MovieService
    {
        string getDetailMovieQuery;

        readonly string URL_BASE_APIREST = "https://api.themoviedb.org/3/movie";
        readonly string URL_BASE_IMAGE = "https://image.tmdb.org/t/p/w500";

        public event EventHandler<GenericEventArg<MovieDetail>> GetDetailMovie_Completed;

        public async Task GetDetailMovie(string MovieId)
        {
            getDetailMovieQuery = $"{URL_BASE_APIREST}/{MovieId}?api_key={Environment.THEMOVIEDB_API_KEY}&language=en-US";

            var movieDetail = new MovieDetail();

            var client = new HttpClient();
            var response = await client.GetAsync(getDetailMovieQuery);
            if (response.IsSuccessStatusCode)
            {
                var ContentString = await response.Content.ReadAsStringAsync();
                movieDetail = JsonConvert.DeserializeObject<MovieDetail>(ContentString);
                if (movieDetail != null)
                {
                    movieDetail.PosterImage = URL_BASE_IMAGE + movieDetail.PosterImage;

                    var splitData = movieDetail.Release.Split('-');
                    if (splitData.Any())
                        movieDetail.Release = splitData[0];
                }
                movieDetail.Casts = await GetCastsMovie(MovieId);
            }

            GetDetailMovie_Completed?.Invoke(this, new GenericEventArg<MovieDetail>(movieDetail));
        }

        public async Task<List<Cast>> GetCastsMovie(string MovieId)
        {
            var getCastsMovieQuery = $"{URL_BASE_APIREST}/{MovieId}/credits?api_key={Environment.THEMOVIEDB_API_KEY}&language=en-US";
            BaseResponseDetail baseResponseDetail = new BaseResponseDetail();

            var client = new HttpClient();
            var response = await client.GetAsync(getCastsMovieQuery);
            if (response.IsSuccessStatusCode)
            {
                var ContentString = await response.Content.ReadAsStringAsync();
                baseResponseDetail = JsonConvert.DeserializeObject<BaseResponseDetail>(ContentString);
                if (baseResponseDetail.Casts != null)
                {
                    baseResponseDetail.Casts = baseResponseDetail.Casts.Where(x => x.ProfileImage != null).ToList();
                    if (baseResponseDetail.Casts.Count > 4)
                        baseResponseDetail.Casts = new List<Cast>(baseResponseDetail.Casts.Take(5));

                    baseResponseDetail.Casts.ForEach(x => x.ProfileImage = URL_BASE_IMAGE + x.ProfileImage);
                }
            }

            return baseResponseDetail.Casts;
        }
    }

    public class BaseResponseDetail
    {
        [JsonProperty("cast")]
        public List<Cast> Casts { get; set; }
    }
}
