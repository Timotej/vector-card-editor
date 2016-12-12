using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Xml;

namespace VectorCardEditor
{
    class EllipseShape : ShapeBase
    {
        string Style;
        double CX;
        double CY;
        double RX;
        double RY;

        public EllipseShape(double width, double heigth)
        {
            RX = width / 2;
            RY = heigth / 2;
            CX = width / 2;
            CY = heigth / 2;
        }

        public override void Load(XmlNode node)
        {
            Style = node.Attributes["style"].Value;
            CX = double.Parse(node.Attributes["cx"].Value);
            CY = double.Parse(node.Attributes["cy"].Value);
            RX = double.Parse(node.Attributes["rx"].Value);
            RY = double.Parse(node.Attributes["ry"].Value);

            ParseStyle(Style);
        }

        public override void Save(XmlDocument doc)
        {
            var node = doc.CreateElement("ellipse");
            node.SetAttribute("style", GenerateStyle());
            node.SetAttribute("cx", CX.ToString());
            node.SetAttribute("cy", CY.ToString());
            node.SetAttribute("rx", RX.ToString());
            node.SetAttribute("ry", RY.ToString());

            doc.DocumentElement.SelectSingleNode("/svg/g").AppendChild(node);
        }

        public override void Draw(Graphics g, Point origin)
        {
            var rect = new Rectangle(origin.X, origin.Y, (int)RX * 2, (int)RY * 2);
            var brush = new SolidBrush(FillColor);
            g.FillEllipse(brush, rect);

            if (StrokeColor != null)
            {
                var pen = new Pen(StrokeColor, (float)StrokeWidth);
                g.DrawEllipse(pen, rect);
            }
        }
    }
}
