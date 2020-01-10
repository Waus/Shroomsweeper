using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shroomsweeper
{
    public partial class BestTimesForm : Form
    {
        public BestTimesForm(HighScore bestTimeOnEasy, HighScore bestTimeOnMedium, HighScore bestTimeOnHard)
        {
            InitializeComponent();
            BestTimeOnEasy = bestTimeOnEasy.BestTime;
            BestTimeOnMedium = bestTimeOnMedium.BestTime;
            BestTimeOnHard = bestTimeOnHard.BestTime;
            SetBestTimes();
        }

        public HighScore[] HighScores = new HighScore[3];

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private double? BestTimeOnEasy { get; set; }
        private double? BestTimeOnMedium { get; set; }
        private double? BestTimeOnHard { get; set; }

        private void SetBestTimes()
        {
            EasyBestTime.Text = BestTimeOnEasy.ToString();
            MediumBestTime.Text = BestTimeOnMedium.ToString();
            HardBestTime.Text = BestTimeOnHard.ToString();
        }

    }
}
