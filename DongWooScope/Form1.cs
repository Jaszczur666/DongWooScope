﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DongWooScope
{

    public partial class Form1 : Form
    {
        
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Form1()
        {
            InitializeComponent();
            petla=new ELoop();
            petla.OnDataAvailable += new ELoop.DataAvailableHandler(this.UpdateChart);
            petla.OnExperimentFinished += new ELoop.ExperimentFinishedHandler(FinishExperiment);
            log.Info("Started form");
            krok = 0;
            filename = "";
        }

        private void FinishExperiment()
        {
            Invoke((MethodInvoker)delegate
            {
                this.BackColor = Color.LimeGreen;
                string dane = "";
                for (int i = 0; i < chart1.Series[0].Points.Count; i++) { dane += chart1.Series[0].Points[i].XValue + " " + chart1.Series[0].Points[i].YValues[0] + "\r\n"; };
                System.IO.File.WriteAllText("dane.dat", dane);
            });
            }

        private void UpdateChart()
        {
            double lam0, step, end;
            double.TryParse(tbStart.Text, out lam0);
            double.TryParse(tbStep.Text, out step);
            double.TryParse(tbEnd.Text, out end);
            log.Info("Chart update ");
            Invoke((MethodInvoker) delegate {
                Tektro.curve lastcurve;
                petla.GetLastCurve(out lastcurve);
                double integral = 0;
                for (int i = 0; i < lastcurve.decay.Count; i++) { integral += lastcurve.decay[i].y; };
                double cw=new double();
                cw = lastcurve.exc;
                chart1.Series[0].Points.AddXY(lastcurve.exc, integral);
                double val = 1000.0 * (cw- lam0) / (end - lam0);
                toolStripProgressBar1.Value = (int)val;
                toolStripStatusLabel1.Text = cw.ToString();
                TimeSpan time = TimeSpan.FromSeconds((int)(3.9 * ((end - cw) / step)));
                toolStripStatusLabel2.Text = time.ToString();
                });
            krok++;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double lam0,step,end;
            //krotki.InitializePort(Mono1comboBox.Text);
            //dlugi.InitializePort(mono2ComboBox.Text);
            double.TryParse(tbStart.Text, out lam0);
            double.TryParse(tbStep.Text, out step);
            double.TryParse(tbEnd.Text, out end);
            petla.SetSampleLabel(filename);
            //dlugi.Goto(lam0);
            //Oscyloskop.Initialize();
            //przetwornik.InitializeADC(ADCcomboBox.Text);
            petla.initMono1(Mono1comboBox.Text);
            petla.InitScope();
            double wl;
            log.Info(lam0 + " " + step + " " + end);
            //Console.WriteLine(lam0 + " " + step + " " + end);
            wl = lam0;//; wl <= end; wl+= step
            if (step == 0) step = 1;
            petla.PostMessage("goto1 " + (lam0 - step).ToString());
            for (int i=0;lam0+i*step<=end;i++)
            {
                wl = lam0 + i * step;
                petla.PostMessage("wait 100");
                //Console.WriteLine("wait 100");
                petla.PostMessage("scan1 " + wl.ToString());
                //Console.WriteLine("info: scan1 " + wl.ToString("G4", System.Globalization.CultureInfo.InvariantCulture));
                //log.Info("scan1 " + wl.ToString("G4", System.Globalization.CultureInfo.InvariantCulture));
                petla.PostMessage("rstscope");
                petla.PostMessage("wait 3500");
                petla.PostMessage("decay");
                
            }
            
            petla.PostMessage("dump");
            krok = 0;
            //timer1.Enabled = true;
            petla.loop();
            //petla.ProcessMessages();
            
            
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
            //start = double.Parse(tbStart.Text);
            //stepsize = double.Parse(tbStep.Text);
            //end = double.Parse(tbEnd.Text);
            double.TryParse(tbStart.Text, out start);
            double.TryParse(tbStep.Text, out stepsize);
            double.TryParse(tbEnd.Text, out end);

            double lambda;
            lambda = start + krok * stepsize;
            if ((lambda>0)&&(lambda <= end))            {
                //dlugi.ScanTo(lambda);
                //krotki.Goto(lambda+3.6);

                //double voltage = przetwornik.ReadValue();
                //List<Tektro.punkt> curve= new List<Tektro.punkt>();
                //Oscyloskop.dumpList(out curve);
                double voltage = 0;
                //foreach (Tektro.punkt p in curve) voltage += p.x;
                chart1.Series[0].Points.AddXY(lambda, voltage);
                krok++;
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                //Console.WriteLine("Info: Trud skonczon");
                log.Info("Fight for better socialistic tommorow finished");
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            /*petla.initScope();
            petla.PostMessage("decay");
            petla.PostMessage("dump");
            petla.loop();
            */
            //   petla.loop();
            petla.fakedecay();
            petla.SetSampleLabel(filename);
            petla.PostMessage("dump");
            petla.loop();
            //UpdateChart();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }
        public void setFilename( string fname)
        {
            filename = fname;
            petla.SetSampleLabel(fname);

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            f2.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            petla.initMono1(Mono1comboBox.Text);
            ManipulationForm f3 = new ManipulationForm(this);
            f3.Show();
        }
    }
}
