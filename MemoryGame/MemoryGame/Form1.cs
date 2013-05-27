using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

namespace MemoryGame
{
    public partial class Form1 : Form
    {
        
        Color[] colorsList = new Color[]{
            Color.Red,Color.Blue, Color.Aqua, Color.Green, Color.Brown, Color.Beige,
            Color.DarkBlue, Color.Orange, Color.Olive, Color.Yellow,
            Color.LemonChiffon, Color.Lavender, Color.Indigo, Color.HotPink,
            Color.Gray, Color.Fuchsia, Color.ForestGreen, Color.Firebrick,
            Color.DodgerBlue, Color.DeepSkyBlue, Color.Violet, Color.Tomato,
            Color.Teal, Color.SpringGreen, Color.Wheat, Color.Turquoise,
            Color.Chartreuse, Color.DarkKhaki, Color.DarkOrange, Color.DarkSeaGreen,
            Color.DeepPink, Color.DodgerBlue, Color.Gainsboro, Color.Gold, 
            Color.SteelBlue,Color.Tan
        };
        private int x = 0;
        private int y = 0;
        private Button [,] buttons;
        private bool[] colorUsed = new bool[72];
        private ArrayList colors = new ArrayList();
        private int counter = 0;
        private Button prevButton = null;
        private int pairs = 0;

        public Form1()
        {
            InitializeComponent();
            resetColors();
            
        }
        private void resetColors()
        {
            for (int u = 0; u < 72; u++)
            {
                colorUsed[u] = false;
            } 
        }

        // Funkcija koja se koristi za odbiranje na pozadinska boja za 
        // kvadratite. Funkcijata koristi generator na slucajni broevi
        // za da opredeli indeks za bojata. Indeksot sluzi za pristap do
        // poleto colorsList i zemanje na soodvetnata boja od tamu.
        // Poleto colorsUsed gi sodrzi site boi za inicijalizacija.
        // Nizata colorUsed sluzi za oznacuvanje koja od boite vo colorsList
        // e zafatena. Sekoja od boite vo colorsList moze da se javi najmnogu
        // dvapati na nacrtanite kvadrati.
        
        private Color colorFunc()
        {
            int index=0;
            Random ran=new Random();
            index=ran.Next(0,x*y/2);
            while (colorUsed[index] == true)
            {
                if (colorUsed[index + (x * y / 2)] == true)
                    index = ran.Next(0, x * y / 2);
                else 
                {
                    colorUsed[index + (x * y / 2)] = true;
                    return colorsList[index];
                }
            }
            colorUsed[index] = true;
            return colorsList[index];
        }

         //Funkcija koja sluzi za iscrtuvanje na kvadratite.
         //Sekoj kvadrat e objekt od klasata Button. Prvo se
         //kreira matrica od kopcinja so odbranite dimenzii (x i y).
         //Potoa poedinecno se kreira sekoe kopce, se postavuvaat 
         //negovite dimenzii, pocetna pozicija, ime i se dodava
         //nastan za klikanje na istoto. Istovremeno, se odbira
         //bojata koja ke bide povrzana so soodvetniot kvadrat (kopce),
         //a potoa istiot se dodava na panel. 
         
       

        private void CreateTable()
        {
            buttons = new Button[x, y];
            int a = (this.Width / 2) - (x / 2) * 60;
            int b = (this.Height / 2) - (y / 2) * 60;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Height = 50,
                        Width = 50,
                    };
                    Point p = new Point(a + i * 60, b + j * 60);
                    buttons[i, j].Width = 50;
                    buttons[i, j].Height = 50;
                    buttons[i, j].Location = p;
                    buttons[i, j].Name = "btn" + i.ToString() + j.ToString();
                    buttons[i, j].Click += Form1_Click;
                    colors.Add(colorFunc());
                    panel1.Controls.Add(buttons[i, j]);
                }
            }
        }

        void Form1_Click(object sender, EventArgs e)
        {
            counter++;
            Button btn = sender as Button;
            string i = btn.Name.Substring(3, 1);
            string j = btn.Name.Substring(4, 1);
            btn.BackColor = (Color) colors[Int32.Parse(i)*y+Int32.Parse(j)];
            btn.Refresh();
            if (counter == 2)
            {
                if (btn.BackColor.Equals(prevButton.BackColor))
                {
                    System.Threading.Thread.Sleep(500);
                    prevButton.BackColor = Color.Black;
                    btn.BackColor = Color.Black;
                    pairs++;
                    if (pairs == x * y / 2)
                    {
                        MessageBox.Show("You won!");
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                    btn.BackColor = Color.LightGray;
                    prevButton.Enabled = true;
                    prevButton.BackColor = Color.LightGray;
                }
                counter = 0;
            }
            else
            {
                prevButton = btn;
                btn.Enabled = false;
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.Refresh();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click on any rectangle card to uncover the card content. With each play you can only turn over two cards. If the content of the two cards match, then repeat the process until the board is cleared out.");
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
             ProcessStartInfo AboutThisGame = new ProcessStartInfo("http://en.wikipedia.org/wiki/Concentration_(game)");  
             Process.Start(AboutThisGame);
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)//2 x 3
        {
            if (toolStripMenuItem10.Checked)
                toolStripMenuItem10.Checked = false;
            if (toolStripMenuItem9.Checked)
                toolStripMenuItem9.Checked = false;
            panel1.Controls.Clear();
            toolStripMenuItem8.Checked = true;
            x = 3;
            y = 2;
            resetColors();
            CreateTable();    

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)//9 x 8
        {
            if (toolStripMenuItem8.Checked)
                toolStripMenuItem8.Checked = false;
            if (toolStripMenuItem9.Checked)
                toolStripMenuItem9.Checked = false;
            panel1.Controls.Clear();
            toolStripMenuItem10.Checked = true;
            x = 9;
            y = 8;
            resetColors();
            CreateTable();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)// 6 x 6
        {
            if (toolStripMenuItem10.Checked)
                toolStripMenuItem10.Checked = false;
            if (toolStripMenuItem8.Checked)
                toolStripMenuItem8.Checked = false;
            panel1.Controls.Clear();
            toolStripMenuItem9.Checked = true;
            x = 6;
            y = 6;
            resetColors();
            CreateTable();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItem10.Checked)
                toolStripMenuItem10.Checked = false;
            if (toolStripMenuItem9.Checked)
                toolStripMenuItem9.Checked = false;
            panel1.Controls.Clear();
            toolStripMenuItem8.Checked = true;
            x = 3;
            y = 2;
            resetColors();
            CreateTable(); 
        }        

    }
}
