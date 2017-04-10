using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VectorCardEditor
{
    public partial class Form3 : Form
    {
        CardsManager Manager;

        /*public Form3(CardsManager cardMan)
        {
            Manager = cardMan;
            InitializeComponent();
        }*/
        public Form3(string txt)
        {
            InitializeComponent();
            textBox1.Text = txt;
        }

    }
}
