using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace VectorCardEditor
{
    public partial class Form1 : Form
    {
        public const int HEIGHT_DIFF = 61;

        CardsManager Manager = new CardsManager();

        Image BackgroundImage;

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

            ClientSize = new Size(800, 600 + HEIGHT_DIFF);

            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);

            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (BackgroundImage != null)
            {
                e.Graphics.DrawImage(BackgroundImage, new Point(0, HEIGHT_DIFF));
            }

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
            Manager.CardSetup.Shape = ShapeType.Ellipse;
            ShapePanel.Visible = false;
            foreach (var item in Manager.SelectedCardsList)
            {
                item.Shape = new EllipseShape(item.Width, item.Height);
                item.Shape.FillColor = Manager.CardSetup.ShapeColor;
                item.Shape.StrokeColor = Manager.CardSetup.StrokeColor;
                item.Shape.StrokeWidth = Manager.CardSetup.StrokeWidth;
            }
            ShapeButton.Image = EllipseButton.Image;
            Refresh();
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            Manager.CardSetup.Shape = ShapeType.Rectangle;
            ShapePanel.Visible = false;
            foreach (var item in Manager.SelectedCardsList)
            {
                item.Shape = new RectangleShape(item.Width, item.Height);
                item.Shape.FillColor = Manager.CardSetup.ShapeColor;
                item.Shape.StrokeColor = Manager.CardSetup.StrokeColor;
                item.Shape.StrokeWidth = Manager.CardSetup.StrokeWidth;
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

                Manager.CardSetup.ShapeColor = colorDialog1.Color;
            }
            foreach (var item in Manager.SelectedCardsList)
            {
                item.Shape.FillColor = Manager.CardSetup.ShapeColor;
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
            ProcessHideTextBox(e);
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

        void ProcessHideTextBox(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.H)
            {
                var item = zobrazSkryTextovePoleToolStripMenuItem;
                item.Checked = !item.Checked;
                textBox1.Visible = !textBox1.Visible;
                GenerateCardButton.Visible = !GenerateCardButton.Visible;
                label4.Visible = !label4.Visible;
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager.SaveAsSVG();
        }

        private void GenerateCardButton_Click(object sender, EventArgs e)
        {
            var origins = Manager.CardsList.Select(p => p.OriginPoint).ToList();

            var text = textBox1.Text;
            var split = text.Split('\n');

            var width = 0.0;
            var height = 0.0;

            var g = CreateGraphics();

            if (Manager.CardsList.Count > 0)
            {
                width = Manager.CardsList[0].Width;
                height = Manager.CardsList[0].Height;
            }
            else
            {
               
                foreach (var item in split)
                {
                    var size = g.MeasureString(item, Manager.CardSetup.Font);
                    if (size.Width > width) width = size.Width;
                    if (size.Height > height) height = size.Height;
                }
                width += 20f;
                height += 20f;

            }

            Manager.DeleteAllCards();
            var position = 0;
            for (int i = 0; i < split.Length; i++)
            {

                var card = new Card(width, height);

                if (Manager.CardSetup.Shape == ShapeType.Ellipse)
                {
                    card.Shape = new EllipseShape(card.Width, card.Height);
                }
                else if (Manager.CardSetup.Shape == ShapeType.Rectangle)
                {
                    card.Shape = new RectangleShape(card.Width, card.Height);
                }
                card.Shape.FillColor = Manager.CardSetup.ShapeColor;
                card.Shape.StrokeColor = Manager.CardSetup.StrokeColor;
                card.Shape.StrokeWidth = Manager.CardSetup.StrokeWidth;
                card.ShowGrid = true;
                card.Text = split[i];
                card.FontType = Manager.CardSetup.Font;
                card.FontColor = Manager.CardSetup.FontColor;
                card.FontSize = g.MeasureString(split[i], Manager.CardSetup.Font);

                if (i < origins.Count)
                {
                    card.OriginPoint = origins[i];
                }
                else
                {
                    card.OriginPoint = new Point(300, 100 + (((int)card.RealHeight + 5) * position));
                    position++;
                }
                
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
            RefreshSetup();
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
            else if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = comboBox1.Text;

            int size = 0;
            var success = int.TryParse(comboBox2.Text, out size);
            if (!success) size = 12;

            Manager.CardSetup.Font = new Font(new FontFamily(text), size);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = comboBox1.Text;

            int size = 0;
            var success = int.TryParse(comboBox2.Text, out size);
            if (!success) size = 12;

            Manager.CardSetup.Font = new Font(new FontFamily(text), size);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FontColorButton.BackColor = dialog.Color;

                Manager.CardSetup.FontColor = dialog.Color;
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

                Manager.CardSetup.StrokeColor = dialog.Color;
            }
            foreach (var item in Manager.SelectedCardsList)
            {
                item.Shape.StrokeColor = Manager.CardSetup.StrokeColor;
            }
            Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Manager.CardSetup.StrokeWidth = (int)numericUpDown1.Value;
            foreach (var item in Manager.SelectedCardsList)
            {
                item.Shape.StrokeWidth = Manager.CardSetup.StrokeWidth;
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

        private void zobrazSkryTextovePoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = (sender as ToolStripMenuItem);
            item.Checked = !item.Checked;
            textBox1.Visible = !textBox1.Visible;
            GenerateCardButton.Visible = !GenerateCardButton.Visible;
            label4.Visible = !label4.Visible;
        }

        private void nastaviťPozadieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetBackgroud();
        }

        private void nastaviťPozadieToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SetBackgroud();
        }

        void SetBackgroud()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image files (*.jpg, *.jpeg, *.gif, *.png) | *.jpg; *.jpeg; *.gif; *.png";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName != "")
                {
                    BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                    Refresh();
                }
            }
        }

        private void doSúboruToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manager.SaveCoordinatesToFile();
        }

        private void doClipboarduToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = Manager.GenerateCardsCoordinates();
            var text = item.Item1 + Environment.NewLine + item.Item2;
            var form = new Form3(text);
            form.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Manager.CardSetup.Text = textBox1.Text;
        }

        private void RefreshSetup()
        {
            var setup = Manager.CardSetup;
            textBox1.Text = setup.Text;
            StrokeColorButton.BackColor = setup.StrokeColor;
            ColorButton.BackColor = setup.ShapeColor;
            numericUpDown1.Value = setup.StrokeWidth;
            FontColorButton.BackColor = setup.FontColor;

            if (setup.Shape == ShapeType.Ellipse)
            {
                ShapeButton.Image = EllipseButton.Image;
            }
            else if (setup.Shape == ShapeType.Rectangle)
            {
                ShapeButton.Image = RectangleButton.Image;
            }

            var size = (int)setup.Font.Size;
            var fontName = setup.Font.FontFamily.Name;

            comboBox1.Text = fontName;
            comboBox2.Text = size.ToString();
        }
    }
}
