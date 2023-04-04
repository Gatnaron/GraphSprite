using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphSprite
{
    public partial class Form1 : Form
    {
        Image playerImg;
        private int currFrame = 2;
        private int currAnimation = -1;
        private bool isPressAnyKey = false;
        //Graphics gr;
        public Form1()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            //gr = this.CreateGraphics();
            playerImg = new Bitmap("D:\\Учеба\\4\\Графика\\5\\sprite.png"); 
            timer1.Interval = 130;
            timer1.Tick += new EventHandler(update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(keyboard);
            this.KeyUp += new KeyEventHandler(freekeyb);
        }

        private void freekeyb(object sender, KeyEventArgs e)
        {
            isPressAnyKey = false;
        }

        private void keyboard(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "S":
                    currAnimation = 0;
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y+3);
                    break;
                case "A":
                    currAnimation = 1;
                    pictureBox1.Location = new Point(pictureBox1.Location.X-3, pictureBox1.Location.Y);
                    break;
                case "W":
                    currAnimation = 2;
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 3);
                    break;
                case "D":
                    currAnimation = 3;
                    pictureBox1.Location = new Point(pictureBox1.Location.X+3, pictureBox1.Location.Y);
                    break;
            }
            isPressAnyKey = true;
        }

        private void update(object sender, EventArgs e)
        {
            if(isPressAnyKey)
                PlayAnimation();
            if (currFrame == 9)
                currFrame = 0;
            currFrame++;
        }

        private void PlayAnimation()
        {
            if (currAnimation != -1)
            {
                Image part = new Bitmap(120, 130);
                Graphics g = Graphics.FromImage(part);
                g.DrawImage(playerImg, 0, 0, new Rectangle(new Point(120 * currFrame, 130*currAnimation), new Size(120, 130)), GraphicsUnit.Pixel);
                pictureBox1.Size = new Size(120, 130);
                pictureBox1.Image = part;
            }
        }
    }
}
