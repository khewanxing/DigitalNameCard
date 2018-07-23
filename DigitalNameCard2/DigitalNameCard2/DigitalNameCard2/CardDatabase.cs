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
            /*
           
            */
            fillDB();
        }


        public void fillDB ()
        {
            CardInfo c = new CardInfo();
            c.Name = "Sulaeman Santoso";
            c.Title = "Programmer extraordinaire";
            c.PhoneNumber = "082240062800";
            c.Website = "sulaeman.santoso.it.maranatha.edu";
            c.Email = "vatsuko@gmail.com";
            c.Address = "Jl ABC no 10";
            List<xInfo> xtraInfo = new List<xInfo>();
            xInfo temp = new xInfo("research gate", "wwww.researchgate.com", "www.researchgate.com");
            xtraInfo.Add(temp);
            temp = new xInfo("hobby", "www.alienware.com", "www.alibaba.com");
            xtraInfo.Add(temp);
            temp = new xInfo("facebook", "wwww.facebook.com", "www.facebook.com");
            xtraInfo.Add(temp);
            xtraInfo.Add(new xInfo("twitter", "@Sulaemansantoso", "www.twitter.com"));
            xtraInfo.Add(new xInfo("Instagam", "@Sulaemansantoso", "www.adhd.com"));

            String result = JsonConvert.SerializeObject(xtraInfo);
            c.ExtraInfo = result;
            dbConnection.Insert(c);

            c = new CardInfo();
            c.Name = "Bruce Wayne";
            c.Title = "Billionaire Vigilante";
            c.PhoneNumber = "082240062800";
            c.Website = "waynecorp.com";
            c.Email = "bruce.wayne@gmail.com";
            c.Address = "Gotham Avenue 1";
            xtraInfo = new List<xInfo>();
            temp = new xInfo("research gate", "wwww.researchgate.com", "www.researchgate.com");
            xtraInfo.Add(temp);
            temp = new xInfo("hobby", "www.alienware.com", "www.alibaba.com");
            xtraInfo.Add(temp);
            temp = new xInfo("facebook", "wwww.facebook.com", "www.facebook.com");
            xtraInfo.Add(temp);
            xtraInfo.Add(new xInfo("twitter", "@Sulaemansantoso", "www.twitter.com"));
            xtraInfo.Add(new xInfo("Instagam", "@Sulaemansantoso", "www.adhd.com"));

            result = JsonConvert.SerializeObject(xtraInfo);
            c.ExtraInfo = result;
            dbConnection.Insert(c);

            c = new CardInfo();
            c.Name = "Tony Stark";
            c.Title = "Genius Entrepreneur";
            c.PhoneNumber = "082240062800";
            c.Website = "stark.com";
            c.Email = "tony@stark.com";
            c.Address = "Jl ABC no 10";
            xtraInfo = new List<xInfo>();
            temp = new xInfo("research gate", "wwww.researchgate.com", "www.researchgate.com");
            xtraInfo.Add(temp);
            temp = new xInfo("hobby", "www.alienware.com", "www.alibaba.com");
            xtraInfo.Add(temp);
            temp = new xInfo("facebook", "wwww.facebook.com", "www.facebook.com");
            xtraInfo.Add(temp);
            xtraInfo.Add(new xInfo("twitter", "@Sulaemansantoso", "www.twitter.com"));
            xtraInfo.Add(new xInfo("Instagam", "@Sulaemansantoso", "www.adhd.com"));

            result = JsonConvert.SerializeObject(xtraInfo);
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
