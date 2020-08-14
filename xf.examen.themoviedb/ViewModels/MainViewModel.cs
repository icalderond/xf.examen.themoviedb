using System.Collections.ObjectModel;
using System.Linq;
using xf.examen.themoviedb.Models;
using xf.examen.themoviedb.Services;

namespace xf.examen.themoviedb.ViewModels
{
    public class MainViewModel : NotificationEnabledObject
    {
        public MainViewModel()
        {
            MoviesService.GetPopular_Completed += (_, a) =>
            {
                PopularMovies_Persist = new ObservableCollection<Movie>(a.Results);
                PopularMovies = new ObservableCollection<Movie>(PopularMovies_Persist);
            };

            MoviesService.GetUpComing_Completed += (_, a) =>
            {
                UpComingMovies_Persist = new ObservableCollection<Movie>(a.Results);
                UpComingMovies = new ObservableCollection<Movie>(UpComingMovies_Persist);
            };

            MoviesService.GetPopular_Completed += (_, a) =>
            {
                PopularMovies_Persist = new ObservableCollection<Movie>(a.Results);
                PopularMovies = new ObservableCollection<Movie>(PopularMovies_Persist);
            };

            LoadData();
        }

        private void LoadData()
        {
            MoviesService.GetTopRated();
            MoviesService.GetUpComing();
            MoviesService.GetPopular();
        }

        private ObservableCollection<Movie> TopRateMovies_Persist;
        private ObservableCollection<Movie> UpComingMovies_Persist;
        private ObservableCollection<Movie> PopularMovies_Persist;

        private MoviesService _MoviesService;
        public MoviesService MoviesService
        {
            get => _MoviesService = _MoviesService ?? new MoviesService();
        }

        private ObservableCollection<Movie> _TopRateMovies;
        public ObservableCollection<Movie> TopRateMovies
        {
            get { return _TopRateMovies; }
            set { Set(ref _TopRateMovies, value); }
        }

        private ObservableCollection<Movie> _UpComingMovies;
        public ObservableCollection<Movie> UpComingMovies
        {
            get { return _UpComingMovies; }
            set { Set(ref _UpComingMovies, value); }
        }

        private ObservableCollection<Movie> _PopularMovies;
        public ObservableCollection<Movie> PopularMovies
        {
            get { return _PopularMovies; }
            set { Set(ref _PopularMovies, value); }
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { Set(ref _IsBusy, value); }
        }

        private string _QuerySearch;
        public string QuerySearch
        {
            get { return _QuerySearch; }
            set
            {
                if (Set(ref _QuerySearch, value))
                    if (_QuerySearch.Length >= 3 || _QuerySearch.Length == 0)
                        FilterCommand.Execute(_QuerySearch);

            }
        }

        private ActionCommand<string> _FilterCommand;
        public ActionCommand<string> FilterCommand
        {
            get
            {
                return _FilterCommand = _FilterCommand ?? new ActionCommand<string>((query) =>
                {
                    if (query.Length >= 3)
                    {
                        TopRateMovies = new ObservableCollection<Movie>(
                            TopRateMovies_Persist.Where(x => x.Title.ToLower().Contains(query.ToLower()))
                            );

                        UpComingMovies = new ObservableCollection<Movie>(
                            UpComingMovies_Persist.Where(x => x.Title.ToLower().Contains(query.ToLower()))
                            );

                        PopularMovies = new ObservableCollection<Movie>(
                            PopularMovies_Persist.Where(x => x.Title.ToLower().Contains(query.ToLower()))
                            );
                    }
                    else
                    {
                        PopularMovies = new ObservableCollection<Movie>(PopularMovies_Persist);
                        UpComingMovies = new ObservableCollection<Movie>(UpComingMovies_Persist);
                        PopularMovies = new ObservableCollection<Movie>(PopularMovies_Persist);
                    }
                });
            }
        }

    }
}
