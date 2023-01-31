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
    public partial class cartelera : ContentPage
    {
        public cartelera(string usuario)
        {
            InitializeComponent();
            lblusuario.Text = usuario;
        }
    }
}