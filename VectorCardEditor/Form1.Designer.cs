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
            this.TextButton = new System.Windows.Forms.Button();
            this.ColorButton = new System.Windows.Forms.Button();
            this.StrokeButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ShapeButton = new System.Windows.Forms.Button();
            this.ShapePanel = new System.Windows.Forms.Panel();
            this.EllipseButton = new System.Windows.Forms.Button();
            this.RectangleButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.HeightTextBox = new System.Windows.Forms.TextBox();
            this.WidthTextBox = new System.Windows.Forms.TextBox();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.GenerateCardButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ShapePanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextButton
            // 
            this.TextButton.Image = ((System.Drawing.Image)(resources.GetObject("TextButton.Image")));
            this.TextButton.Location = new System.Drawing.Point(3, 39);
            this.TextButton.Name = "TextButton";
            this.TextButton.Size = new System.Drawing.Size(32, 32);
            this.TextButton.TabIndex = 1;
            this.TextButton.UseVisualStyleBackColor = true;
            this.TextButton.Click += new System.EventHandler(this.TextButton_Click);
            // 
            // ColorButton
            // 
            this.ColorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ColorButton.Image = ((System.Drawing.Image)(resources.GetObject("ColorButton.Image")));
            this.ColorButton.Location = new System.Drawing.Point(3, 77);
            this.ColorButton.Name = "ColorButton";
            this.ColorButton.Size = new System.Drawing.Size(32, 32);
            this.ColorButton.TabIndex = 2;
            this.ColorButton.UseVisualStyleBackColor = true;
            this.ColorButton.Click += new System.EventHandler(this.ColorButton_Click);
            // 
            // StrokeButton
            // 
            this.StrokeButton.Location = new System.Drawing.Point(3, 115);
            this.StrokeButton.Name = "StrokeButton";
            this.StrokeButton.Size = new System.Drawing.Size(32, 32);
            this.StrokeButton.TabIndex = 3;
            this.StrokeButton.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(897, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.exportToolStripMenuItem.Text = "Export collection";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.TextButton);
            this.panel1.Controls.Add(this.ShapeButton);
            this.panel1.Controls.Add(this.ColorButton);
            this.panel1.Controls.Add(this.StrokeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(38, 337);
            this.panel1.TabIndex = 6;
            // 
            // ShapeButton
            // 
            this.ShapeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ShapeButton.Image = ((System.Drawing.Image)(resources.GetObject("ShapeButton.Image")));
            this.ShapeButton.Location = new System.Drawing.Point(3, 3);
            this.ShapeButton.Name = "ShapeButton";
            this.ShapeButton.Size = new System.Drawing.Size(32, 32);
            this.ShapeButton.TabIndex = 0;
            this.ShapeButton.UseVisualStyleBackColor = true;
            this.ShapeButton.Click += new System.EventHandler(this.ShapeButton_Click);
            // 
            // ShapePanel
            // 
            this.ShapePanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ShapePanel.Controls.Add(this.EllipseButton);
            this.ShapePanel.Controls.Add(this.RectangleButton);
            this.ShapePanel.Location = new System.Drawing.Point(38, 24);
            this.ShapePanel.Name = "ShapePanel";
            this.ShapePanel.Size = new System.Drawing.Size(39, 80);
            this.ShapePanel.TabIndex = 7;
            this.ShapePanel.Visible = false;
            // 
            // EllipseButton
            // 
            this.EllipseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EllipseButton.Image = ((System.Drawing.Image)(resources.GetObject("EllipseButton.Image")));
            this.EllipseButton.Location = new System.Drawing.Point(3, 39);
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
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BottomPanel.Controls.Add(this.HeightTextBox);
            this.BottomPanel.Controls.Add(this.WidthTextBox);
            this.BottomPanel.Controls.Add(this.HeightLabel);
            this.BottomPanel.Controls.Add(this.WidthLabel);
            this.BottomPanel.Controls.Add(this.GenerateCardButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(38, 311);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(859, 50);
            this.BottomPanel.TabIndex = 8;
            // 
            // HeightTextBox
            // 
            this.HeightTextBox.Location = new System.Drawing.Point(65, 28);
            this.HeightTextBox.Name = "HeightTextBox";
            this.HeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.HeightTextBox.TabIndex = 4;
            this.HeightTextBox.Text = "100";
            // 
            // WidthTextBox
            // 
            this.WidthTextBox.Location = new System.Drawing.Point(65, 8);
            this.WidthTextBox.Name = "WidthTextBox";
            this.WidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.WidthTextBox.TabIndex = 3;
            this.WidthTextBox.Text = "100";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(14, 28);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(41, 13);
            this.HeightLabel.TabIndex = 2;
            this.HeightLabel.Text = "Height:";
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(14, 8);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(38, 13);
            this.WidthLabel.TabIndex = 1;
            this.WidthLabel.Text = "Width:";
            // 
            // GenerateCardButton
            // 
            this.GenerateCardButton.Location = new System.Drawing.Point(172, 15);
            this.GenerateCardButton.Name = "GenerateCardButton";
            this.GenerateCardButton.Size = new System.Drawing.Size(95, 23);
            this.GenerateCardButton.TabIndex = 0;
            this.GenerateCardButton.Text = "Generate Card";
            this.GenerateCardButton.UseVisualStyleBackColor = true;
            this.GenerateCardButton.Click += new System.EventHandler(this.GenerateCardButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(897, 361);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.ShapePanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Form1";
            this.Text = "Vector Card Editor";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ShapePanel.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShapeButton;
        private System.Windows.Forms.Button TextButton;
        private System.Windows.Forms.Button ColorButton;
        private System.Windows.Forms.Button StrokeButton;
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
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.TextBox HeightTextBox;
        private System.Windows.Forms.TextBox WidthTextBox;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Button GenerateCardButton;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

