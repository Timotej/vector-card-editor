using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;
namespace VectorCardEditor
{
    [Serializable]
    class Card
    {
        public Point OriginPoint { get; set; }
        public bool ShowGrid { get; set; } = false;
        public bool Selected { get; set; } = false;
        public double Width { get; set; }
        public double Height { get; set; }
        public string Name { get; set; }
        public ShapeBase Shape { get; set; }

        public string Text { get; set; }
        public Font FontType { get; set; }
        public Color FontColor { get; set;  }
        public SizeF FontSize { get; set; }
        public Card(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public void DrawCard(Graphics g)
        {
            Shape.Draw(g, OriginPoint);

            DrawText(g);

            if (ShowGrid)
            {
                var rect = new Rectangle(OriginPoint, new Size((int)Width, (int)Height));
                if (Selected)
                {
                    g.DrawRectangle(Pens.Red, rect);
                }
                else
                {
                    g.DrawRectangle(Pens.Black, rect);
                }
            }
        }

        void DrawText(Graphics g)
        {
            var rectF = new RectangleF(OriginPoint.X, OriginPoint.Y, (float)Width, (float)Height);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            
            g.DrawString(Text, FontType, new SolidBrush(FontColor), rectF, stringFormat);
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
            svgNode.SetAttribute("width", Width.ToString());
            svgNode.SetAttribute("height", Height.ToString());
            doc.AppendChild(svgNode);

            var gNode = doc.CreateElement("g");
            doc.DocumentElement.SelectSingleNode("/svg").AppendChild(gNode);

            Shape.Save(doc);
            SaveText(doc);
            doc.Save(file);
        }

        public void ChangeShape(ShapeBase shape)
        {
            Shape = shape;
        }

        public void MoveByVector(Point vector)
        {
            OriginPoint = new Point(OriginPoint.X + vector.X, OriginPoint.Y + vector.Y);
        }

        public bool IsInside(Point p)
        {
            var xTrue = Helpers.IsBetween(p.X, OriginPoint.X, OriginPoint.X + Width);
            var yTrue = Helpers.IsBetween(p.Y, OriginPoint.Y, OriginPoint.Y + Width);
            return xTrue && yTrue;
        }


        public void SaveText(XmlDocument doc)
        {
            var node = doc.CreateElement("text");
            node.SetAttribute("style", GenerateTextStyle());
            node.SetAttribute("x", ((Width / 2) - (FontSize.Width / 3)).ToString());
            node.SetAttribute("y", ((Height / 2) + (FontSize.Height / 4)).ToString());
            node.InnerText = Text;
            doc.DocumentElement.SelectSingleNode("/svg/g").AppendChild(node);
        }

        string GenerateTextStyle()
        {
            Console.WriteLine(FontType.FontFamily.Name);
            string result;
            result = "font-style:normal;";
            result += "font-weight:normal;";
            result += "font-size:" + (int)FontType.Size + "px;";
            result += "line-height:100%;";
            result += "font-family:'" + FontType.FontFamily.Name + "';";
            result += "letter-spacing:0px;";
            result += "fill:"+ColorTranslator.ToHtml(FontColor)+";";
            return result;
        }
    }
}
