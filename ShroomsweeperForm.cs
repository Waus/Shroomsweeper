using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Shroomsweeper.Properties;

namespace Shroomsweeper
{
    public partial class ShroomsweeperForm : Form
    {
        public ShroomsweeperForm()
        {
            LoadHighScores();
            InitializeComponent();
            LoadGame(null, null);
        }

        private Difficulty difficulty;

        private enum Difficulty { Hard, Medium, Easy }

        private string CurrentLevel { get; set; }
        private int NumberOfShrooms { get; set; }
        private bool GameFinished { get; set; }
        public static bool PlaySound { get; set; }
        private bool PlaySoundOptionChosen { get; set; }

        private void LoadGame(object sender, EventArgs e)
        {
            if (!PlaySoundOptionChosen)
                ShroomsweeperForm.PlaySound = true;
            GameFinished = false;
            int x, y, shrooms, poops;

            //7	  7	  49  8   6,125
            //15  15  225 40  5,625
            //15  25  375 80  4,6875

            switch (difficulty)
            {
                case Difficulty.Easy:
                    x = y = 7;
                    shrooms = poops = 8;
                    CurrentLevel = "Easy";
                    break;
                case Difficulty.Medium:
                    x = y = 15;
                    shrooms = poops = 40;
                    CurrentLevel = "Medium";
                    break;
                case Difficulty.Hard:
                    x = 25;
                    y = 15;
                    shrooms = poops = 80;
                    CurrentLevel = "Hard";
                    break;
                default:
                    throw new InvalidOperationException("Unimplemented difficulty selected");
            }

            NumberOfShrooms = shrooms;
            tileGrid.LoadGrid(new Size(x, y), shrooms, poops);
            MaximumSize = MinimumSize = new Size(tileGrid.Width + 36, tileGrid.Height + menuStrip.Height + TimerLabel.Height + 50);
            time = 0.00;
            StartTimer();
        }

        private void MakeAMove(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    tileGrid.ChangePosition(true, false, false, false);
                    break;
                case Keys.Right:
                    tileGrid.ChangePosition(false, true, false, false);
                    break;
                case Keys.Up:
                    tileGrid.ChangePosition(false, false, true, false);
                    break;
                case Keys.Down:
                    tileGrid.ChangePosition(false, false, false, true);
                    break;
                case Keys.D1:
                    difficulty = Difficulty.Easy;
                    LoadGame(null, null);
                    break;
                case Keys.D2:
                    difficulty = Difficulty.Medium;
                    LoadGame(null, null);
                    break;
                case Keys.D3:
                    difficulty = Difficulty.Hard;
                    LoadGame(null, null);
                    break;
            }
            this.CheckForWin();
            this.CheckForLose();
        }

        public void StartTimer()
        {
            this.Timer.Enabled = true;
        }

        private double time;

        private void timer_Tick(object sender, EventArgs e)
        {
            time = Math.Round(time + 0.01, 2);
            TimerLabel.Text = Convert.ToString(time);
        }

        private void CheckForWin()
        {
            if (tileGrid.ShroomsCounter == NumberOfShrooms && !GameFinished)
            {
                Timer.Enabled = false;
                var level = 0;
                switch (difficulty)
                {
                    case Difficulty.Easy:
                        level = 2;
                        break;
                    case Difficulty.Medium:
                        level = 1;
                        break;
                    case Difficulty.Hard:
                        level = 0;
                        break;
                    default:
                        throw new InvalidOperationException("Unimplemented difficulty selected");
                }
                if (PlaySound)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Win);
                    player.Play();
                }
                CheckForHighScore(level, time);
                GameFinished = true;
            }
        }
        private void CheckForLose()
        {
            if (TileGrid.GameOver == true && !GameFinished)
            {
                Timer.Enabled = false;
                //MessageBox.Show("You suck :(", "Game over", MessageBoxButtons.OK);
                GameFinished = true;
                if (PlaySound)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.Lose);
                    player.Play();
                }
            }
        }

        public HighScore[] HighScores = new HighScore[3];



        private void CheckForHighScore(int difficulty, double time)
        {
            if (HighScores[difficulty].BestTime > time || HighScores[difficulty].BestTime == null)
            {
                HighScores[difficulty].BestTime = time;
                MessageBox.Show($"You have new best time on {CurrentLevel} level! (:", "Congratulations", MessageBoxButtons.OK);
                SaveBestTime();
            }
        }

        private void LoadHighScores()
        {
            if (File.Exists("highscores.xml"))
            {
                var serializer = new XmlSerializer(HighScores.GetType(), "HighScores.Scores");
                object obj;
                using (var reader = new StreamReader("highscores.xml"))
                {
                    obj = serializer.Deserialize(reader.BaseStream);
                }
                HighScores = (HighScore[])obj;
            }
            else
            {
                HighScores[0] = new HighScore { Level = 0, BestTime = null };
                HighScores[1] = new HighScore { Level = 1, BestTime = null };
                HighScores[2] = new HighScore { Level = 2, BestTime = null };
            }
        }

        private void SaveBestTime()
        {
            var serializer = new XmlSerializer(HighScores.GetType(), "HighScores.Scores");
            using (var writer = new StreamWriter("highscores.xml", false))
            {
                serializer.Serialize(writer.BaseStream, HighScores);
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGame(null, null);
        }

        private void DifficultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            difficulty = (Difficulty)Enum.Parse(typeof(Difficulty), (string)((ToolStripMenuItem)sender).Tag);
            LoadGame(null, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutShroomsweeperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutShroomsweeperForm dialog = new AboutShroomsweeperForm();
            dialog.ShowDialog();
        }

        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HowToPlayForm dialog = new HowToPlayForm();
            dialog.ShowDialog();
        }

        private void bestTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BestTimesForm dialog = new BestTimesForm(HighScores[2], HighScores[1], HighScores[0]);
            dialog.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm dialog = new OptionsForm();
            PlaySoundOptionChosen = true;
            dialog.ShowDialog();
        }
    }
}
