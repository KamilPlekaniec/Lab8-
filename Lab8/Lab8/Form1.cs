using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ZombieApocalypse
{
    public enum PlayerType
    {
        Human,
        Soldier,
        Zombie
    }
    public partial class Form1 : Form
    {
        List<Control> humans = new List<Control>();
        List<Control> players = new List<Control>();
        List<Control> soldiers = new List<Control>();
        List<Control> zombies = new List<Control>();
        public decimal Money { get; set; }
        public int Strength { get; set; }
        public int Rounds { get; set; }
        public int Durability { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control item in panel1.Controls)
            {
                foreach (Control item2 in panel1.Controls)
                {
                    if(item == item2)
                    {
                        continue;
                    }
                    if(Math.Abs(item.Location.X - item2.Location.X) < 20 || Math.Abs(item.Location.Y - item2.Location.Y) < 20 )
                    {
                        
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text))
            {
                return;
            }
            var random = new Random();
            FillList(int.Parse(textBox1.Text), humans, players, PlayerType.Human, panel1, random );
            FillList(int.Parse(textBox2.Text), soldiers, players, PlayerType.Soldier, panel1, random );
            FillList(int.Parse(textBox3.Text), zombies, players, PlayerType.Zombie, panel1, random );

            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            button2.Enabled = true;
            button1.Visible = false;
            

        }

        public void FillList(int amount, List<Control> controls, List<Control> allControls, PlayerType playerType, Panel board, Random random)
        {
            
            for (int i = 0; i < amount; i++)
            {
                
                Control newPlayer = new PictureBox()
                {
                    Location = new Point(random.Next(20, 230), random.Next(20, 230)),
                    Height = 10,
                    Width = 10
                };

                switch (playerType)
                {
                    case PlayerType.Human:
                        newPlayer.BackColor = Color.Blue;
                        break;
                    case PlayerType.Soldier:
                        newPlayer.BackColor = Color.DarkGreen;
                        break;
                    case PlayerType.Zombie:
                        newPlayer.BackColor = Color.Red;
                        break;
                }

                controls.Add(newPlayer);
                allControls.Add(newPlayer);
                board.Controls.Add(newPlayer);
            }
        }
    }
}
