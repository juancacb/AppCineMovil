using AppCineMovil.models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCineMovil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        private ObservableCollection<Ingreso> _TablaUsuario;
        public ConsultaRegistro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
        }

        protected async override void OnAppearing()
        {
            var resultado = await _conn.Table<Ingreso>().ToListAsync();
            _TablaUsuario = new ObservableCollection<Ingreso>(resultado);
            ListaUsuarios.ItemsSource = _TablaUsuario;
            base.OnAppearing();
        }

        private void ListaUsuarios_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var Obj = (Ingreso)e.SelectedItem;
            int id = Convert.ToInt32(Obj.Id.ToString());
            try
            {
                Navigation.PushAsync(new Editar(id));


            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnAtras_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
        }
    }
}