/**********************************************************************/
//
//                  Monte Carlo Algorithm Example
//
//
//
//
//
//  E-mail : wwponv158@gmail.com
//  Made by kimkanghyune
/**********************************************************************/
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte_Carlo
{
    public partial class DataGenerator : Form
    {
        public DataGenerator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        private async void Generater_Click(object sender, EventArgs e)
        {
            string dir = ".\\" + textBox1.Text + " 회 데이터";

            DirectoryInfo di = new DirectoryInfo(dir);
            if (di.Exists == false)
            {
                di.Create();
            }

            RandomDataGen Making = new RandomDataGen();
            RandomDataGen.strFilePath = dir + $"\\{ DateTime.Now.ToString("yyyy - MM - dd - HH - mm - ss")} -";

            Task<int> speedfile = null;
            Task<int> intervaltestfile = null;
            Task<int> Weavingtestfile = null;

            if (SpeedCheck.CheckState == CheckState.Checked)
            {
                speedfile = Making.speedfile(Convert.ToInt32(textBox1.Text));
            }
            if (DistanceCheck.CheckState == CheckState.Checked)
            {
                intervaltestfile = Making.intervaltestfile(Convert.ToInt32(textBox1.Text));
            }
            if (IntervalCheck.CheckState == CheckState.Checked)
            {
                Weavingtestfile = Making.Weavingtestfile(Convert.ToInt32(textBox1.Text));
            }

            await speedfile;
            await intervaltestfile;
            await Weavingtestfile;


            MessageBox.Show("완료");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("E-mail: wwponv158@gmail.com\r\nMade by KimKanghyune", "Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
