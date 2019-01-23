using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DongWooScope
{
    public partial class Form2 : Form
    {
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Form1 mainForm = null;
        public Form2()
        {
            InitializeComponent();

        }

        public Form2( Form parent)
        {
            InitializeComponent();
            mainForm = parent as Form1;                
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var invalids = System.IO.Path.GetInvalidFileNameChars();
            var newName = String.Join("_", textBox1.Text.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');
            label3.Text=newName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DongWooScope.Form1.filename = label3.Text;
            
              mainForm.setFilename(label3.Text);
            log.Info("form1 filename set to " + label3.Text);
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) button1_Click(this,e) ;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
