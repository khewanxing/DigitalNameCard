using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DigitalNameCard2
{
    public class CardLogo
    {
        public Image Logo { get; set; }

        public CardLogo(ImageSetting setting)
        {
            Logo = new Image();

            Logo.SetValue(Grid.RowProperty, setting.Row);
            Logo.SetValue(Grid.ColumnProperty, setting.Column);
            Logo.SetValue(Grid.RowSpanProperty, setting.RowSpan);
            Logo.SetValue(Grid.ColumnSpanProperty, setting.ColumnSpan);

            Logo.Aspect = setting.Aspect;
        }
    }
}
