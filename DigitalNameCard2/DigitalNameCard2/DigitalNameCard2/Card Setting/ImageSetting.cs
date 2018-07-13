using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DigitalNameCard2
{
    public class ImageSetting
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public int RowSpan { get; set; }
        public int ColumnSpan { get; set; }
        public Aspect Aspect { get; set; }

        public ImageSetting(int row, int column, int rowSpan, int columnSpan, Aspect aspect)
        {
            Row = row;
            Column = column;
            RowSpan = rowSpan;
            ColumnSpan = columnSpan;
            Aspect = aspect;
        }
    }
}
