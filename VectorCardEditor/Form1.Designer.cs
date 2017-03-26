namespace VectorCardEditor
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsPNGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upraviťToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nastaveniaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.StrokeColorButton = new System.Windows.Forms.Button();
            this.RowAlignButton = new System.Windows.Forms.Button();
            this.ColumnAlignButton = new System.Windows.Forms.Button();
            this.FontColorButton = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ShapeButton = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.ShapePanel = new System.Windows.Forms.Panel();
            this.EllipseButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.GenerateCardButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.ShapePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.upraviťToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exportAsPNGToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.fileToolStripMenuItem.Text = "Súbor";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.saveToolStripMenuItem.Text = "Uložiť";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.openToolStripMenuItem.Text = "Otvoriť";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exportToolStripMenuItem.Text = "Export ako SVG";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // exportAsPNGToolStripMenuItem
            // 
            this.exportAsPNGToolStripMenuItem.Name = "exportAsPNGToolStripMenuItem";
            this.exportAsPNGToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.exportAsPNGToolStripMenuItem.Text = "Export ako PNG";
            this.exportAsPNGToolStripMenuItem.Click += new System.EventHandler(this.exportAsPNGToolStripMenuItem_Click);
            // 
            // upraviťToolStripMenuItem
            // 
            this.upraviťToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nastaveniaToolStripMenuItem});
            this.upraviťToolStripMenuItem.Name = "upraviťToolStripMenuItem";
            this.upraviťToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.upraviťToolStripMenuItem.Text = "Upraviť";
            // 
            // nastaveniaToolStripMenuItem
            // 
            this.nastaveniaToolStripMenuItem.Name = "nastaveniaToolStripMenuItem";
            this.nastaveniaToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.nastaveniaToolStripMenuItem.Text = "Nastavenia";
            this.nastaveniaToolStripMenuItem.Click += new System.EventHandler(this.nastaveniaToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.StrokeColorButton);
            this.panel1.Controls.Add(this.RowAlignButton);
            this.panel1.Controls.Add(this.ColumnAlignButton);
            this.panel1.Controls.Add(this.FontColorButton);
            this.panel1.Controls.Add(this.comboBox2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ShapeButton);
            this.panel1.Controls.Add(this.ColorButton);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 39);
            this.panel1.TabIndex = 6;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(517, 11);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(42, 22);
            this.numericUpDown1.TabIndex = 18;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // StrokeColorButton
            // 
            this.StrokeColorButton.BackColor = System.Drawing.Color.White;
            this.StrokeColorButton.Location = new System.Drawing.Point(479, 3);
            this.StrokeColorButton.Name = "StrokeColorButton";
            this.StrokeColorButton.Size = new System.Drawing.Size(32, 32);
            this.StrokeColorButton.TabIndex = 17;
            this.StrokeColorButton.UseVisualStyleBackColor = false;
            this.StrokeColorButton.Click += new System.EventHandler(this.StrokeColorButton_Click);
            // 
            // RowAlignButton
            // 
            this.RowAlignButton.BackColor = System.Drawing.SystemColors.Control;
            this.RowAlignButton.Location = new System.Drawing.Point(646, 3);
            this.RowAlignButton.Name = "RowAlignButton";
            this.RowAlignButton.Size = new System.Drawing.Size(58, 32);
            this.RowAlignButton.TabIndex = 15;
            this.RowAlignButton.Text = "Riadok";
            this.RowAlignButton.UseVisualStyleBackColor = false;
            this.RowAlignButton.Click += new System.EventHandler(this.RowAlignButton_Click);
            // 
            // ColumnAlignButton
            // 
            this.ColumnAlignButton.BackColor = System.Drawing.SystemColors.Control;
            this.ColumnAlignButton.Location = new System.Drawing.Point(582, 3);
            this.ColumnAlignButton.Name = "ColumnAlignButton";
            this.ColumnAlignButton.Size = new System.Drawing.Size(58, 32);
            this.ColumnAlignButton.TabIndex = 14;
            this.ColumnAlignButton.Text = "Stĺpec";
            this.ColumnAlignButton.UseVisualStyleBackColor = false;
            this.ColumnAlignButton.Click += new System.EventHandler(this.ColumnAlignButton_Click);
            // 
            // FontColorButton
            // 
            this.FontColorButton.BackColor = System.Drawing.Color.Black;
            this.FontColorButton.Location = new System.Drawing.Point(237, 3);
            this.FontColorButton.Name = "FontColorButton";
            this.FontColorButton.Size = new System.Drawing.Size(32, 32);
            this.FontColorButton.TabIndex = 13;
            this.FontColorButton.UseVisualStyleBackColor = false;
            this.FontColorButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(182, 11);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(49, 21);
            this.comboBox2.TabIndex = 11;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Písmo";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(55, 11);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 11;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Tvar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Obrys";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Výplň";
            // 
            // ShapeButton
            // 
            this.ShapeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ShapeButton.Image = ((System.Drawing.Image)(resources.GetObject("ShapeButton.Image")));
            this.ShapeButton.Location = new System.Drawing.Point(324, 3);
            this.ShapeButton.Name = "ShapeButton";
            this.ShapeButton.Size = new System.Drawing.Size(32, 32);
            this.ShapeButton.TabIndex = 0;
            this.ShapeButton.UseVisualStyleBackColor = true;
            this.ShapeButton.Click += new System.EventHandler(this.ShapeButton_Click);
            // 
            // ColorButton
            // 
            this.ColorButton.BackColor = System.Drawing.Color.White;
            this.ColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ColorButton.Image = ((System.Drawing.Image)(resources.GetObject("ColorButton.Image")));
            this.ColorButton.Location = new System.Drawing.Point(401, 3);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(32, 32);
            this.ColorButton.TabIndex = 2;
            this.ColorButton.UseVisualStyleBackColor = false;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // ShapePanel
            // 
            this.ShapePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ShapePanel.Controls.Add(this.EllipseButton);
            this.ShapePanel.Controls.Add(this.RectangleButton);
            this.ShapePanel.Location = new System.Drawing.Point(324, 66);
            this.ShapePanel.Name = "ShapePanel";
            this.ShapePanel.Size = new System.Drawing.Size(39, 80);
            this.ShapePanel.TabIndex = 7;
            this.ShapePanel.Visible = false;
            // 
            // EllipseButton
            // 
            this.EllipseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("EllipseButton.Image")));
            this.EllipseButton.Location = new System.Drawing.Point(3, 41);
            this.EllipseButton.Name = "EllipseButton";
            this.EllipseButton.Size = new System.Drawing.Size(32, 32);
            this.EllipseButton.TabIndex = 9;
            this.EllipseButton.UseVisualStyleBackColor = true;
            this.EllipseButton.Click += new System.EventHandler(this.EllipseButton_Click);
            // 
            // RectangleButton
            // 
            this.RectangleButton.BackColor = System.Drawing.SystemColors.ControlDark;
            this.RectangleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.RectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("RectangleButton.Image")));
            this.RectangleButton.Location = new System.Drawing.Point(3, 3);
            this.RectangleButton.Name = "RectangleButton";
            this.RectangleButton.Size = new System.Drawing.Size(32, 32);
            this.RectangleButton.TabIndex = 8;
            this.RectangleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RectangleButton.UseVisualStyleBackColor = false;
            this.RectangleButton.Click += new System.EventHandler(this.RectangleButton_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            this.colorDialog1.ShowHelp = true;
            // 
            // GenerateCardButton
            // 
            this.GenerateCardButton.Location = new System.Drawing.Point(0, 329);
            this.GenerateCardButton.Name = "GenerateCardButton";
            this.GenerateCardButton.Size = new System.Drawing.Size(243, 23);
            this.GenerateCardButton.TabIndex = 0;
            this.GenerateCardButton.Text = "Generuj";
            this.GenerateCardButton.UseVisualStyleBackColor = true;
            this.GenerateCardButton.Click += new System.EventHandler(this.GenerateCardButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(0, 86);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(243, 237);
            this.textBox1.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.PaleTurquoise;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(0, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Text";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 600);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.GenerateCardButton);
            this.Controls.Add(this.ShapePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Text = "Vector Card Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ShapePanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShapeButton;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ShapePanel;
        private System.Windows.Forms.Button RectangleButton;
        private System.Windows.Forms.Button EllipseButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button GenerateCardButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button FontColorButton;
        private System.Windows.Forms.ToolStripMenuItem exportAsPNGToolStripMenuItem;
        private System.Windows.Forms.Button RowAlignButton;
        private System.Windows.Forms.Button ColumnAlignButton;
        private System.Windows.Forms.Button StrokeColorButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ToolStripMenuItem upraviťToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nastaveniaToolStripMenuItem;
    }
}

