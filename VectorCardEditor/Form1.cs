using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace VectorCardEditor
{
    public partial class Form1 : Form
    {
        ShapeType CurrentSelectedShape;
        Color CurrentColor = Color.White;

        Font CurrentFont = new Font(new FontFamily("Arial"), 12);
        Color FontColor = Color.Black;

        CardsManager Manager = new CardsManager();
 
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            colorDialog1.AllowFullOpen = true;

            toolTip1.SetToolTip(this.StrokeButton, "Set stroke for cards");
            toolTip1.SetToolTip(this.TextButton, "Add and edit text in cards");
            toolTip1.SetToolTip(this.ShapeButton, "Choose shape");
            toolTip1.SetToolTip(this.ColorButton, "Choose color");

            foreach (FontFamily oneFontFamily in FontFamily.Families)
            {
                comboBox1.Items.Add(oneFontFamily.Name);
            }
            comboBox1.Text = "Arial";

            for (int i = 8; i <= 50; i += 2)
            {
                comboBox2.Items.Add(i);
            }
            comboBox2.Text = "8";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graphics = e.Graphics;

            Manager.DrawAllCards(graphics);
        }

        #region ShapeButtons

        private void ShapeButton_Click(object sender, EventArgs e)
        {
            ShapePanel.Visible = !ShapePanel.Visible;
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            CurrentSelectedShape = ShapeType.Ellipse;
            ShapePanel.Visible = false;
            foreach (var item in Manager.SelectedCardsList)
            {
                item.Shape = new EllipseShape(item.Width, item.Height);
                item.Shape.FillColor = CurrentColor;
            }
            ShapeButton.Image = EllipseButton.Image;
            Refresh();
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            CurrentSelectedShape = ShapeType.Rectangle;
            ShapePanel.Visible = false;
            foreach (var item in Manager.SelectedCardsList)
            {
                item.Shape = new RectangleShape(item.Width, item.Height);
                item.Shape.FillColor = CurrentColor;
            }
            ShapeButton.Image = RectangleButton.Image;
            
            Refresh();
        }

        #endregion

        #region ColorButton

        private void ColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ColorButton.BackColor = colorDialog1.Color;

                CurrentColor = colorDialog1.Color;
            }
            foreach (var item in Manager.SelectedCardsList)
            {
                item.Shape.FillColor = CurrentColor;
            }
            Refresh();
            
        }

        #endregion
        Point ClickStartPoint;
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            HandleMouseSelection(e);
            Refresh();
        }


        void HandleMouseSelection(MouseEventArgs e)
        {
            bool SomethingSelected = false;

            if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                int i = 0;
                foreach (var card in Manager.CardsList)
                {
                    var xTrue = Helpers.IsBetween(e.X, card.OriginPoint.X, card.OriginPoint.X + card.Width);
                    var yTrue = Helpers.IsBetween(e.Y, card.OriginPoint.Y, card.OriginPoint.Y + card.Height);
                    if (xTrue && yTrue)
                    {
                        if (!card.Selected)
                        {
                            Manager.SelectedCardsList.Add(card);
                            i++;
                        }
                        else
                        {
                            Manager.SelectedCardsList.Remove(card);
                        }
                        card.Selected = !card.Selected;
                        SomethingSelected = true;
                    }
                }
                Console.WriteLine(i);
            }
            else if (e.Button == MouseButtons.Left)
            {
                Manager.DeselectAllCards();

                foreach (var card in Manager.CardsList)
                {
                    var xTrue = Helpers.IsBetween(e.X, card.OriginPoint.X, card.OriginPoint.X + card.Width);
                    var yTrue = Helpers.IsBetween(e.Y, card.OriginPoint.Y, card.OriginPoint.Y + card.Height);
                    if (xTrue && yTrue)
                    {
                        if (!card.Selected)
                        {
                            Manager.SelectedCardsList.Add(card);
                        }
                        card.Selected = !card.Selected;
                        SomethingSelected = true;
                    }
                }
            }

            if (!SomethingSelected)
            {
                foreach (var card in Manager.CardsList)
                {
                    card.Selected = false;
                }
                Manager.SelectedCardsList.Clear();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            ProcessSelectAll(e);
            ProcessDelete(e);

            Refresh();
        }

        void ProcessSelectAll(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                Manager.SelectedCardsList.Clear();
                foreach (var card in Manager.CardsList)
                {
                    card.Selected = true;
                    Manager.SelectedCardsList.Add(card);
                }
            }
        }

        void ProcessDelete(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Manager.DeleteSelectedCards();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager.SaveAsSVG();
        }

        private void GenerateCardButton_Click(object sender, EventArgs e)
        {
            /*double width = 100;
            double height = 100;
            var widthOK = true;
            var heightOk = true;
            Console.WriteLine(textBox1.Text);
            if (widthOK && heightOk)
            {
                var card = new Card(width, height);
                if (Manager.CardsList.Count > 0)
                {
                    var last = Manager.CardsList[Manager.CardsList.Count - 1];
                    card.OriginPoint = new Point((int)(last.OriginPoint.X + last.Width + 10), last.OriginPoint.Y);
                }
                else
                {
                    card.OriginPoint = new Point(100, 100);
                }
                if (CurrentSelectedShape == ShapeType.Ellipse)
                {
                    card.Shape = new EllipseShape(card.Width, card.Height);
                }
                else if (CurrentSelectedShape == ShapeType.Rectangle)
                {
                    card.Shape = new RectangleShape(card.Width, card.Height);
                }
                card.Shape.FillColor = CurrentColor;
                card.ShowGrid = true;
                card.AddLabel(this);
                Manager.CardsList.Add(card);
            }
            else
            {
                MessageBox.Show("Wrong input");
            }
            
            Refresh();*/
            Manager.DeleteAllCards();

            var text = textBox1.Text;
            var split = text.Split('\n');

            var width = 0f;
            var height = 0f;

            var g = CreateGraphics();
            foreach (var item in split)
            {
                var size = g.MeasureString(item, CurrentFont);
                if (size.Width > width) width = size.Width;
                if (size.Height > height) height = size.Height;
            }
            width += 20f;
            height += 20f;

            for (int i = 0; i<split.Length; i++)
            {
                var card = new Card(width, height);
                card.OriginPoint = new Point(300, 100 + (((int)height + 5) * i));
                if (CurrentSelectedShape == ShapeType.Ellipse)
                {
                    card.Shape = new EllipseShape(card.Width, card.Height);
                }
                else if (CurrentSelectedShape == ShapeType.Rectangle)
                {
                    card.Shape = new RectangleShape(card.Width, card.Height);
                }
                card.Shape.FillColor = CurrentColor;
                card.ShowGrid = true;
                card.Text = split[i];
                card.FontType = CurrentFont;
                card.FontColor = FontColor;
                card.FontSize = g.MeasureString(split[i], CurrentFont);
                Manager.CardsList.Add(card);
            }


            Refresh();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager.SaveAsSingleFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager.OpenSingleFile();
            Refresh();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            ProcessObjectMove(e);    
        }

        private void ProcessObjectMove(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && Manager.SelectedCardsList.Count > 0)
            {
                bool isInside = false;
                foreach (var item in Manager.SelectedCardsList)
                {
                    if (item.IsInside(ClickStartPoint))
                    {
                        isInside = true;
                        break;
                    }
                }
                if (isInside)
                {
                    var vector = new Point(e.X - ClickStartPoint.X, e.Y - ClickStartPoint.Y);
                    Manager.MoveAllSelectedCardsByVector(vector);
                    ClickStartPoint = e.Location;
                }
            }
            Refresh();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ClickStartPoint = e.Location;
            }
        }

        private void TextButton_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = comboBox1.Text;

            int size = 0;
            var success = int.TryParse(comboBox2.Text, out size);
            if (!success) size = 12;

            CurrentFont = new Font(new FontFamily(text), size);
            textBox1.Font = CurrentFont;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = comboBox1.Text;

            int size = 0;
            var success = int.TryParse(comboBox2.Text, out size);
            if (!success) size = 12;

            CurrentFont = new Font(new FontFamily(text), size);
            textBox1.Font = CurrentFont;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FontColorButton.BackColor = dialog.Color;

                FontColor = dialog.Color;
            }
        }
    }
}
