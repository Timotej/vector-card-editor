using System;
using System.Drawing;
using System.Windows.Forms;

namespace VectorCardEditor
{
    public partial class Form1 : Form
    {
        ShapeType CurrentSelectedShape;
        Color CurrentColor = Color.White;
        Color CurrentStrokeColor = Color.White;

        Font CurrentFont = new Font(new FontFamily("Arial"), 8);
        Color FontColor = Color.Black;

        CardsManager Manager = new CardsManager();
 
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            colorDialog1.AllowFullOpen = true;

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
                item.Shape.StrokeColor = CurrentStrokeColor;
                item.Shape.StrokeWidth = (int)numericUpDown1.Value;
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
                item.Shape.StrokeColor = CurrentStrokeColor;
                item.Shape.StrokeWidth = (int)numericUpDown1.Value;
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
            //HandleMouseSelection(e);
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

            var position = 0;
            for (int i = 0; i<split.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(split[i])) 
                {
                    var card = new Card(width, height);
                    
                    if (CurrentSelectedShape == ShapeType.Ellipse)
                    {
                        card.Shape = new EllipseShape(card.Width, card.Height);
                    }
                    else if (CurrentSelectedShape == ShapeType.Rectangle)
                    {
                        card.Shape = new RectangleShape(card.Width, card.Height);
                    }
                    card.Shape.FillColor = CurrentColor;
                    card.Shape.StrokeColor = CurrentStrokeColor;
                    card.Shape.StrokeWidth = (int)numericUpDown1.Value;
                    card.ShowGrid = true;
                    card.Text = split[i];
                    card.FontType = CurrentFont;
                    card.FontColor = FontColor;
                    card.FontSize = g.MeasureString(split[i], CurrentFont);

                    card.OriginPoint = new Point(300, 100 + (((int)card.RealHeight + 5) * position));
                    position++;

                    Manager.CardsList.Add(card);
                }
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
            if (Manager.IsInBottomRightCorner(e.Location))
            {
                Cursor.Current = Cursors.SizeNWSE;
            }
            else
            {
                Cursor.Current = Cursors.Default;
            }

            if (ResizingStarted)
            {
                ResizeEvent(e);
            }
            else
            {
                ProcessObjectMove(e);
            }
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


        bool ResizingStarted = false;
        Size InitialSize;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ClickStartPoint = e.Location;
                

                if (Manager.IsInBottomRightCorner(e.Location))
                {
                    ResizingStarted = true;
                    InitialSize = new Size((int)Manager.CardsList[0].Width, (int)Manager.CardsList[0].Height);
                }
                else
                {
                    HandleMouseSelection(e);
                    ResizingStarted = false;
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = comboBox1.Text;

            int size = 0;
            var success = int.TryParse(comboBox2.Text, out size);
            if (!success) size = 12;

            CurrentFont = new Font(new FontFamily(text), size);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = comboBox1.Text;

            int size = 0;
            var success = int.TryParse(comboBox2.Text, out size);
            if (!success) size = 12;

            CurrentFont = new Font(new FontFamily(text), size);
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

        private void exportAsPNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager.SaveAsPNG();
        }

        private void ResizeEvent(MouseEventArgs e)
        {
            if (ResizingStarted && e.Button == MouseButtons.Left)
            {
                var x = e.X - ClickStartPoint.X;
                var y = e.Y - ClickStartPoint.Y;
                Manager.ResizeAll(InitialSize.Width + x, InitialSize.Height + y);
                Refresh();
            }
        }

        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            ResizingStarted = false;
        }

        private void ColumnAlignButton_Click(object sender, EventArgs e)
        {
            Manager.ColumnAlign();
            Refresh();
        }

        private void RowAlignButton_Click(object sender, EventArgs e)
        {
            Manager.RowAlign();
            Refresh();
        }
        
        private void StrokeColorButton_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                StrokeColorButton.BackColor = dialog.Color;

                CurrentStrokeColor = dialog.Color;
            }
            foreach (var item in Manager.SelectedCardsList)
            {
                item.Shape.StrokeColor = CurrentStrokeColor;
            }
            Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            foreach (var item in Manager.SelectedCardsList)
            {
                item.Shape.StrokeWidth = (int)numericUpDown1.Value;
            }
            Refresh();
        }

        private void nastaveniaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new Form2(this);
            form.ShowDialog();
        }

        private void uložiťAkoSVGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager.SaveAsSingleSVG();
        }
    }
}
