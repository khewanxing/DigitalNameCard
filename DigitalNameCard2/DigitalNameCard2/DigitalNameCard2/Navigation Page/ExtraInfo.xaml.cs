using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace DigitalNameCard2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExtraInfo : ContentPage
	{
             
		public ExtraInfo (List<CardInfo> c)
		{
			InitializeComponent ();
            //enter info 
            CardInfo User = c[0];
            

            List<xInfo> info = JsonConvert.DeserializeObject<List<xInfo>>(User.ExtraInfo);
            foreach (var item in info)
            {
                Grid s = new Grid();

                ColumnDefinition infoColumn = new ColumnDefinition();
                infoColumn.Width = new GridLength(1, GridUnitType.Star);
                
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
                _label.SetValue(Label.MarginProperty, "15");

                Label _value = new Label(); _value.Text = item.Value;
                _value.SetValue(Grid.ColumnProperty, 1);
                _value.SetValue(Label.MarginProperty, "10");

                s.Children.Add(_label);
                s.Children.Add(_value);
                root.Children.Add(s);
            }
        }
	}
}