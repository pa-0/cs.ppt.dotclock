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
        double[,] NonStaticXDotCoordArray = new double[20, 20];
        double[,] NonStaticYDotCoordArray = new double[20, 20];
        double[,] XDotCordDestination = new double[20, 20];
        double[,] YDotCordDestination = new double[20, 20];
        double[,] XMovement = new double[6,20];
        double[,] YMovement = new double[6,20];
        #region Initializing Master cord. array
        private static int[, , ,] num1 = new int[10, 20, 2, 1]{
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
        private static int[,] LetterA = new int[20, 2] { { 70, 10 }, { 60, 10 }, { 50, 10 }, { 40, 10 }, { 30, 10 }, { 20, 10 }, { 10, 10 }, { 10, 20 }, { 10, 30 }, { 10, 40 }, { 20, 40 }, { 30, 40 }, { 40, 40 }, { 50, 40 }, { 60, 40 }, { 70, 40 }, { 30, 20 }, { 30, 30 }, { 70, 40 }, { 70, 40 } };
        private static int[,] LetterM = new int[20, 2] { { 70, 10 }, { 60, 10 }, { 50, 10 }, { 40, 10 }, { 30, 10 }, { 20, 10 }, { 10, 10 }, { 20, 20 }, { 20, 30 }, { 30, 30 }, { 30, 20 }, { 10, 40 }, { 20, 40 }, { 30, 40 }, { 40, 40 }, { 50, 40 }, { 60, 40 }, { 70, 40 }, { 70, 40 }, { 70, 40 } };
        private static int[,] LetterP = new int[20, 2] { { 70, 10 }, { 60, 10 }, { 50, 10 }, { 40, 10 }, { 30, 10 }, { 20, 10 }, { 10, 10 }, { 10, 20 }, { 10, 30 }, { 10, 40 }, { 20, 40 }, { 30, 40 }, { 40, 40 }, { 40, 30 }, { 40, 20 }, { 70, 10 }, { 70, 10 }, { 70, 10 }, { 70, 10 }, { 70, 10 } };
        private int[] TempLetterX = new int[20];
        private int[] TempLetterY = new int[20];
        private int[,] APVelo = new int[2,20];
        Graphics graph;
        Bitmap drawing = null;
        public int[] number = new int[6];
        string str = null;
        int index = 0;
        int LastSecond = 0;
        Boolean AM = true;
        Boolean LastWasAm = true;
        public static void Main()
        {
            Application.Run(new Form1());
        }
        public void Form1_Load(object sender, EventArgs e)
        {
            //Opacity = .7d;
            AM = DateTime.Now.ToShortTimeString().Contains("AM");
            if (disp == null)
            {
               disp = new Thread(new ThreadStart(dun));
               //tim.start();
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
            if (LastSecond != number[5])
            {
                for (int a = 0; a <= 5; a++)
                {
                    for (int b = 0; b <= 19; b++)
                    {
                        XDotCordDestination[0, b] = num1[number[0], b, 0, 0];
                        YDotCordDestination[0, b] = num1[number[0], b, 1, 0];
                        XDotCordDestination[1, b] = num1[number[1], b, 0, 0] + 50;
                        YDotCordDestination[1, b] = num1[number[1], b, 1, 0];
                        XDotCordDestination[2, b] = num1[number[2], b, 0, 0] + 125;
                        YDotCordDestination[2, b] = num1[number[2], b, 1, 0];
                        XDotCordDestination[3, b] = num1[number[3], b, 0, 0] + 175;
                        YDotCordDestination[3, b] = num1[number[3], b, 1, 0];
                        XDotCordDestination[4, b] = num1[number[4], b, 0, 0] + 250;
                        YDotCordDestination[4, b] = num1[number[4], b, 1, 0];
                        XDotCordDestination[5, b] = num1[number[5], b, 0, 0] + 300;
                        YDotCordDestination[5, b] = num1[number[5], b, 1, 0];
                        if (NonStaticXDotCoordArray[a, b] < XDotCordDestination[a, b])
                        {
                            XMovement[a, b] = (XDotCordDestination[a, b] - NonStaticXDotCoordArray[a, b]) / 15;
                        }
                        if (NonStaticXDotCoordArray[a, b] > XDotCordDestination[a, b])
                        {
                            XMovement[a,b] = (NonStaticXDotCoordArray[a, b] - XDotCordDestination[a, b])/15;
                        }
                        if (NonStaticYDotCoordArray[a, b] < YDotCordDestination[a, b])
                        {
                            YMovement[a,b] = (YDotCordDestination[a, b] - NonStaticYDotCoordArray[a, b])/15;
                        }
                        if (NonStaticYDotCoordArray[a, b] > YDotCordDestination[a, b])
                        {
                            YMovement[a,b] = (NonStaticYDotCoordArray[a, b] - YDotCordDestination[a, b])/15;
                        }
                    }
                }
                LastSecond = number[5];
                if (DateTime.Now.ToShortTimeString().Contains("AM"))
                    AM = true;
                else
                    LastWasAm = false;
                /*
                if (LastWasAm !=AM)
                {
                    if(DateTime.Now.ToShortTimeString().Contains("AM"))
                    {
                        for(int b = 0; b <=19;b++)
                        {
                            if (TempLetterX[b] > LetterA[b, 0])
                            {
                                APVelo[0, b] = (TempLetterX[b] - LetterA[b, 0]) / 15;
                            }
                            if (TempLetterX[b] < LetterA[b, 0])
                            {
                                APVelo[0, b] = (LetterA[b,0] - TempLetterX[b]) / 15;
                            }
                            if (TempLetterY[b] > LetterA[b,1])
                            {
                                APVelo[1, b] = (TempLetterY[b] - LetterA[b, 1])/15;
                            }
                            if (TempLetterY[b] < LetterA[b,1])
                            {
                                APVelo[1,b] = (LetterA[b,1] - TempLetterY[b])/15;
                            }
                        }
                    }
                    else
                    {
                        for(int b = 0; b <=19;b++)
                        {
                            if (TempLetterX[b] > LetterP[b, 1])
                            {
                                APVelo[0, b] = (TempLetterX[b] - LetterP[b, 1]) / 15;
                            }
                            if (TempLetterX[b] < LetterP[b, 1])
                            {
                                APVelo[0, b] = (LetterP[b, 1] - TempLetterX[b]) / 15;
                            }
                            if (TempLetterY[b] > LetterP[b, 0])
                            {
                                APVelo[1, b] = (TempLetterY[b] - LetterP[b, 0]) / 15;
                            }
                            if (TempLetterY[b] < LetterP[b, 0])
                            {
                                APVelo[1, b] = (LetterP[b, 0] - TempLetterY[b]) / 15;
                            }
                        }
                    }
                }
                 */
            }
            for(int a=0;a<=5;a++)
            {
                for(int b=0;b<=19;b++)
                {
                    if (NonStaticXDotCoordArray[a, b] + XMovement[a, b] < XDotCordDestination[a, b])
                    {
                        NonStaticXDotCoordArray[a, b] = NonStaticXDotCoordArray[a, b] + XMovement[a, b];
                    }
                    else
                    {
                        if (NonStaticXDotCoordArray[a, b] - XMovement[a, b] > XDotCordDestination[a, b])
                        {
                            NonStaticXDotCoordArray[a, b] = NonStaticXDotCoordArray[a, b] - XMovement[a, b];
                        }
                        else
                            NonStaticXDotCoordArray[a, b] = XDotCordDestination[a, b];
                    }
                    if (NonStaticYDotCoordArray[a, b] + YMovement[a, b] < YDotCordDestination[a, b])
                    {
                        NonStaticYDotCoordArray[a, b] = NonStaticYDotCoordArray[a, b] + YMovement[a, b];
                    }
                    else
                    {
                        if (NonStaticYDotCoordArray[a, b] - YMovement[a, b] > YDotCordDestination[a, b])
                        {
                            NonStaticYDotCoordArray[a, b] = NonStaticYDotCoordArray[a, b] - YMovement[a, b];
                        }
                        else
                            NonStaticYDotCoordArray[a, b] = YDotCordDestination[a, b];
                    }
                }
            }
            /*
            if (LastWasAm != AM)
            {
                if (DateTime.Now.ToShortTimeString().Contains("AM"))
                {
                    for (int b = 0; b <= 19; b++)
                    {
                        if (TempLetterX[b] + APVelo[0, b] > LetterA[b, 0])
                        {
                            TempLetterX[b] += APVelo[0, b];
                        }
                        else
                        {
                            if (TempLetterX[b] - APVelo[0, b] < LetterA[b, 0])
                            {
                                TempLetterX[b] = TempLetterX[b] - APVelo[0, b];
                            }
                            else
                            {
                                TempLetterX[b] = LetterA[b, 0];
                                APVelo[0, b] = 0;
                            }
                        }
                        if (TempLetterY[b] + APVelo[1, b] > LetterA[b, 1])
                        {
                            TempLetterY[b] = TempLetterY[b]+APVelo[1, b];
                        }
                        else
                        {
                            if (TempLetterY[b] - APVelo[1, b] < LetterA[b, 1])
                            {
                                TempLetterY[b] = TempLetterY[b] - APVelo[1, b];
                            }
                            else
                            {
                                TempLetterY[b] = LetterA[b, 1];
                                APVelo[1, b] = 0;
                            }
                    }
                }
                else 
                {
                    for (int b = 0; b <= 19; b++)
                    {
                        if (TempLetterY[b] + APVelo[1, b] > LetterP[b, 0])
                        {
                            TempLetterY[b] += APVelo[1, b];
                        }
                        else
                        {
                            if (TempLetterY[b] - APVelo[1, b] < LetterP[b, 0])
                            {
                                TempLetterY[b] -= APVelo[1, b];
                            }
                            else
                                TempLetterY[b] = LetterP[b, 0];
                        }
                    }
                }
            }
                        
             */
        }
        void dun()
        {
            str = DateTime.Now.ToString();
            index = str.IndexOf(":");
            // Hours
            seperate(0, int.Parse(str.Substring(index - 2, 2)));
            // Min
            seperate(2, int.Parse(str.Substring(index + 1, 2)));
            // Seconds
            seperate(4, int.Parse(str.Substring(index + 4, 2)));
            for(int b=0;b<=19;b++)
            {
                NonStaticXDotCoordArray[0,b] = num1[number[0],b,0,0];
                NonStaticXDotCoordArray[1,b] = num1[number[1],b,0,0]+50;
                NonStaticXDotCoordArray[2,b] = num1[number[2],b,0,0]+125;
                NonStaticXDotCoordArray[3,b] = num1[number[3],b,0,0]+175;
                NonStaticXDotCoordArray[4,b] = num1[number[4],b,0,0]+250;
                NonStaticXDotCoordArray[5,b] = num1[number[5],b,0,0]+300;
                NonStaticYDotCoordArray[0,b] = num1[number[0],b,1,0];
                NonStaticYDotCoordArray[1,b] = num1[number[1],b,1,0];
                NonStaticYDotCoordArray[2,b] = num1[number[2],b,1,0];
                NonStaticYDotCoordArray[3,b] = num1[number[3],b,1,0];
                NonStaticYDotCoordArray[4,b] = num1[number[4],b,1,0];
                NonStaticYDotCoordArray[5,b] = num1[number[5],b,1,0];
                if (DateTime.Now.ToShortTimeString().Contains("AM"))
                {
                    TempLetterX[b] = LetterA[b,0];
                    TempLetterY[b] = LetterA[b,1];
                    LastWasAm = true;
                }
                else
                {
                    TempLetterX[b] = LetterP[b,0];
                    TempLetterY[b] = LetterP[b,1];
                }
            }
            while(disp!=null)
            {
                frew();
                GC.Collect();
                this.Invalidate();
                str = DateTime.Now.ToString();
                index = str.IndexOf(":");
                // Hours
                seperate(0, int.Parse(str.Substring(index - 2, 2)));
                // Min
                seperate(2, int.Parse(str.Substring(index + 1, 2)));
                // Seconds
                seperate(4, int.Parse(str.Substring(index + 4, 2)));
                Thread.Sleep(33);
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
                    g2.FillEllipse(Brushes.Red, System.Convert.ToInt32(NonStaticXDotCoordArray[a, b]), System.Convert.ToInt32(NonStaticYDotCoordArray[a, b]), 10, 10);
                    //g2.FillEllipse(Brushes.Red, LetterM[b, 1] + 50, LetterM[b, 0], 10, 10);
                    //g2.FillEllipse(Brushes.Red, TempLetterY[b], TempLetterX[b], 10, 10);
                }
            }
            if (IsEven(number[5]))
            {
                g2.FillEllipse(Brushes.Red, 112, 50, 10, 10);
                g2.FillEllipse(Brushes.Red, 112, 25, 10, 10);
                g2.FillEllipse(Brushes.Red, 237, 25, 10, 10);
                g2.FillEllipse(Brushes.Red, 237, 50, 10, 10);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawing = new Bitmap(this.Width, this.Height, e.Graphics);
            graph = Graphics.FromImage(drawing);
            graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            // Draw the Background
            graph.FillRectangle(Brushes.Black, new Rectangle(new Point(0, 0),
                this.ClientSize));
            paint(graph);
            e.Graphics.DrawImageUnscaled(drawing, 0, 0);
            //g.Dispose();
        }
        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            //this.Opacity = 1d;
        }
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            //this.Opacity = .6d;
        }
        public void seperate(int dig, int a)
        {
            if (a >= 0 && a < 10)
            {
                number[dig] = 0;
                number[dig + 1] = a;
            }
            if (a == 10)
            {
                number[dig] = 1;
                number[dig + 1] = 0;
            }
            if (a > 10 && a < 20)
            {
                number[dig] = 1;
                number[dig + 1] = a - 10;
            }
            if (a == 20)
            {
                number[dig] = 2;
                number[dig + 1] = 0;
            }
            if (a > 20 && a < 30)
            {
                number[dig] = 2;
                number[dig + 1] = a - 20;
            }
            if (a == 30)
            {
                number[dig] = 3;
                number[dig + 1] = 0;
            }
            if (a > 30 && a < 40)
            {
                number[dig] = 3;
                number[dig + 1] = a - 30;
            }
            if (a == 40)
            {
                number[dig] = 4;
                number[dig + 1] = 0;
            }
            if (a > 40 && a < 50)
            {
                number[dig] = 4;
                number[dig + 1] = a - 40;
            }
            if (a == 50)
            {
                number[dig] = 5;
                number[dig + 1] = 0;
            }
            if (a > 50 && a < 60)
            {
                number[dig] = 5;
                number[dig + 1] = a - 50;
            }
            if (a == 60)
            {
                number[dig] = 0;
                number[dig + 1] = 0;
            }
        }
        public static bool IsEven(int intValue)
        {
            return ((intValue & 1) == 0);
        }

        private void contextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(System.Windows.Forms.MouseButtons.Right))
            {
                contextMenuStrip1.Show(e.Location.X + this.Location.X, e.Location.Y + this.Location.Y);
            }
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
        private void run()
        {
            while(true)
            {
                string str = DateTime.Now.ToString();
                int index = str.IndexOf(":");
                // Hours
                seperate(0, int.Parse(str.Substring(index-2, 2)));
                // Min
                seperate(2, int.Parse(str.Substring(index+1, 2)));
                // Seconds
                seperate(4, int.Parse(str.Substring(index + 4, 2)));
                Thread.Sleep(1000);
            }
        }
    }
}