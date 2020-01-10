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
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            PlaySoundCheckbox.Checked = ShroomsweeperForm.PlaySound;
        }

        public HighScore[] HighScores = new HighScore[3];

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PlaySoundCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            ShroomsweeperForm.PlaySound = PlaySoundCheckbox.Checked;
        }
    }
}
