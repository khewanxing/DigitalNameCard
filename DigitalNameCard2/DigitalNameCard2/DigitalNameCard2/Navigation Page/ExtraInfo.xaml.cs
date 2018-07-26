using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using DigitalNameCard2.Navigation_Page;

namespace DigitalNameCard2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExtraInfo : ContentPage
	{

        CardInfo current;
		public ExtraInfo (List<CardInfo> c, CardInfo current)
		{
			InitializeComponent ();
            //enter info 
            CardInfo User = current;
            this.current = current;

            List<xInfo> info = JsonConvert.DeserializeObject<List<xInfo>>(User.ExtraInfo);
            foreach (var item in info)
            {
                Grid s = new Grid();

                ColumnDefinition infoColumn = new ColumnDefinition();
                infoColumn.Width = new GridLength(2, GridUnitType.Star);
                
                s.ColumnDefinitions.Add(infoColumn);
                ColumnDefinition valueColumn = new ColumnDefinition();
                valueColumn.Width = new GridLength(3, GridUnitType.Star);

                s.ColumnDefinitions.Add(valueColumn);
                s.SetValue(Grid.MarginProperty, "10");
                s.SetValue(Grid.ColumnSpacingProperty, 0);
                s.SetValue(Grid.PaddingProperty, "10");
                
                BoxView bView = new BoxView();
                bView.Color = Color.Black;
                bView.SetValue(Grid.ColumnProperty, 0);
                s.Children.Add(bView);

                Label _label = new Label(); _label.Text= item.Key;_label.TextColor = Color.White;
                _label.SetValue(Grid.ColumnProperty, 0);
                _label.SetValue(Label.MarginProperty, new Thickness(5));

                Label _value = new Label(); _value.Text = item.Value;
                _value.SetValue(Grid.ColumnProperty, 1);
                
                _value.SetValue(Label.MarginProperty, new Thickness(5));
                TapGestureRecognizer tapper = new TapGestureRecognizer();
                tapper.Tapped += (source, events) =>
                {
                    if (!item.Link.StartsWith("http:"))
                    {
                        item.Link = "http://" + item.Link;
                    }
                    Uri uri = new Uri(item.Link);
                    Device.OpenUri(uri);
                };
                s.GestureRecognizers.Add(tapper);
                

                s.Children.Add(_label);
                s.Children.Add(_value);
                root.Children.Add(s);
            }
        }

        public void Profile(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new AddCard(current));

        }

        public void  SearchCard(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new CardSearch());

        }

        public void AddCard(object sender, EventArgs args)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new AddCard(current));

        }

    }
}