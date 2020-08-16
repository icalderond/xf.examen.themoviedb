using System.Threading.Tasks;
using xf.examen.themoviedb.Models;
using xf.examen.themoviedb.Services;

namespace xf.examen.themoviedb.ViewModels
{
    public class DetailViewModel : NotificationEnabledObject
    {
        public DetailViewModel(string movieId)
        {
            MovieService.GetDetailMovie_Completed += (_, a) =>
            {
                MovieDetail = a.Results;
                IsBusy = false;
            };
            _ = LoadData(movieId);
        }

        private async Task LoadData(string movieId)
        {
            IsBusy = true;
            await MovieService.GetDetailMovie(movieId);
        }

        private MovieService _MovieService;
        public MovieService MovieService
        {
            get { return _MovieService = _MovieService ?? new MovieService(); }
        }

        private MovieDetail _MovieDetail;
        public MovieDetail MovieDetail
        {
            get { return _MovieDetail; }
            set { Set(ref _MovieDetail, value); }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { Set(ref _IsBusy, value); }
        }

    }
}
