using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DigitalNameCard2
{
    public class CardLabel
    {
        public Label Label { get; set; }

        public string Text
        {
            get { return Label.Text; }
            set { Label.Text = value; }
        }

        public CardLabel(LabelSetting setting)
        {
            Label = new Label();

            Label.SetValue(Grid.RowProperty, setting.Row);
            Label.SetValue(Grid.ColumnProperty, setting.Column);
            Label.SetValue(Grid.RowSpanProperty, setting.RowSpan);
            Label.SetValue(Grid.ColumnSpanProperty, setting.ColumnSpan);
            Label.HorizontalTextAlignment = setting.Alignment;

            double size = Device.GetNamedSize(setting.FontSize, typeof(Label));
            Label.FontSize = size;
            Label.TextColor = setting.FontColor;
        }
    }
}
