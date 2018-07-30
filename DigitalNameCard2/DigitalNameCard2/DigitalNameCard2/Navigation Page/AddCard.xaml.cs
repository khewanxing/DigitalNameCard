using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using Newtonsoft.Json;
using System.IO;

namespace DigitalNameCard2.Navigation_Page
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddCard : ContentPage
	{
        ZXingScannerView viewer;
        ZXingDefaultOverlay overlay;
        CardInfo current;

		public AddCard (CardInfo current)
		{
			InitializeComponent ();
            this.current = current;
            String jsonCurrent = JsonConvert.SerializeObject(current);

            ////create current barcode
            
            int count = jsonCurrent.Length;
            imgQR.BarcodeValue = jsonCurrent;

            //imgQR.BarcodeValue = "bawahahahahahaa omg omg omg";

        }

        private  void btnScan_Clicked(object sender, EventArgs e)
        {

            viewer = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingscannerview",
                IsScanning = true,
                
            };

            viewer.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async()=>
                {
                    //viewer.IsAnalyzing = false;
                    
                    await DisplayAlert("Scanned result : ", result.Text, "OK");
                    //if you got the thing get
                    await Navigation.PopModalAsync();
                });
            };

            overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the barcode",
                BottomText = "Scanning will happen automatically",
                ShowFlashButton = viewer.HasTorch,
                AutomationId = "zxingDefaultOverlay",
            };

            overlay.FlashButtonClicked += (senders,ex) =>
            {
                viewer.IsTorchOn = !viewer.IsTorchOn;
            };

            var grid = new Grid()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            grid.Children.Add(viewer);
            grid.Children.Add(overlay);

            Content = grid;
        }

  
    }
}