using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppCineMovil.Droid;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using AppCineMovil.Droid;
//using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SqLiteCliente))]
namespace AppCineMovil.Droid
{
    public class SqLiteCliente : Database
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            var path = Path.Combine(documentPath, "uisrael.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}