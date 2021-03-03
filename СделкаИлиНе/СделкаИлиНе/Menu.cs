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

    public partial class Menu : Form
    {
        public Player player = new Player(string.Empty, 0);

        public Menu()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.Hide();

            About about = new СделкаИлиНе.About();
            about.ShowDialog();

            this.Show();
        }

        private void btnHighScores_Click(object sender, EventArgs e)
        {

            this.Hide();

            HighScores highScores = new СделкаИлиНе.HighScores();
            highScores.ShowDialog();

            this.Show();
        }

        private void tbUserName_TextChanged(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(tbUserName.Text) || tbUserName.Text.Any(z => !char.IsLetter(z)))
            {
                btnStart.Enabled = false;
                errorProvider1.SetError(tbUserName, "Полето с името не може да бъде празно или да съдържа числа и символи!");
            }
            else
            {
                btnStart.Enabled = true;
                errorProvider1.SetError(tbUserName, null);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            this.Hide();

            DealOrNot dealOrNot = new СделкаИлиНе.DealOrNot();
            dealOrNot.userName = tbUserName.Text;


            dealOrNot.ShowDialog();


            this.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            MaximizeBox = false;
        }


        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {

            DialogResult res = MessageBox.Show("Наистина ли искате да излезете от играта ?", "Изход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }
    }
}
