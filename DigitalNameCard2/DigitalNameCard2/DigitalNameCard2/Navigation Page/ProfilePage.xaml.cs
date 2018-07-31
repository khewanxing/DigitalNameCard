using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalNameCard2.Navigation_Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
    {
        public int Id { get; set; }
        public String Website { get; set; }
        public String PhoneNumber { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public int DesignNo { get; set; }
        public String ExtraInfo { get; set; }
        public static double fSize = 10;

        public ProfilePage (CardInfo current)
		{
			InitializeComponent ();

            Id = current.Id;
            addLine("Name  : ", current.Name);
            addLine("Title : ", current.Title);
            addLine("Website : ", current.Website);
            addLine("Phone : ", current.PhoneNumber);
            addLine("Email : ", current.Email);
            addLine("Address : ", current.Address);

            List<xInfo> info = JsonConvert.DeserializeObject<List<xInfo>>(current.ExtraInfo);
            foreach (var x in info)
            {
                addEditableLine(x.Key, x.Value);
                EditableLine(x.Link);
            }

           
        }

        private async void BtnUpdate_Clicked(object sender, EventArgs e)
        {
            CardInfo c = new CardInfo();
            c.Id = Id;
            int count=0;
            int rowCount = 6;
            for(int i=0;i< rowCount * 2;i++)
            {
                object o = root.Children[i];
                if (o is Entry)
                {
                    count++;
                    Entry et = (Entry)o;
                    switch (count)
                    {
                        case 1: c.Name = et.Text; break;
                        case 2: c.Title = et.Text; break;
                        case 3: c.Website = et.Text; break;
                        case 4: c.PhoneNumber = et.Text; break;
                        case 5: c.Email = et.Text; break;
                        case 6: c.Address = et.Text; break;
                    }
                }
            }
            List<xInfo> info = new List<xInfo>();
            for (int i = rowCount*2; i+2 <= root.Children.Count; i+=3)
            {
                Entry key = (Entry)root.Children[i];
                Entry value = (Entry)root.Children[i + 1];
                Entry link = (Entry)root.Children[i + 2];
                info.Add(new xInfo(key.Text, value.Text,link.Text));
            }
            String jsonInfo = JsonConvert.SerializeObject(info);
            c.ExtraInfo = jsonInfo;

            int result = App.cDBUtil.dbConnection.Update(c);
            await Navigation.PopModalAsync();
        }

        public void EditableLine(String link)
        {
            Entry lblKey;
     
            lblKey = new Entry(); 
            lblKey.Text = link; 
            lblKey.SetValue(Grid.ColumnProperty, 0);
            lblKey.SetValue(Grid.RowProperty, root.RowDefinitions.Count);
            lblKey.SetValue(Grid.ColumnSpanProperty, 2);
            lblKey.FontSize = fSize;
            root.Children.Add(lblKey);

            root.RowDefinitions.Add(new RowDefinition());
        }
        public void addEditableLine(String key, String value)
        {
            Entry lblKey;
            Entry eValue;

            lblKey = new Entry(); eValue = new Entry();
            lblKey.Text = key; eValue.Text = value;
            lblKey.SetValue(Grid.ColumnProperty, 0);
            lblKey.SetValue(Grid.RowProperty, root.RowDefinitions.Count);
            eValue.SetValue(Grid.ColumnProperty, 1);
            eValue.FontSize = fSize; lblKey.FontSize = fSize;
            eValue.SetValue(Grid.RowProperty, root.RowDefinitions.Count);
            root.Children.Add(lblKey); root.Children.Add(eValue);
            root.RowDefinitions.Add(new RowDefinition());

        }
        public void addLine(String key, String value)
        {
            Label lblKey;
            Entry eValue;

            lblKey = new Label(); eValue = new Entry();
            lblKey.Text = key; eValue.Text = value;
            lblKey.SetValue(Grid.ColumnProperty, 0);
            lblKey.SetValue(Grid.RowProperty, root.RowDefinitions.Count);
            eValue.SetValue(Grid.ColumnProperty, 1);
            eValue.SetValue(Grid.RowProperty, root.RowDefinitions.Count);
            eValue.FontSize = fSize;
            root.Children.Add(lblKey); root.Children.Add(eValue);
            root.RowDefinitions.Add(new RowDefinition());


        }

    }
}