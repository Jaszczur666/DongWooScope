using System;
using System.Diagnostics;

public class Monochromator
{
    private System.IO.Ports.SerialPort serialPort1;
    public string name;
    public void Goto(double lambda)
    {
        string res;
        if (this.serialPort1.IsOpen)
        {
            Console.WriteLine("DEBUG: "+this.name + " Attempting step to " + lambda.ToString());
            //this.serialPort1.BaseStream.Flush();
            //this.serialPort1.DiscardInBuffer();
            this.serialPort1.WriteLine("sl" + lambda.ToString());
            
           
            Console.WriteLine("DEBUG: Reading response from " +this.name);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            while (this.serialPort1.BytesToRead == 0) ;
            Console.WriteLine("DEBUG: "+this.name+" "+sw.ElapsedMilliseconds.ToString() + " ms waited for  start of the response");
            res = "";
            if (this.serialPort1.BytesToRead > 0)
            {
                bool finish = false;
                while (!finish)
                {

                    char znak = (char)this.serialPort1.ReadByte();
                    if (znak == '*' || znak == '!') finish = true;
                    res += znak.ToString();
                    //Console.Write(znak);
                }
                Console.WriteLine("DEBUG: " + this.name + " " + sw.ElapsedMilliseconds.ToString() + " ms waited for  end of the response");
                //Console.WriteLine(" ");
            }
            
            //res =this.serialPort1.ReadTo("*");
            Console.WriteLine("DEBUG: " +this.name+ " Buffer length is " + this.serialPort1.BytesToRead );
            Console.WriteLine("DEBUG: " +this.name+ " Response was: " + res);
            
        };
    }
    public void InitializePort(string pname)
    {
        this.serialPort1.PortName = pname;
        Console.WriteLine(this.ToString());
        Console.WriteLine(pname);
        if (!this.serialPort1.IsOpen) this.serialPort1.Open();
    }
    public Monochromator()
    {
        this.serialPort1 = new System.IO.Ports.SerialPort();
        this.serialPort1.StopBits = System.IO.Ports.StopBits.One;
        this.serialPort1.BaudRate = 9600;
        this.serialPort1.DataBits = 8;
        this.serialPort1.Parity = System.IO.Ports.Parity.None;
        this.serialPort1.PortName = "COM1";
        this.serialPort1.NewLine ="\r\n";
        this.name = "unset";
        
    }
}
