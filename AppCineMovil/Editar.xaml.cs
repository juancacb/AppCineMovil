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
    public partial class Editar : ContentPage
    {
        private int idSelecccionado;
        private SQLiteAsyncConnection _conn;
        IEnumerable<Ingreso> ResultadoDelete;
        IEnumerable<Ingreso> ResultadoUpdate;
        public Editar(int id)
        {
            _conn = DependencyService.Get<SQLiteAsyncConnection>();
            InitializeComponent();           
            idSelecccionado = id;
        }

        public static IEnumerable<Ingreso> Delete(SQLiteConnection db, int id)
        {
            return db.Query<Ingreso>("Delete from Ingreso where Id =  ?", id);
        }

        public static IEnumerable<Ingreso> Update(SQLiteConnection db, string nombre, string usuario, string contrasenia, int id)
        {
            return db.Query<Ingreso>("UPDATE Ingreso SET Nombre = ?, Usuario = ?, Constrasenia = ? where Id = ?", nombre, usuario, contrasenia, id);
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");

            var db = new SQLiteConnection(databasePath);

            ResultadoUpdate = Update(db, TxtNombre.Text, TxtUsuario.Text, TxtContrasenia.Text, idSelecccionado);

            DisplayAlert("Alerta", "Se actualizó correctamente!", "OK");
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");

                var db = new SQLiteConnection(databasePath);

                ResultadoDelete = Delete(db, idSelecccionado);

                DisplayAlert("Alerta", "Se eliminó correctamente!", "OK");

            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "EROOR: " + ex.Message, "OK");

            }
        }
    }
}