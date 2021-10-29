using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using xf.examen.themoviedb.CustomRender;
using xf.examen.themoviedb.iOS;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBariOS))]
namespace xf.examen.themoviedb.iOS
{
    public class CustomSearchBariOS : SearchBarRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == SearchBar.TextProperty.PropertyName)
                Control.Text = Element.Text;

            if (e.PropertyName != SearchBar.CancelButtonColorProperty.PropertyName && e.PropertyName != SearchBar.TextProperty.PropertyName)
                base.OnElementPropertyChanged(sender, e);

        }
    }
}

