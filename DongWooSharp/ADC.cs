using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DongWooSharp
{
    class ADC
    {
     private System.IO.Ports.SerialPort ADCPort;
        public double ReadValue() {
            double voltage=-3.0;
            if (this.ADCPort.IsOpen)
            {
                Console.WriteLine("DEBUG: Request sent to ADC");
                this.ADCPort.WriteLine("Query");
                
                string val= this.ADCPort.ReadLine();
                Int32 intval;
                Console.WriteLine("DEBUG: value received from ADC "+val);
                if (Int32.TryParse(val, out intval)) {
                    voltage = 2.048*(intval / 131072.0) / 2;
                };
                if (this.ADCPort.BytesToRead>0)
                {
                    Console.WriteLine("WARN: Something unexpected happened, further communication received");
                    string weirdstuff="";
                    while (this.ADCPort.BytesToRead != 0)
                    {
                        char znak = (char)ADCPort.ReadByte();
                        weirdstuff += znak.ToString();
                    }
                    Console.WriteLine(weirdstuff);
                }
             
            }
            return voltage;
        }
        public void InitializeADC(string PortName)
        {
            if (PortName != ADCPort.PortName)
            {
                if (this.ADCPort.IsOpen)
                {
                    this.ADCPort.Close();
                    this.ADCPort.PortName = PortName;
                    this.ADCPort.Open();
                }
                else
                {
                    this.ADCPort.PortName = PortName;
                }
            }
            if (!this.ADCPort.IsOpen)this.ADCPort.Open();
        }
        public ADC() {
            this.ADCPort = new System.IO.Ports.SerialPort();
            this.ADCPort.BaudRate = 9600;
            this.ADCPort.Parity= System.IO.Ports.Parity.None;
            this.ADCPort.StopBits = System.IO.Ports.StopBits.One;
            this.ADCPort.DataBits = 8;
            this.ADCPort.PortName = "COM1";
            this.ADCPort.NewLine = "\r\n";
        }
    }
}
