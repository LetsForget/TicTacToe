using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeV2.GameMap;
using TicTacToeV2.Players;
namespace TicTacToeV2
{
    public partial class Form1 : Form
    {
        static public Graphics g;
        private Painter p;
        private Map map = new Map(3, 3);
        private Tic first = new Tic();
        private Tac second = new Tac();
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            p = new Painter(g, pictureBox1);
            p.PaintMap(map);
 
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.PaintMap(map);

            Computer Comp = new Computer(map, first, second);
            Comp.MakeAMove(3, 2);
            map = Comp.Map;
            p.PaintMap(map);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Point target = PointToClient(MousePosition);

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            for (int i = 0; i < map.Height; i++)
                for (int j = 0; j < map.Width; j++)
                    if (((float)(i + 1) / map.Height) * height > target.X && ((float)(j + 1) / map.Width) * width > target.Y)
                    {
                        map.Cells[i * map.Width + j] = new Tac();
                        p.PaintMap(map);
                        return;
                    }
        }
    }
}
