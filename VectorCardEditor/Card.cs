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
        [NonSerialized]
        public Label TextLabel;
        [NonSerialized] TextBox InputText;
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

            TextLabel.Location = new Point((int)(OriginPoint.X + Width / 2 - TextLabel.Width / 2), (int)(OriginPoint.Y + Height / 2 - TextLabel.Height / 2));
            InputText.Location = new Point((int)(OriginPoint.X + Width / 2 - InputText.Width / 2), (int)(OriginPoint.Y + Height / 2 - InputText.Height / 2));
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

        public void AddLabel(Form form)
        {
            TextLabel = new Label();
            TextLabel.TextAlign = ContentAlignment.MiddleCenter;
            TextLabel.AutoSize = true;
            TextLabel.Anchor = AnchorStyles.None;
            TextLabel.Location = new Point((int)(OriginPoint.X + Width / 2), (int)(OriginPoint.Y + Height / 2));
            TextLabel.BackColor = Color.Transparent;
            TextLabel.Text = Text;
            TextLabel.Anchor = AnchorStyles.Left;
            TextLabel.MouseDoubleClick += HandleTextFieldDoubleClick;
            form.Controls.Add(TextLabel);

            InputText = new TextBox();
            InputText.TextAlign = HorizontalAlignment.Center;
            InputText.Location = new Point((int)(OriginPoint.X + Width / 2 - InputText.Width / 2), (int)(OriginPoint.Y + Height / 2 - InputText.Height / 2));
            InputText.TextChanged += HandleTextChanged;
            InputText.Visible = false;
            InputText.Text = Text;
            form.Controls.Add(InputText);
        }

        private void HandleTextFieldDoubleClick(object sender, MouseEventArgs e)
        {
            SwitchTextEdit();
        }

        private void HandleTextChanged(object sender, EventArgs args)
        {
            TextLabel.Text = InputText.Text;
            Text = TextLabel.Text;
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

        public void SwitchTextEdit()
        {
            TextLabel.Visible = !TextLabel.Visible;
            InputText.Visible = !InputText.Visible;
        }

        public bool IsInsideTextBox(Point p)
        {
            var xTrue = Helpers.IsBetween(p.X, TextLabel.Location.X, TextLabel.Location.X + TextLabel.Width);
            var yTrue = Helpers.IsBetween(p.Y, TextLabel.Location.Y, TextLabel.Location.Y + TextLabel.Height);
            return xTrue && yTrue;
        }

        public void StopEdit()
        {
            TextLabel.Visible = true;
            InputText.Visible = false;
        }

        public void StartEdit()
        {
            TextLabel.Visible = false;
            InputText.Visible = true;
        }

        public void SaveText(XmlDocument doc)
        {
            var node = doc.CreateElement("text");
            node.SetAttribute("style", GenerateTextStyle());
            node.SetAttribute("x", (Width / 2 - TextLabel.Width / 2).ToString());
            node.SetAttribute("y", (Height / 2 - TextLabel.Height / 2).ToString());
            node.InnerText = Text;
            doc.DocumentElement.SelectSingleNode("/svg/g").AppendChild(node);
        }

        string GenerateTextStyle()
        {
            string result;
            result = "font-style:normal;";
            result += "font-weight:normal;";
            result += "font-size:12px;";
            result += "line-height:125%;";
            result += "font -family:'Times New Roman';";
            result += "letter-spacing:0px;";
            return result;
        }
    }
}
