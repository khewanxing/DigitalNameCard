using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigitalNameCard2
{
	public partial class MainPage : ContentPage
	{
        private List<CardInfo> cardList;
        public void GridInit()
        {

            for (int i = 0; i < 57; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = GridLength.Star;
                root.RowDefinitions.Add(r);
            }

            for (int i = 0; i < 30; i++)
            {
                ColumnDefinition c = new ColumnDefinition();
                c.Width = GridLength.Star;
                root.ColumnDefinitions.Add(c);
            }
        }

        public MainPage()
		{
			InitializeComponent();

            GridInit();

            #region what is this
            //CardLabel name = new CardLabel(20, 15, 3, 15, NamedSize.Large, TextAlignment.Center);
            //name.Text = "John Wick";

            //Grid g = new Grid();

            //g.SetValue(Grid.RowProperty, 0);
            //g.SetValue(Grid.ColumnProperty, 0);
            //g.SetValue(Grid.RowSpanProperty, 10);
            //g.SetValue(Grid.ColumnSpanProperty, 10);

            //g.BackgroundColor = Color.Red;

            //CardLabel title = new CardLabel(23, 15, 3, 15, NamedSize.Medium, TextAlignment.Center);
            //title.Text = "Head Programmer";

            //root.Children.Add(name.Label);
            //root.Children.Add(title.Label);

            //root.Children.Add(g);
            #endregion

            App.cDBUtil = new CardDatabase();
            //loading info from db3 into card
            cardList = App.cDBUtil.GetAllCard();
            //enter card info to class and to extra info
            
            //visualize card

            NameCard card = NameCard.CreateCardDesign(0);
            card.SetNameCard(root, background, cardList[0]);
           // card.SetNameCard(root, background, "John Doe", "- Main Photographer -", "www.johndoephotography.com", "+6281233344455", "john.doe@johndoephotography.com", "Jl. Dago 999, Bandung, Indonesia");
        }

 

        private async void ImageTapped(object sender, EventArgs args)
        {
            //await DisplayAlert("Something","Number of Children :" +  root.Children.Count + " ", "OK");
            GoSecondPage();
        }

        private void TestHandler(object sender, EventArgs e)
        {
            //go 2nd page
            //DisplayAlert("Test", "Test", "Test");
            GoSecondPage();
        }

        public void GoSecondPage()
        {
            Application.Current.MainPage = new NavigationPage(new ExtraInfo(cardList));

        }


        private async void myButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("something", "somethign", "ok");
            //await App.Current.MainPage.Navigation.PushModalAsync(new ExtraInfo());
        }
    }
}
