using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
namespace VectorCardEditor
{
    class Card
    {
        double Width { get; set; }
        double Height { get; set; }
        string Name { get; set; }
        ShapeBase Shape;

        public Card()
        {
           
        }

        public void DrawCard(Graphics g)
        {
            var xml = new XmlDocument();
            xml.Load("draw.svg");
            Console.WriteLine(xml);
            var node = xml.DocumentElement.SelectSingleNode("/svg/g/ellipse");

            Shape = new EllipseShape();
            Shape.Load(node);
            Shape.Draw(g);
        }

        public void LoadCard(string path)
        {
        }

        public void SaveCard(string file)
        {
            var doc = new XmlDocument();
            var declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "no");
            doc.AppendChild(declaration);

            var svgNode = doc.CreateElement("svg");
            doc.AppendChild(svgNode);

            var gNode = doc.CreateElement("g");
            doc.DocumentElement.SelectSingleNode("/svg").AppendChild(gNode);

            Shape.Save(doc);
            
            doc.Save(file);
        }
    }
}
