using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using xf.examen.themoviedb.Services;

namespace xf.examen.themoviedb.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            _ = GetAsyncMet();
        }

        private async Task GetAsyncMet()
        {
            MoviesService moviesService = new MoviesService();
            _ = await moviesService.GetTopRated();
        }
    }
}
