using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DigitalNameCard2
{
    public class NameCard
    {
        
        public static NameCard CreateCardDesign(int number)
        {
            if (number == 0)
                return new NameCard(
                    new LabelSetting(20, 13, 5, 15, NamedSize.Medium, TextAlignment.Center, Color.Black),
                    new LabelSetting(23, 13, 3, 15, NamedSize.Small, TextAlignment.Center, Color.Black),
                    new LabelSetting(44, 5, 2, 20, NamedSize.Micro, TextAlignment.Center, Color.White),
                    new LabelSetting(46, 5, 2, 20, NamedSize.Micro, TextAlignment.Center, Color.White),
                    new LabelSetting(48, 5, 3, 20, NamedSize.Micro, TextAlignment.Center, Color.White),
                    new LabelSetting(52, 5, 3, 20, NamedSize.Micro, TextAlignment.Center, Color.White),
                    new ImageSetting(5, 10, 5, 15, Aspect.AspectFit),
                    "logo2.png",
                    "backgroundcard.png");
            else if (number == 1)
                return new NameCard(
                    new LabelSetting(25, 5, 3, 20, NamedSize.Medium, TextAlignment.Center, Color.White),
                    new LabelSetting(28, 5, 3, 20, NamedSize.Small, TextAlignment.Center, Color.White),
                    new LabelSetting(44, 5, 2, 20, NamedSize.Micro, TextAlignment.Center, Color.White),
                    new LabelSetting(46, 5, 2, 20, NamedSize.Micro, TextAlignment.Center, Color.White),
                    new LabelSetting(48, 5, 3, 20, NamedSize.Micro, TextAlignment.Center, Color.White),
                    new LabelSetting(52, 5, 3, 20, NamedSize.Micro, TextAlignment.Center, Color.White),
                    new ImageSetting(5, 5, 15, 20, Aspect.AspectFit),
                    "logo.png",
                    "backgroundcard2.png");

            return null;
        }

        private CardLabel Name { get; set; }
        private CardLabel Title { get; set; }
        private CardLabel Website { get; set; }
        private CardLabel PhoneNumber { get; set; }
        private CardLabel Email { get; set; }
        private CardLabel Address { get; set; }

        public string Background { get; set; }
        private CardLogo Logo { get; set; }

        public NameCard(LabelSetting nameSetting, LabelSetting titleSetting, LabelSetting websiteSetting, LabelSetting phoneNumberSetting, LabelSetting emailSetting, LabelSetting addressSetting, ImageSetting logoSetting, string logo, string background)
        {
            Name = new CardLabel(nameSetting);
            Title = new CardLabel(titleSetting);
            Website = new CardLabel(websiteSetting);
            PhoneNumber = new CardLabel(phoneNumberSetting);
            Email = new CardLabel(emailSetting);
            Address = new CardLabel(addressSetting);

            Background = background;
            Logo  = new CardLogo(logoSetting);
            Logo.Logo.Source = logo;
        }

        public void SetNameCard(Grid root, Image background, CardInfo c)
        {

            Name.Text = c.Name;
            Title.Text = c.Title;
            Website.Text = c.Website;
            PhoneNumber.Text = c.PhoneNumber;
            Email.Text = c.Email;
            Address.Text = c.Address;

            ShowCard(root, background);
        }

        public void SetNameCard(Grid root, Image background, string name, string title, string website, string phoneNumber, string email, string address)
        {
            Name.Text = name;
            Title.Text = title;
            Website.Text = website;
            PhoneNumber.Text = phoneNumber;
            Email.Text = email;
            Address.Text = address;

            ShowCard(root,background);
        }

        public void ShowCard(Grid root, Image background)
        {
            root.Children.Clear();
            root.Children.Add(Name.Label);
            root.Children.Add(Title.Label);
            root.Children.Add(Website.Label);
            root.Children.Add(PhoneNumber.Label);
            root.Children.Add(Email.Label);
            root.Children.Add(Address.Label);
            root.Children.Add(Logo.Logo);

            background.Source = Background;
            
        }
    }
}
