using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;

namespace AppCineMovil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class recomendado : ContentPage
    {
        
        public recomendado(string usuario)
        {
            InitializeComponent();
            lbluser.Text = "Usuario conectado: "+usuario;
            Localizar();
        }

        double lati;
        double longi;

        private async void Localizar()
        {
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;
            if (locator.IsGeolocationAvailable)
            {
                if (locator.IsGeolocationEnabled)
                {
                    if (!locator.IsListening)
                    {
                        await locator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                    }
                    locator.PositionChanged += (cambio, args) =>
                    {
                        var loc = args.Position;
                        lon.Text = loc.Longitude.ToString();
                        longi = double.Parse(lon.Text);
                        lat.Text = loc.Latitude.ToString();
                        lati = double.Parse(lat.Text);
                    };
                }
            }
        }

        private async void mostrarMapa(object sender, EventArgs args1)
        {
            MapLaunchOptions options = new MapLaunchOptions { Name = "Mi posición actual" };
            await Map.OpenAsync(lati, longi, options);
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            string usuario = lbluser.Text;
            Navigation.PushAsync(new cartelera(usuario));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            string usuario = lbluser.Text;
            Navigation.PushAsync(new cartelera(usuario));
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            string usuario = lbluser.Text;
            Navigation.PushAsync(new carteleraSuper(usuario));
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            string usuario = lbluser.Text;
            Navigation.PushAsync(new carteleraCinemarck(usuario));
        }

        private void Button_Clicked_4(object sender, EventArgs e)
        {
            string usuario = lbluser.Text;
            Navigation.PushAsync(new carteleraCinext(usuario));
        }

        private void Button_Clicked_5(object sender, EventArgs e)
        {
            string usuario = lbluser.Text;
            Navigation.PushAsync(new carteleraSuper(usuario));
        }

 
    }
}