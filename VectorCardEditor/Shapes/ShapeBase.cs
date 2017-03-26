using System;
using System.Xml;
using System.Drawing;
namespace VectorCardEditor
{
    public enum ShapeType
    {
        Rectangle = 0,
        Ellipse = 1
    }

    [Serializable]
    public abstract class ShapeBase
    {
        public Color FillColor { get; set; }
        public Color StrokeColor { get; set; } = Color.White;
        public double StrokeWidth { get; set; } = 0;

        public ShapeBase() { }

        public abstract void Load(XmlNode node);
        public abstract void Save(XmlDocument doc);
        public abstract void Draw(Graphics g, Point origin);
        public abstract void Resize(double width, double height);

        protected virtual void ParseStyle(string style)
        {
            var elements = style.Split(';');
            foreach (var item in elements)
            {
                if (item.StartsWith("fill:"))
                {
                    FillColor = ColorTranslator.FromHtml(item.Substring(5));
                }
                else if (item.StartsWith("stroke-width:"))
                {
                    StrokeWidth = double.Parse(item.Substring(13));
                }
                else if (item.StartsWith("stroke:"))
                {
                    StrokeColor = ColorTranslator.FromHtml(item.Substring(7));
                }
            }
        }

        protected virtual string GenerateStyle()
        {
            string result;
            result = "fill:" + ColorTranslator.ToHtml(FillColor) +";";
            result += "stroke-width:" + StrokeWidth + ";";
            result += "stroke:" + ColorTranslator.ToHtml(StrokeColor);
            return result;
        }

    }
}
