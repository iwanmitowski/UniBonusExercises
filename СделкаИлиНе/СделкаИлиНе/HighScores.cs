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

namespace СделкаИлиНе
{
    public partial class HighScores : Form
    {
        Dictionary<string, Player> players = new Dictionary<string, Player>();
        

        public HighScores()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Наистина ли искате да се върнете към менюто ?", "Изход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        public void FillCurrentPlayers()
        {
            string dest = Path.Combine("HighScore.txt");
            var lines = File.ReadAllLines(dest);

            List<string> output = new List<string>(lines);

            foreach (var line in lines)
            {
                string[] tokens = line.Split('-', (char)StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0].Trim();
                decimal prize = decimal.Parse(tokens[1]);
                Player currentPlayer = new Player(name, prize);

                if (players.ContainsKey(name))
                {
                    if (players[name].Prize < currentPlayer.Prize)
                    {
                        players[name].Prize = currentPlayer.Prize;
                    }
                }
                else
                {
                    players.Add(name, currentPlayer);
                }

            }
        }

        private void HighScores_Load(object sender, EventArgs e)
        {
            FillCurrentPlayers();

            StringBuilder sb = new StringBuilder();

            foreach (var player in players.OrderByDescending(p => p.Value.Prize))
            {
                sb.AppendLine(player.Value.ToString());
            }

            rtbHighScores.Text = sb.ToString();
        }

        private void HighScores_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res = MessageBox.Show("Наистина ли искате да се върнете към менюто ?", "Изход", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
