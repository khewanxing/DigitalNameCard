using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DigitalNameCard2
{
    public class LabelSetting
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int RowSpan { get; set; }
        public int ColumnSpan { get; set; }
        public NamedSize FontSize { get; set; }
        public TextAlignment Alignment { get; set; }
        public Color FontColor { get; set; }

        public LabelSetting(int row, int column, int rowSpan, int columnSpan, NamedSize fontSize, TextAlignment alignment, Color fontColor)
        {
            Row = row;
            Column = column;
            RowSpan = rowSpan;
            ColumnSpan = columnSpan;
            FontSize = fontSize;
            Alignment = alignment;
            FontColor = fontColor;
        }
    }
}
