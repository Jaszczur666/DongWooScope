using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DongWooSharp
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            krotki = new Monochromator();
            krotki.name = "Krotki";
            dlugi = new Monochromator();
            dlugi.name = "Dlugi";
            przetwornik = new ADC();
            krok = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            krotki.InitializePort(Mono1comboBox.Text);
            dlugi.InitializePort(mono2ComboBox.Text);
            przetwornik.InitializeADC(ADCcomboBox.Text);
            krok = 0;
            timer1.Enabled = true;
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string s in ports) {
                Mono1comboBox.Items.Add(s);
               mono2ComboBox.Items.Add(s);
                ADCcomboBox.Items.Add(s);
            }
            try
            {
                string config = System.IO.File.ReadAllText("ports.cfg");
                var result = System.Text.RegularExpressions.Regex.Split(config, "\r\n|\r|\n");
                ADCcomboBox.Text = result[0];
                Mono1comboBox.Text = result[1];
                mono2ComboBox.Text = result[2];
            }
            catch { };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            double start, stepsize, end;
            //Console.WriteLine("DEBUG: "+ tbStart.Text);
            start = double.Parse(tbStart.Text);
            
            stepsize = double.Parse(tbStep.Text);
            end = double.Parse(tbEnd.Text);
            double lambda;
            lambda = start + krok * stepsize;
            if (lambda <= end)
            {

                dlugi.Goto(lambda);
                krotki.Goto(lambda+3.6);

                double voltage = przetwornik.ReadValue();
                chart1.Series[0].Points.AddXY(lambda, voltage);
                krok++;
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                Console.WriteLine("Info: Trud skonczon");
                string dane="";
                for (int i = 0; i < chart1.Series[0].Points.Count; i++) { dane += chart1.Series[0].Points[i].XValue + " " + chart1.Series[0].Points[i].YValues[0]+"\r\n"; };
                System.IO.File.WriteAllText("dane.dat", dane);
            }
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            string config;
            config = ADCcomboBox.Text + "\r\n" + Mono1comboBox.Text+"\r\n"+mono2ComboBox.Text;
            System.IO.File.WriteAllText("ports.cfg", config);
        }

        private void mono2ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
