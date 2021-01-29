using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DongWooScope
{
    public partial class ManipulationForm : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private Form1 mainform = null;
        public ManipulationForm()
        {
            InitializeComponent();
        }
        public void FinishedMove()
        {
            MessageBox.Show("Done");
        }
        public ManipulationForm(Form parent)
        {
            InitializeComponent();
            mainform = parent as Form1;
            mainform.petla.OnPresetDone += new ELoop.PresetDoneHandler(FinishedMove);

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(delegate {
                string grating="";
                if (this.radioButton1.Checked) grating = "1";
                if (this.radioButton2.Checked) grating = "2";
                if (this.radioButton3.Checked) grating = "3";
                log.Debug("Attempting step to wavelength " + textBox1.Text + " using grating number " + grating);
                mainform.petla.SelectGrating1(grating);
                mainform.petla.Move1(textBox1.Text);

            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
