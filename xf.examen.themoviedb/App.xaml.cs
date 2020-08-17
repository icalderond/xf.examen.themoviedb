﻿using Xamarin.Forms;
using xf.examen.themoviedb.CustomRender;
using xf.examen.themoviedb.Views;

namespace xf.examen.themoviedb
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new CustomNavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
