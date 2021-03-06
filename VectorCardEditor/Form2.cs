﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VectorCardEditor
{
    public partial class Form2 : Form
    {
        Form MainForm;

        public Form2(Form mainForm)
        {
            MainForm = mainForm;

            InitializeComponent();

            textBox1.Text = MainForm.ClientSize.Width.ToString();
            textBox2.Text = (MainForm.ClientSize.Height - Form1.HEIGHT_DIFF).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int width;
            int height;

            if (int.TryParse(textBox1.Text, out width) && int.TryParse(textBox2.Text, out height))
            {
                MainForm.ClientSize = new Size(width, height + Form1.HEIGHT_DIFF);
                Close();
            }
            else
            {
                MessageBox.Show("Zadajte rozmery v správnom formáte.", "Zlý vstup.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
