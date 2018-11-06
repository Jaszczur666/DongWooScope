namespace DongWooSharp
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Startbutt = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.tbStep = new System.Windows.Forms.TextBox();
            this.tbEnd = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Mono1comboBox = new System.Windows.Forms.ComboBox();
            this.ADCcomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mono2ComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.Text;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(941, 513);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Startbutt
            // 
            this.Startbutt.Location = new System.Drawing.Point(12, 23);
            this.Startbutt.Name = "Startbutt";
            this.Startbutt.Size = new System.Drawing.Size(75, 23);
            this.Startbutt.TabIndex = 7;
            this.Startbutt.Text = "Start";
            this.Startbutt.UseVisualStyleBackColor = true;
            this.Startbutt.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Location = new System.Drawing.Point(127, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 513);
            this.panel1.TabIndex = 42;
            // 
            // tbStart
            // 
            this.tbStart.Location = new System.Drawing.Point(12, 82);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(100, 20);
            this.tbStart.TabIndex = 1;
            // 
            // tbStep
            // 
            this.tbStep.Location = new System.Drawing.Point(12, 121);
            this.tbStep.Name = "tbStep";
            this.tbStep.Size = new System.Drawing.Size(100, 20);
            this.tbStep.TabIndex = 2;
            // 
            // tbEnd
            // 
            this.tbEnd.Location = new System.Drawing.Point(12, 160);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.Size = new System.Drawing.Size(100, 20);
            this.tbEnd.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Start";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Step size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 35;
            this.label3.Text = "End";
            // 
            // Mono1comboBox
            // 
            this.Mono1comboBox.FormattingEnabled = true;
            this.Mono1comboBox.Location = new System.Drawing.Point(0, 222);
            this.Mono1comboBox.Name = "Mono1comboBox";
            this.Mono1comboBox.Size = new System.Drawing.Size(121, 21);
            this.Mono1comboBox.TabIndex = 4;
            // 
            // ADCcomboBox
            // 
            this.ADCcomboBox.FormattingEnabled = true;
            this.ADCcomboBox.Location = new System.Drawing.Point(0, 307);
            this.ADCcomboBox.Name = "ADCcomboBox";
            this.ADCcomboBox.Size = new System.Drawing.Size(121, 21);
            this.ADCcomboBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mono krotki";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "ADC";
            // 
            // mono2ComboBox
            // 
            this.mono2ComboBox.FormattingEnabled = true;
            this.mono2ComboBox.Location = new System.Drawing.Point(0, 265);
            this.mono2ComboBox.Name = "mono2ComboBox";
            this.mono2ComboBox.Size = new System.Drawing.Size(121, 21);
            this.mono2ComboBox.TabIndex = 5;
            this.mono2ComboBox.SelectedIndexChanged += new System.EventHandler(this.mono2ComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Mono dlugi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 529);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mono2ComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ADCcomboBox);
            this.Controls.Add(this.Mono1comboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbEnd);
            this.Controls.Add(this.tbStep);
            this.Controls.Add(this.tbStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Startbutt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Monochromator krotki;
        private Monochromator dlugi;
        private ADC przetwornik;
        private int krok;        
        private System.Windows.Forms.Button Startbutt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.TextBox tbStep;
        private System.Windows.Forms.TextBox tbEnd;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Mono1comboBox;
        private System.Windows.Forms.ComboBox ADCcomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox mono2ComboBox;
        private System.Windows.Forms.Label label6;
    }
}

