using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KmlWriter;

namespace KML_Player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Stop();
        }

        private ReadFlightLog ReadFlightLog = new ReadFlightLog();
        private KmlWriter.KmlWriter KmlWriter = new KmlWriter.KmlWriter();
        private List<Tuple<double, double, double>> path = new List<Tuple<double, double, double>>();
        private int counter = 0;

        private void button_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                textBox_file.Text = ofd.FileName;
            }
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            if(File.Exists(textBox_file.Text))
            {
                if(!ReadFlightLog.ReadFile(textBox_file.Text))
                {
                    MessageBox.Show("Error finding flight data");
                    return;
                }
            }
            else
            {
                MessageBox.Show("File does not exist");
                return;
            }

            path.Clear();
            counter = 0;
            timer1.Start();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var data = ReadFlightLog.GetPosition(counter);

            if(data != null)
            {
                path.Add(new Tuple<double, double, double>(data.lat, data.lon, data.alt));

                KmlWriter.UpdateKmlPath(path, "Hdg:" + data.hdg);
                KmlWriter.UpdateKmlVehicle(data.lat, data.lon, data.alt, data.hdg, counter.ToString(), "Test");

                label_status.Text = $"{counter}: Lat:{data.lat} Lon:{data.lon}";
                counter += 12;//log rate is about 25 messages per second, so skip some a 2Hz
            }
        }
    }
}
