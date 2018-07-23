using DigitalNameCard2.Card;
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
	public partial class CardSearch : ContentPage
	{
        private CardDatabase db;
        private List<CardInfo> cardDB;
		public CardSearch ()
		{
			InitializeComponent ();
            initDB();
		}

        public void initDB()
        {
            db = new CardDatabase();
            cardDB = db.GetAllCard();

            initTable(cardDB);
        }

        public void initTable(List<CardInfo> cardList)
        {
            if (root.Children.Count > 0)
            {
                root.Children.Clear();
            }
            foreach(CardInfo c in cardList)
            {
                CardFrame frame = new CardFrame(c);
                root.Children.Add(frame);
            }
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            //search..
            String query = ((Entry)sender).Text;
            if ( query != "")
            {
                //List<CardInfo> filter = (List<CardInfo>) cardDB.Where((c) => c.Name.Contains(query));
                List<CardInfo> filter = cardDB.Where(c => c.Name.Contains(query)).ToList();
                initTable(filter);
            }
            else
            {
                initTable(cardDB);
            }
        }
    }
}