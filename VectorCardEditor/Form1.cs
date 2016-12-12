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
        List<Card> CardsList = new List<Card>();
        List<Card> SelectedCards = new List<Card>();
        Color CurrentColor = Color.White;

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            colorDialog1.AllowFullOpen = true;

            var c = new Card(200, 200);
            c.OriginPoint = new Point(100, 100);
            c.ShowGrid = true;
            c.Shape = new EllipseShape(200, 200);

            var a = new Card(200, 200);
            a.OriginPoint = new Point(305, 100);
            a.ShowGrid = true;
            a.Shape = new EllipseShape(200, 200);

            var b = new Card(200, 200);
            b.OriginPoint = new Point(510, 100);
            b.ShowGrid = true;
            b.Shape = new EllipseShape(200, 200);

            CardsList.Add(a);
            CardsList.Add(b);
            CardsList.Add(c);

            toolTip1.SetToolTip(this.StrokeButton, "Set stroke for cards");
            toolTip1.SetToolTip(this.TextButton, "Add and edit text in cards");
            toolTip1.SetToolTip(this.ShapeButton, "Choose shape");
            toolTip1.SetToolTip(this.ColorButton, "Choose color");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var graphics = e.Graphics;


            foreach (var card in CardsList)
            {
                card.DrawCard(graphics);
            }
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
            foreach (var item in SelectedCards)
            {
                item.Shape = new EllipseShape(item.Width, item.Height);
                item.Shape.FillColor = CurrentColor;
            }

            Refresh();
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            CurrentSelectedShape = ShapeType.Rectangle;
            ShapePanel.Visible = false;
            foreach (var item in SelectedCards)
            {
                item.Shape = new RectangleShape(item.Width, item.Height);
                item.Shape.FillColor = CurrentColor;
            }

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
            foreach (var item in SelectedCards)
            {
                item.Shape.FillColor = CurrentColor;
            }
            Refresh();
            
        }

        #endregion

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
                foreach (var card in CardsList)
                {
                    var xTrue = Helpers.IsBetween(e.X, card.OriginPoint.X, card.OriginPoint.X + card.Width);
                    var yTrue = Helpers.IsBetween(e.Y, card.OriginPoint.Y, card.OriginPoint.Y + card.Width);
                    if (xTrue && yTrue)
                    {
                        if (!card.Selected)
                        {
                            SelectedCards.Add(card);
                        }
                        else
                        {
                            SelectedCards.Remove(card);
                        }
                        card.Selected = !card.Selected;
                        SomethingSelected = true;
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                foreach (var card in SelectedCards)
                {
                    card.Selected = false;
                }
                SelectedCards.Clear();
                foreach (var card in CardsList)
                {
                    var xTrue = Helpers.IsBetween(e.X, card.OriginPoint.X, card.OriginPoint.X + card.Width);
                    var yTrue = Helpers.IsBetween(e.Y, card.OriginPoint.Y, card.OriginPoint.Y + card.Width);
                    if (xTrue && yTrue)
                    {
                        if (!card.Selected)
                        {
                            SelectedCards.Add(card);
                        }
                        card.Selected = !card.Selected;
                        SomethingSelected = true;
                    }
                }
            }

            if (!SomethingSelected)
            {
                foreach (var card in CardsList)
                {
                    card.Selected = false;
                }
                SelectedCards.Clear();
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
                SelectedCards.Clear();
                foreach (var card in CardsList)
                {
                    card.Selected = true;
                    SelectedCards.Add(card);
                }
            }
        }

        void ProcessDelete(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                foreach (var card in SelectedCards)
                {
                    CardsList.Remove(card);
                }
                SelectedCards.Clear();
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FileName != "")
                {   
                    Directory.CreateDirectory(saveFileDialog1.FileName);
                    var path = Path.GetFileName(saveFileDialog1.FileName);
                    for (int i=0; i< CardsList.Count; i++)
                    {
                        CardsList[i].SaveCard(saveFileDialog1.FileName + "\\" + path + (i + 1) + ".svg");
                    }
                }
            }
        }

        private void GenerateCardButton_Click(object sender, EventArgs e)
        {
            double width;
            double height;
            var widthOK = double.TryParse(WidthTextBox.Text, out width);
            var heightOk = double.TryParse(HeightTextBox.Text, out height);

            if (widthOK && heightOk)
            {
                var card = new Card(width, height);
                var last = CardsList[CardsList.Count - 1];
                card.OriginPoint = new Point((int)(last.OriginPoint.X + last.Width + 5), last.OriginPoint.Y);
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
                CardsList.Add(card);
            }
            
            Refresh();
        }
    }
}
