using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DigitalNameCard2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExtraInfo : ContentPage
	{
             
		public ExtraInfo (CardInfo c)
		{
			InitializeComponent ();
            //enter info 
            
		}
	}
}