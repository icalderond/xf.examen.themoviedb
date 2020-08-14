using Xamarin.Forms;
using xf.examen.themoviedb.ViewModels;

namespace xf.examen.themoviedb.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
        }
    }
}
