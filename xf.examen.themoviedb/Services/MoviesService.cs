using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using xf.examen.themoviedb.Models;

namespace xf.examen.themoviedb.Services
{
    public class MoviesService
    {
        readonly string getTopRatedQuery;
        readonly string getUpComingQuery;
        readonly string getPopularQuery;

        readonly string URL_BASE_APIREST = "https://api.themoviedb.org/3/movie";
        readonly string URL_BASE_IMAGE = "https://image.tmdb.org/t/p/w500";

        public event EventHandler<GenericEventArg<List<Movie>>> GetTopRated_Completed;
        public event EventHandler<GenericEventArg<List<Movie>>> GetUpComing_Completed;
        public event EventHandler<GenericEventArg<List<Movie>>> GetPopular_Completed;

        public MoviesService()
        {
            getTopRatedQuery = $"{URL_BASE_APIREST}/top_rated?api_key={Environment.THEMOVIEDB_API_KEY}&language=en-US&page=1";
            getUpComingQuery = $"{URL_BASE_APIREST}/upcoming?api_key={Environment.THEMOVIEDB_API_KEY}&language=en-US&page=1";
            getPopularQuery = $"{URL_BASE_APIREST}/popular?api_key={Environment.THEMOVIEDB_API_KEY}&language=en-US&page=1";
        }

        public async Task GetTopRated()
        {
            var baseResponse = new BaseResponse();

            var client = new HttpClient();
            var response = await client.GetAsync(getTopRatedQuery);
            if (response.IsSuccessStatusCode)
            {
                var ContentString = await response.Content.ReadAsStringAsync();
                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(ContentString);
                if (baseResponse.Movies != null)
                {
                    if (baseResponse.Movies.Any())
                        baseResponse.Movies = baseResponse.Movies.Take(10).ToList();
                    baseResponse.Movies.ForEach((item) => item.PosterImage = URL_BASE_IMAGE + item.PosterImage);
                }
            }

            GetTopRated_Completed?.Invoke(this, new GenericEventArg<List<Movie>>(baseResponse.Movies));
        }

        public async Task GetUpComing()
        {
            var baseResponse = new BaseResponse();

            var client = new HttpClient();
            var response = await client.GetAsync(getUpComingQuery);
            if (response.IsSuccessStatusCode)
            {
                var ContentString = await response.Content.ReadAsStringAsync();
                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(ContentString);
                if (baseResponse.Movies != null)
                {
                    if (baseResponse.Movies.Any())
                        baseResponse.Movies = baseResponse.Movies.Take(10).ToList();
                    baseResponse.Movies.ForEach((item) => item.PosterImage = URL_BASE_IMAGE + item.PosterImage);
                }
            }

            GetUpComing_Completed?.Invoke(this, new GenericEventArg<List<Movie>>(baseResponse.Movies));
        }

        public async Task GetPopular()
        {
            var baseResponse = new BaseResponse();

            var client = new HttpClient();
            var response = await client.GetAsync(getPopularQuery);
            if (response.IsSuccessStatusCode)
            {
                var ContentString = await response.Content.ReadAsStringAsync();
                baseResponse = JsonConvert.DeserializeObject<BaseResponse>(ContentString);
                if (baseResponse.Movies != null)
                {
                    if (baseResponse.Movies.Any())
                        baseResponse.Movies = baseResponse.Movies.Take(10).ToList();

                    baseResponse.Movies.ForEach((item) => item.PosterImage = URL_BASE_IMAGE + item.PosterImage);
                }
            }

            GetPopular_Completed?.Invoke(this, new GenericEventArg<List<Movie>>(baseResponse.Movies));
        }
    }
}
