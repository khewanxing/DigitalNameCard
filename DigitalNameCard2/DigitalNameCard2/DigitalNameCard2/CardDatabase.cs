using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using SQLitePCL;

namespace DigitalNameCard2
{
    public class CardDatabase
    {
        SQLiteConnection dbConnection;

        public CardDatabase()
        {
            dbConnection = DependencyService.Get<ISqlLite>().GetConnection();
            dbConnection.DropTable<CardInfo>();
            dbConnection.CreateTable<CardInfo>(CreateFlags.None);

            //CardInfo c = new CardInfo();
            //c.Name = "Sulaeman Santoso";
            //c.Address = "Jl ABC no 10";
            //dbConnection.Insert(c);
        }

        public List<CardInfo> GetAllCard()
        { 
            List<CardInfo> values = dbConnection.Query<CardInfo>("Select * from [CardInfo]");
            return values;
        }

        public int InsertCard(CardInfo c)
        {
            int result = dbConnection.Insert(c);
            return result;
        }
        
        public int UpdateCard(CardInfo c)
        {
            int result = dbConnection.Update(c);
            return result;
        }

    
    }
}
