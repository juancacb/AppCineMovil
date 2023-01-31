
using AppCineMovil.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCineMovil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registrar());

        }
        public static IEnumerable<Ingreso> SELECT_WHERE(SQLiteConnection db, string usuario, string contrasenia)
        {
            return db.Query<Ingreso>("SELECT * FROM  Ingreso  where Usuario  = ?  and Constrasenia = ?", usuario, contrasenia);

        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");

                var db = new SQLiteConnection(databasePath);

                db.CreateTable<Ingreso>();

                IEnumerable<Ingreso> resultado = SELECT_WHERE(db, usuario.Text, contrasenia.Text);

                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new recomendado(usuario.Text));

                }
                else
                {
                    DisplayAlert("Alerta", "Veriifique el Usurio o Contraseña!", "OK");

                }


            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "OK");
            }
        }

        private void BtnConsultar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConsultaRegistro());
        }
    }
}