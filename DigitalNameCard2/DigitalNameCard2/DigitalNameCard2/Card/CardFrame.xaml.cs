using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalNameCard2.Card
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CardFrame : ContentView
	{
        CardInfo _info;
		public CardFrame (CardInfo info)
		{
			InitializeComponent ();
            _info = info;
            lblName.Text = _info.Name;
		}

        private void btnLook_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MainPage(_info);
        }
    }
}