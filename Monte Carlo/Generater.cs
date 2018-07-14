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
using static Monte_Carlo.benchmarkclass;

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

            CStopWatch speedWatch = new CStopWatch();
            CStopWatch weavingWatch = new CStopWatch();
            CStopWatch intervalWatch = new CStopWatch();
            
            long SpeedElapsedTime;
            long WeavingElapsedTime;
            long IntervalElapsedTime;

            Task<int> speedfile = null;
            Task<int> intervaltestfile = null;
            Task<int> Weavingtestfile = null;

            if (SpeedCheck.CheckState == CheckState.Checked)
            {
                speedWatch.Start();
                speedfile = Making.speedfile(Convert.ToInt32(textBox1.Text));
            }
            if (DistanceCheck.CheckState == CheckState.Checked)
            {
                weavingWatch.Start();
                Weavingtestfile = Making.Weavingtestfile(Convert.ToInt32(textBox1.Text));
            }
            if (IntervalCheck.CheckState == CheckState.Checked)
            {
                intervalWatch.Start();
                intervaltestfile = Making.intervaltestfile(Convert.ToInt32(textBox1.Text));
            }


            if (speedfile != null)
            {
                await speedfile;
                SpeedElapsedTime = speedWatch.GetElapsedTime(CStopWatch.TIME_UNIT.MICROSECOND, true); //타임끝
                label1.Text = SpeedElapsedTime.ToString() + " μs";
            }
            if (Weavingtestfile != null)
            {
                await Weavingtestfile;
                WeavingElapsedTime = weavingWatch.GetElapsedTime(CStopWatch.TIME_UNIT.MICROSECOND, true); //타임끝
                label2.Text = WeavingElapsedTime.ToString() + " μs";
            }
            if (intervaltestfile != null)
            {
                await intervaltestfile;
                IntervalElapsedTime = intervalWatch.GetElapsedTime(CStopWatch.TIME_UNIT.MICROSECOND, true); //타임끝
                label3.Text = IntervalElapsedTime.ToString() + " μs";
            }
            GC.Collect();
            GC.WaitForPendingFinalizers();
            MessageBox.Show("완료");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("E-mail: wwponv158@gmail.com\r\nMade by KimKanghyune", "Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
