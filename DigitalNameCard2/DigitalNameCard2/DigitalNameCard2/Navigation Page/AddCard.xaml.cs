using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace DigitalNameCard2.Navigation_Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCard : ContentPage
	{
		public AddCard ()
		{
			InitializeComponent ();
		}

        private async void btnScan_Clicked(object sender, EventArgs e)
        {

            var option = new ZXing.Mobile.MobileBarcodeScanningOptions()
            {
                AutoRotate = false,
                UseFrontCameraIfAvailable = false,
                TryHarder = true,
                PossibleFormats  = new List<ZXing.BarcodeFormat>
                {
                    ZXing.BarcodeFormat.EAN_8, ZXing.BarcodeFormat.EAN_13
                }
            };

            var scanPage = new ZXingScannerPage(option)
            {
                Title = "Scan Barcode Here"
            };
            await Application.Current.MainPage.Navigation.PushModalAsync(scanPage);
            scanPage.OnScanResult += ScanPage_OnScanResult;

        }

        private void ScanPage_OnScanResult(ZXing.Result result)
        {
            var ResultText = result.Text;
            DisplayAlert("Result", ResultText, "OK");
        }
    }
}