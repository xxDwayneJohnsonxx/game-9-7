using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace myvidagame
{
   
    public partial class Form1 : Form
    {
        player p1;
        player p2;
        ArrayList objects = new ArrayList();
        public Form1()
        {
           
            InitializeComponent();
            p1 = new player(player1, this);
            p2 = new player(player2, this);
            
            objects.Add(p1);
            objects.Add(p2);
        }
        public bool isClear(PictureBox P, int X, int Y)
        {
            foreach (var item in Controls)
            {
                if (typeof(PictureBox) == item.GetType() && P != item)
                {
                    PictureBox pictureBox = (PictureBox)item;
                    Rectangle newRect = new Rectangle(P.Location.X + X, P.Location.Y + Y, P.Width, P.Height);
                    if (pictureBox.Bounds.IntersectsWith(newRect))
                        return false;
                }
            }
            return true;
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int m_speed = 5;
           
            {
                m_speed = 30;
               
            }
            if (e.KeyCode==Keys.A)
            {
                p1.moveleft();
            }
            if ( e.KeyCode == Keys.D)
            {
                p1.moveright();
            }
            if (e.KeyCode == Keys.W)
            {
                p1.moveup();
                
            }
            if ( e.KeyCode == Keys.S)
            {
                p1.movedown();
               
            }
            if (e.KeyCode == Keys.Left)
            {
                p2.moveleft();
            }
            if (e.KeyCode == Keys.Right)
            {
                p2.moveright();
            }
            if (e.KeyCode == Keys.Up)
            {
                p2.moveup();
            }
            if (e.KeyCode == Keys.Down)
            {
                p2.movedown();
                isClear(player2, 5, 5);
            }


        }




        private void timer1_Tick(object sender, EventArgs e)
        {
           if (progressBar1.Value < progressBar1.Maximum)
                progressBar1.Value++;
            foreach (player item in objects)
            { 
                if (!item.m_picture.Bounds.IntersectsWith(ground.Bounds))
               item.tick();
            
            }
            
        }
       

    }
}
