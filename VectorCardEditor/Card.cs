using System;
using System.Drawing;
using System.Drawing.Imaging;
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

        public int RealWidth
        {
            get
            {
                return (int)(Width + Shape.StrokeWidth);
            }
        }

        public int RealHeight
        {
            get
            {
                return (int)(Height + Shape.StrokeWidth);
            }
        }

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

            DrawText(g, OriginPoint);
            
            if (ShowGrid)
            {
                var diff = (int)(Shape.StrokeWidth / 2);
                var rect = new Rectangle(OriginPoint.X - diff, OriginPoint.Y - diff, (int)Width + (2 * diff), (int)Height + (2 * diff));
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

        void DrawText(Graphics g, Point originPoint)
        {
            //var rectF = new RectangleF(originPoint.X, originPoint.Y, (float)Width, (float)Height);
            var rectF = new Rectangle(originPoint.X, originPoint.Y, (int)Width, (int)Height);
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            g.DrawString(Text, FontType, new SolidBrush(FontColor), rectF, stringFormat);
            //TextRenderer.DrawText(g, Text, FontType, rectF, Color.Red, Color.Black, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.GlyphOverhangPadding);
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
            svgNode.SetAttribute("width", RealWidth.ToString());
            svgNode.SetAttribute("height", RealHeight.ToString());
            doc.AppendChild(svgNode);

            var gNode = doc.CreateElement("g");
            doc.DocumentElement.SelectSingleNode("/svg").AppendChild(gNode);

            Shape.Save(doc);
            doc.DocumentElement.SelectSingleNode("/svg/g").AppendChild(SaveText(doc));
            doc.Save(file);
        }

        public void SaveIntoSingleSVG(XmlDocument doc)
        {
            var node = doc.CreateElement("g");
            //node.AppendChild(Shape.GetXmlFormat(doc, new Point(OriginPoint.X - 300, OriginPoint.Y - 100)));
            //node.AppendChild(SaveText(doc, OriginPoint.X - 300, OriginPoint.Y - 100));
            node.AppendChild(Shape.GetXmlFormat(doc, new Point(OriginPoint.X, OriginPoint.Y)));
            node.AppendChild(SaveText(doc, OriginPoint.X, OriginPoint.Y));
            doc.DocumentElement.SelectSingleNode("/svg").AppendChild(node);
        }

        public void SaveAsPng(string file)
        {
            Bitmap b = new Bitmap((RealWidth), RealHeight);
            Graphics g = Graphics.FromImage(b);

            int pos = (int)(Shape.StrokeWidth / 2);
            Shape.Draw(g, new Point(pos, pos));
            DrawText(g, new Point(pos, pos));

            b.Save(file, ImageFormat.Png);
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


        public XmlElement SaveText(XmlDocument doc, double x = 0, double y = 0)
        {
            var node = doc.CreateElement("text");
            node.SetAttribute("style", GenerateTextStyle());
            node.SetAttribute("x", (x + (RealWidth / 2) - (FontSize.Width / 3)).ToString());
            node.SetAttribute("y", (y + (RealHeight / 2) + (FontSize.Height / 4)).ToString());
            node.InnerText = Text;
            //doc.DocumentElement.SelectSingleNode("/svg/g").AppendChild(node);
            return node;
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

        public bool IsInBottomRightCorner(Point p)
        {
            var diff = (int)(Shape.StrokeWidth / 2);
            var bl = new Point(OriginPoint.X + (int)Width + diff, OriginPoint.Y + (int)Height + diff);

            var x = p.X - bl.X;
            var y = p.Y - bl.Y;
            var dist = Math.Sqrt((x * x) + (y * y));
            return dist < 15;
        }

        public void Resize(double width, double height)
        {
            Width = width;
            Height = height;
            Shape.Resize(width, height);
        }
    }
}
