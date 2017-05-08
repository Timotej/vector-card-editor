using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VectorCardEditor
{
    [Serializable]
    class CardSetup
    {
        public string Text { get; set; } = string.Empty;
        public Font Font { get; set; } = new Font(new FontFamily("Arial"), 8);
        public Color FontColor { get; set; } = Color.Black;

        public ShapeType Shape { get; set; } = ShapeType.Rectangle;
        public Color ShapeColor { get; set; } = Color.White;
        public Color StrokeColor { get; set; } = Color.White;
        public int StrokeWidth { get; set; } = 0;
    }
}
