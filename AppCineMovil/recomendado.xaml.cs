using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCineMovil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class recomendado : ContentPage
    {
        public recomendado(string usuario)
        {
            InitializeComponent();
            lbluser.Text = "Usuario conectado: "+usuario;
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