using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DigitalNameCard2;
using DigitalNameCard2.Droid;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteImplementation))]
namespace DigitalNameCard2.Droid
{
   public class SQLiteImplementation : ISqlLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqlFileName = "CardDB.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqlFileName);
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            var conn = new SQLiteConnection(path, true);
            return conn;
        }
    }
}