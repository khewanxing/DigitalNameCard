using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DigitalNameCard2
{
    public class CardDatabase 
    {
        static CardDatabase database;

        public static CardDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new CardDatabase(
                        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cardSQLite.db3"));
                }
                return database;
            }
        }

        public CardDatabase(string dbPath)
        {
            var db = new SQLiteAsyncConnection(dbPath);
            
        }

    }
}
