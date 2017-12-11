using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameoOfLife
{
    public partial class Form1 : Form
    {
        const int MARK = 0;
        const int UPDATE = 1;
        int state = MARK;
       
        List<Generation> generations;
        
        bool IsUserUserDefini =false;
        public Form1()
        {
            InitializeComponent();

            generations = new List<Generation>();
            Generation first = new Generation();
            generations.Add(first);
        }
        bool GameOver()
        {

            if (!generations[generations.Count - 1].IsExtinct())
           {
               MessageBox.Show("All organisms die , generations count :" + (generations.Count - 1), "Game Over");
               return true;             
           }
           if (numericUpDown1.Value ==generations.Count-1)
           {
               MessageBox.Show("A predefined number of generations is reached, generations count :" + (generations.Count - 1), "Game Over");
               return true;
           }
           bool test = false;
           for (int i = generations.Count - 2; i >= 0; i--)
           {
               if (generations[generations.Count - 1].Equals(generations[i]))
               {
                   MessageBox.Show("The pattern of organisms repeats itself, generations count :" + (generations.Count - 1), "Game Over");
                   test = true;
                   break;
               }
           }
           return test;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            generations[generations.Count - 1].Draw(e.Graphics, state != MARK);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (state==MARK)
            {
                generations[generations.Count - 1].Mark();
                state = UPDATE;
                pictureBox1.Invalidate();
            }
            else
            {
                Generation newGeneration = generations[generations.Count - 1].Update();
                generations.Add(newGeneration);
                state = MARK;
                pictureBox1.Invalidate();
                timer1.Stop();
                label1.Text = "Generations Count : " + (generations.Count-1);
                if(!GameOver())
                {
                    
                    timer1.Start();
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Go();
        }
        private void  Go()
        {
            IsUserUserDefini = false;
            pictureBox1.Invalidate();
            timer1.Start();
        }

        private void verticalOscillationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop(); int state = MARK;
            generations.Clear();
            Generation ddd = new Generation();
            ddd.AddOrganism(29, 20); 
            ddd.AddOrganism(30, 20);
            ddd.AddOrganism(31, 20);
            generations.Add(ddd);
            pictureBox1.Invalidate(); label1.Text = "Generations Count : " + (generations.Count - 1);
        }

        private void rPentominoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop(); int state = MARK;
            generations.Clear();
            Generation ddd = new Generation();
            ddd.AddOrganism(29, 20); ddd.AddOrganism(29, 21);
            ddd.AddOrganism(30, 19); ddd.AddOrganism(30, 20);
            ddd.AddOrganism(31, 20);
            generations.Add(ddd);
            pictureBox1.Invalidate(); label1.Text = "Generations Count : " + (generations.Count - 1);
        }

        private void userDefiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            int state = MARK;
            IsUserUserDefini = true;
            generations.Clear();
            generations.Add(new Generation() );
            pictureBox1.Invalidate(); label1.Text = "Generations Count : " + (generations.Count - 1);
        }

        private void stadyStateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop(); int state = MARK;
            generations.Clear();
            Generation ddd = new Generation();
            ddd.AddOrganism(30, 19); ddd.AddOrganism(30, 20);
            generations.Add(ddd);
            pictureBox1.Invalidate();
            label1.Text = "Generations Count : " + (generations.Count - 1);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           if (IsUserUserDefini)
           {
               generations[0].AddOrganism(e.X / 20, e.Y / 20);
               pictureBox1.Invalidate();
           }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            timer1.Stop();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
