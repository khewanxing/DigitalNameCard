using SQLite;
using System;
using System.Collections.Generic;

namespace DigitalNameCard2
{

    public class xInfo
    {
        public String Key { get; set; }
        public String Value { get; set; }
        public String Link { get; set; }

        public xInfo(String key, String value , String link)
        {
            Key = key;
            Value = value;
            Link = link;
        }
    }
   
    public class CardInfo
    {
        
        [PrimaryKey, AutoIncrement][Indexed]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Title { get; set; }
        public String Website { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public int DesignNo { get; set; }
        public String ExtraInfo { get; set; }
        
        public String toJsonString ()
        {
            
            String s = "{ 'Id':" +Id +", 'Name': '" + Name + "'," + 
                        "'Title':'" + Title  + "','Website':'" + Website  + 
                        "','PhoneNumber':"+ PhoneNumber + "','Email':'" + 
                        Email + "','Address':" + Address + "','DesignNo':" + DesignNo  +"}";
            //tinggal tambah info
            return s;
        }
        /*

        public CardInfo(string name, string  title, string website, string phonenumber, string email, string address)
        {
            Name = name;
            Title = title;
            Website = website;
            PhoneNumber = phonenumber;
            Email = email;
            Address = address;
            ExtraInfo = new Dictionary<string, string>();
        }

        public CardInfo(string name, string title, string website, string phonenumber, string email, string address,Dictionary<String,String> extraInfo)
        {
            Name = name;
            Title = title;
            Website = website;
            PhoneNumber = phonenumber;
            Email = email;
            Address = address;
            ExtraInfo = extraInfo;
        }*/
    }
}