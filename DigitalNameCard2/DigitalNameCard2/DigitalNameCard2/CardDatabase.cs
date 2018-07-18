using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using SQLitePCL;
using Newtonsoft.Json;

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

            CardInfo c = new CardInfo();
            c.Name = "Sulaeman Santoso";
            c.Title = "Programmer extraordinaire";
            c.PhoneNumber = "082240062800";
            c.Website = "sulaeman.santoso.it.maranatha.edu";
            c.Email = "vatsuko@gmail.com";
            c.Address = "Jl ABC no 10";
            List<xInfo> xtraInfo = new List<xInfo>();
            xInfo temp = new xInfo();
            temp.Key = "Research Gate";
            temp.Value = "www.researchgate.com";
            xtraInfo.Add(temp);

            temp = new xInfo();
            temp.Key = "Hobby";
            temp.Value = "www.alienware.com";
            xtraInfo.Add(temp);

            String result = JsonConvert.SerializeObject(xtraInfo);
            c.ExtraInfo = result;
            dbConnection.Insert(c);
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
