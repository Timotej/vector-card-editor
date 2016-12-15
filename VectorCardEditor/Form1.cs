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

        CardsManager Manager = new CardsManager();
 
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

            Manager.CardsList.Add(a);
            Manager.CardsList.Add(b);
            Manager.CardsList.Add(c);

            toolTip1.SetToolTip(this.StrokeButton, "Set stroke for cards");
            toolTip1.SetToolTip(this.TextButton, "Add and edit text in cards");
            toolTip1.SetToolTip(this.ShapeButton, "Choose shape");
            toolTip1.SetToolTip(this.ColorButton, "Choose color");
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
                foreach (var card in Manager.CardsList)
                {
                    var xTrue = Helpers.IsBetween(e.X, card.OriginPoint.X, card.OriginPoint.X + card.Width);
                    var yTrue = Helpers.IsBetween(e.Y, card.OriginPoint.Y, card.OriginPoint.Y + card.Width);
                    if (xTrue && yTrue)
                    {
                        if (!card.Selected)
                        {
                            Manager.SelectedCardsList.Add(card);
                        }
                        else
                        {
                            Manager.SelectedCardsList.Remove(card);
                        }
                        card.Selected = !card.Selected;
                        SomethingSelected = true;
                    }
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                Manager.DeselectAllCards();

                foreach (var card in Manager.CardsList)
                {
                    var xTrue = Helpers.IsBetween(e.X, card.OriginPoint.X, card.OriginPoint.X + card.Width);
                    var yTrue = Helpers.IsBetween(e.Y, card.OriginPoint.Y, card.OriginPoint.Y + card.Width);
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
            double width;
            double height;
            var widthOK = double.TryParse(WidthTextBox.Text, out width);
            var heightOk = double.TryParse(HeightTextBox.Text, out height);

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
                Manager.CardsList.Add(card);
            }
            else
            {
                MessageBox.Show("Wrong input");
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
    }
}
