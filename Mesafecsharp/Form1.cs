using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; 

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private string data;
        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < System.IO.Ports.SerialPort.GetPortNames().Length; i++)
            {
                comboBox1.Items.Add(System.IO.Ports.SerialPort.GetPortNames()[i]);
            }
        }

        private void bağllan_Click(object sender, EventArgs e)
        {
            timer1.Start();
            try
            {
                serialPort1.PortName = comboBox1.Text;
                if (!serialPort1.IsOpen)
                    serialPort1.Open();
            }
            catch
            {
                MessageBox.Show("Seri Porta Bağlı !!");
            }
        }

        private void dur_Click(object sender, EventArgs e)
        {
            try
            {

                if (serialPort1.IsOpen)
                    serialPort1.Close();
            }
            catch
            {
                MessageBox.Show("Seri Port Kapalı !!");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             try
            {
                serialPort1.Write("1");
                int receiveddata = Convert.ToInt16(serialPort1.ReadExisting());
                receiveddata = ((receiveddata * 5000) / 1023) / 10;
                progressBar1.Value = receiveddata;
                label3.Text = receiveddata.ToString() + "Mesafe";
                System.Threading.Thread.Sleep(100);
                
            }
            catch (Exception ex) { }
        
        }
    }
}
