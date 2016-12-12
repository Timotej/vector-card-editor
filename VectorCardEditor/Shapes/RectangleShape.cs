using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;

namespace VectorCardEditor
{
    
    class RectangleShape : ShapeBase
    {
        string Style;
        double X;
        double Y;
        double Width;
        double Height;

        public RectangleShape(double width, double height)
        {
            Width = width;
            Height = height;
            X = 0;
            Y = 0;
        }

        public override void Load(XmlNode node)
        {
            Style = node.Attributes["style"].Value;
            X = double.Parse(node.Attributes["x"].Value);
            Y = double.Parse(node.Attributes["y"].Value);
            Width = double.Parse(node.Attributes["width"].Value);
            Height = double.Parse(node.Attributes["height"].Value);
        }

        public override void Save(XmlDocument doc)
        {
            var node = doc.CreateElement("rect");
            node.SetAttribute("style", GenerateStyle());
            node.SetAttribute("x", X.ToString());
            node.SetAttribute("y", Y.ToString());
            node.SetAttribute("width", Width.ToString());
            node.SetAttribute("height", Height.ToString());

            doc.DocumentElement.SelectSingleNode("/svg/g").AppendChild(node);
        }

        public override void Draw(Graphics g, Point origin)
        {
            var rect = new Rectangle(origin.X, origin.Y, (int)Width, (int)Height);
            var brush = new SolidBrush(FillColor);
            g.FillRectangle(brush, rect);

            if (StrokeColor != null)
            {
                var pen = new Pen(StrokeColor, (float)StrokeWidth);
                g.DrawRectangle(pen, rect);
            }
        }
    }
}
