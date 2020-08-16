using System;
using System.Collections.Generic;

using Xamarin.Forms;
using xf.examen.themoviedb.ViewModels;

namespace xf.examen.themoviedb.Views
{
    public partial class DetailPage : ContentPage
    {
        public DetailPage(string movieId)
        {
            InitializeComponent();
            this.BindingContext = new DetailViewModel(movieId);
        }
    }
}
