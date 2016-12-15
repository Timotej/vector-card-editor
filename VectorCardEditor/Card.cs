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
        public  double Width { get; set; }
        public double Height { get; set; }
        public string Name { get; set; }
        public ShapeBase Shape { get; set; }

        public string Text { get; set; } = "Hello";
        public Label TextLabel { get; set; }
        public Card(double width, double height)
        {
            Width = width;
            Height = height;

            
        }

        public void DrawCard(Graphics g)
        {
            Shape.Draw(g, OriginPoint);

            //g.DrawString(Text, SystemFonts.StatusFont, Brushes.Black, new PointF((float)(OriginPoint.X + Width / 2), (float)(OriginPoint.Y + Height / 2)));

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
            
            doc.Save(file);
        }

        public void ChangeShape(ShapeBase shape)
        {
            Shape = shape;
        }

        public void AddLabel(Form form)
        {

            TextLabel = new Label();
            TextLabel.TextAlign = ContentAlignment.MiddleLeft;
            TextLabel.AutoSize = true;
            TextLabel.Location = new Point((int)(OriginPoint.X + Width / 2), (int)(OriginPoint.Y + Height / 2));
            TextLabel.Text = Text;

            form.Controls.Add(TextLabel);
        }
    }
}
