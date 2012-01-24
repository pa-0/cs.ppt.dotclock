using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Dot_clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Time tim = new Time();
        Thread disp=null;
        int[,] x = new int[20, 20];
        int[,] y = new int[20, 20];
        int[,] stx = new int[20, 20];
        int[,] sty = new int[20, 20];
        int X,Y;
        #region the int areas
        int[, , ,] num1 = new int[10, 20, 2, 1]{
    {{{40},{10}},{{30},{10}},{{20},{10}},{{10},{10}},{{10},{20}},{{10},{30}},{{10},{40}},{{10},{50}},{{10},{60}},{{10},{70}},{{20},{70}},{{30},{70}},{{40},{70}},{{40},{60}},{{40},{50}},{{40},{40}},{{40},{30}},{{40},{20}},{{40},{20}},{{40},{20}}},
    {{{40},{10}},{{40},{20}},{{40},{30}},{{40},{40}},{{40},{50}},{{40},{60}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}}},
    {{{10},{10}},{{20},{10}},{{30},{10}},{{40},{10}},{{40},{20}},{{40},{30}},{{40},{40}},{{30},{40}},{{20},{40}},{{10},{40}},{{10},{50}},{{10},{60}},{{10},{70}},{{20},{70}},{{30},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}}},
    {{{10},{10}},{{20},{10}},{{30},{10}},{{40},{10}},{{40},{20}},{{40},{30}},{{40},{40}},{{30},{40}},{{20},{40}},{{10},{40}},{{40},{50}},{{40},{60}},{{40},{70}},{{30},{70}},{{20},{70}},{{10},{70}},{{10},{70}},{{10},{70}},{{10},{70}},{{10},{70}}},
    {{{10},{10}},{{10},{20}},{{10},{30}},{{10},{40}},{{20},{40}},{{30},{40}},{{40},{40}},{{40},{30}},{{40},{20}},{{40},{10}},{{40},{50}},{{40},{60}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}}},
    {{{40},{10}},{{30},{10}},{{20},{10}},{{10},{10}},{{10},{20}},{{10},{30}},{{10},{40}},{{20},{40}},{{30},{40}},{{40},{40}},{{40},{50}},{{40},{60}},{{40},{70}},{{30},{70}},{{20},{70}},{{10},{70}},{{10},{70}},{{10},{70}},{{10},{70}},{{10},{70}}},
    {{{40},{10}},{{30},{10}},{{20},{10}},{{10},{10}},{{10},{20}},{{10},{30}},{{10},{40}},{{10},{50}},{{10},{60}},{{10},{70}},{{20},{70}},{{30},{70}},{{40},{70}},{{40},{60}},{{40},{50}},{{40},{40}},{{30},{40}},{{20},{40}},{{20},{40}},{{20},{40}}},
    {{{10},{10}},{{20},{10}},{{30},{10}},{{40},{10}},{{40},{20}},{{40},{30}},{{40},{40}},{{40},{50}},{{40},{60}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}}},
    {{{40},{10}},{{30},{10}},{{20},{10}},{{10},{10}},{{10},{20}},{{10},{30}},{{10},{40}},{{20},{40}},{{30},{40}},{{40},{40}},{{40},{50}},{{40},{60}},{{40},{70}},{{30},{70}},{{20},{70}},{{10},{70}},{{10},{60}},{{10},{50}},{{40},{30}},{{40},{20}}},
    {{{10},{10}},{{20},{10}},{{30},{10}},{{40},{10}},{{40},{20}},{{40},{30}},{{40},{40}},{{30},{40}},{{20},{40}},{{10},{40}},{{10},{30}},{{10},{20}},{{40},{50}},{{40},{60}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}},{{40},{70}}}};
        #endregion
        public static void Main()
        {
            Application.Run(new Form1());
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            Opacity = .7d;
            if (disp == null)
            {
               disp = new Thread(new ThreadStart(dun));
               tim.start();
               disp.Start();
            }
        }
        public void stopAnim()
        { 
         if (disp != null)
            {
              disp = null;
              tim.time=null;
            }
        }
        public void frew()
        {
            for(int a=0;a<=5;a++)
            {
                for(int b=0;b<=19;b++)
                {
                    stx[0,b]=num1[tim.number[0],b,0,0];
                    sty[0,b]=num1[tim.number[0],b,1,0];
                    stx[1,b]=num1[tim.number[1],b,0,0]+50;
                    sty[1, b] = num1[tim.number[1],b,1,0];
                    stx[2, b] = num1[tim.number[2],b,0,0] + 125;
                    sty[2, b] = num1[tim.number[2],b,1,0];
                    stx[3, b] = num1[tim.number[3],b,0,0] + 175;
                    sty[3, b] = num1[tim.number[3],b,1,0];
                    stx[4, b] = num1[tim.number[4],b,0,0] + 250;
                    sty[4, b] = num1[tim.number[4],b,1,0];
                    stx[5, b] = num1[tim.number[5],b,0,0] + 300;
                    sty[5, b] = num1[tim.number[5],b,1,0];
                    if (x[a,b]<stx[a,b])
                    {
                        X=stx[a,b]/x[a,b];
                        x[a,b]=x[a,b]+X;
                    }
                    if(x[a,b]>stx[a,b])
                    {
                        X=x[a,b]/stx[a,b];
                        x[a,b]=x[a,b]-X;
                    }
                    if (y[a,b]<sty[a,b])
                    {
                        Y=sty[a,b]/y[a,b];
                        y[a,b]=y[a,b]+Y;
                    }
                    if(y[a,b]>sty[a,b])
                    {
                        Y=y[a,b]/sty[a,b];
                        y[a,b]=y[a,b]-Y;
                    }
                }
            }
        }
        void dun()
        {
            for(int b=0;b<=19;b++)
            {
                x[0,b]= num1[tim.number[0],b,0,0];
                x[1,b]=num1[tim.number[1],b,0,0];
                x[2,b]=num1[tim.number[2],b,0,0];
                x[3,b]=num1[tim.number[3],b,0,0];
                x[4,b]=num1[tim.number[4],b,0,0];
                x[5,b]=num1[tim.number[5],b,0,0];
                y[0,b]=num1[tim.number[0],b,1,0];
                y[1,b]=num1[tim.number[1],b,1,0];
                y[2,b]=num1[tim.number[2],b,1,0];
                y[3,b]=num1[tim.number[3],b,1,0];
                y[4,b]=num1[tim.number[4],b,1,0];
                y[5,b]=num1[tim.number[5],b,1,0];
            }
            while(disp!=null)
            {
                frew();
                this.Invalidate();
                Thread.Sleep(10);
            }
        }
        protected override void OnPaintBackground(
            System.Windows.Forms.PaintEventArgs pevent)
        {
        }
        public void paint(Graphics g2)
        {
            for (int a=0;a<=5;a++)
            {
                for(int b=0;b<=19;b++)
                {
                    g2.FillEllipse(Brushes.Red, x[a,b],y[a,b], 10, 10);
                }
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            Bitmap drawing = null;
            drawing = new Bitmap(this.Width, this.Height, e.Graphics);
            g = Graphics.FromImage(drawing);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // Draw a rectangle.
            g.FillRectangle(Brushes.Black, new Rectangle(new Point(0, 0),
                this.ClientSize));
            paint(g);
            e.Graphics.DrawImageUnscaled(drawing, 0, 0);
            g.Dispose();
        }
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            this.Opacity = 1d;
        }
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            this.Opacity = .6d;
        }
    }
    public class Time
    {
        public int[] number = new int[6];
        public Thread time;
        public Time()
        {
            time = new Thread(new ThreadStart(run));
            time.Start();
        }
        public void seperate(int dig,int a)
        {
            if(a>=0&&a<10)
            {
                number[dig]=0;
                number[dig+1]=a;
            }
            if(a==10)
            {
                number[dig]=1;
                number[dig+1]=0;
            }
            if(a>10&&a<20)
            {
                number[dig]=1;
                number[dig+1]=a-10;
            }
            if(a==20)
            {
                number[dig]=2;
                number[dig+1]=0;
            }
            if(a>20&&a<30)
            {
                number[dig]=2;
                number[dig+1]=a-20;
            }
            if(a==30)
            {
                number[dig]=3;
                number[dig+1]=0;
            }
            if(a>30&&a<40)
            {
                number[dig]=3;
                number[dig+1]=a-30;
            }
            if(a==40)
            {
                number[dig]=4;
                number[dig+1]=0;
            }
            if(a>40&&a<50)
            {
                number[dig]=4;
                number[dig+1]=a-40;
            }
            if(a==50)
            {
                number[dig]=5;
                number[dig+1]=0;
            }
            if(a>50&&a<60)
            {
                number[dig]=5;
                number[dig+1]=a-50;
            }
            if(a==60)
            {
                number[dig]=0;
                number[dig+1]=0;
            }
        }
        public void start()
        {
            if(time==null)
            {
                time.Start();
            }
        }
        public void run()
        {
            while(true)
            {
                string str = DateTime.Now.ToString();
                int index = str.IndexOf(":");
                seperate(0, int.Parse(str.Substring(index-2, 2)));
                seperate(2, int.Parse(str.Substring(index+1, 2)));
                seperate(4, int.Parse(str.Substring(index + 4, 2)));
                Thread.Sleep(10);
            }
        }
    }
}