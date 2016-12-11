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

        public EllipseShape() { }

        public override void Load(XmlNode node)
        {
            Style = node.Attributes["style"].Value;
            CX = double.Parse(node.Attributes["cx"].Value);
            CY = double.Parse(node.Attributes["cy"].Value);
            RX = double.Parse(node.Attributes["rx"].Value);
            RY = double.Parse(node.Attributes["ry"].Value);
        }

        public override void Save(XmlDocument doc)
        {
            var node = doc.CreateElement("ellipse");
            node.SetAttribute("style", Style);
            node.SetAttribute("cx", CX.ToString());
            node.SetAttribute("cy", CY.ToString());
            node.SetAttribute("rx", RX.ToString());
            node.SetAttribute("ry", RY.ToString());

            doc.DocumentElement.SelectSingleNode("/svg/g").AppendChild(node);

            //doc.AppendChild(node);
        }
        public override void Draw(Graphics g)
        {
            var rect = new Rectangle(0,0,(int)RX,(int)RY);
            g.FillEllipse(Brushes.Red,rect);
        }
    }
}
