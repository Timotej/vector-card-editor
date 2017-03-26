using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;

namespace VectorCardEditor
{
    [Serializable]
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
            node.SetAttribute("x", (X + StrokeWidth / 2).ToString());
            node.SetAttribute("y", (Y + StrokeWidth / 2).ToString());
            node.SetAttribute("width", Width.ToString());
            node.SetAttribute("height", Height.ToString());

            doc.DocumentElement.SelectSingleNode("/svg/g").AppendChild(node);
        }

        public override void Draw(Graphics g, Point origin)
        {
           
            //var diff = (int)(StrokeWidth / 2);
            //var rect = new Rectangle(origin.X - diff, origin.Y - diff, (int)Width + (2 * diff), (int)Height + (2 * diff));
            var rect = new Rectangle(origin.X, origin.Y, (int)Width, (int)Height);
            var brush = new SolidBrush(FillColor);
            g.FillRectangle(brush, rect);

            if (StrokeColor != null && StrokeWidth > 0)
            {
                var pen = new Pen(StrokeColor, (float)StrokeWidth);
                g.DrawRectangle(pen, rect);
            }
        }

        public override void Resize(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}
