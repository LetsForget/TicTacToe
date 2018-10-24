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
        private Map map = new Map(6, 6);
        private Tic first = new Tic();
        private Tac second = new Tac();
        private GameSession Gs = new GameSession();
        public Form1()
        {
            InitializeComponent();
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            p = new Painter(g, pictureBox1);
            Gs.DepthOfCalculating = 6;
            Gs.LentgthToWin = 3;
            Gs.AddPlayer(new Human(first,Gs));
            Gs.AddPlayer(new Computer(second, Gs));
            p.PaintMap(Gs.Map);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int b = 43;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Point target = PointToClient(MousePosition);

            float wid = pictureBox1.Width;
            float hei = pictureBox1.Height;
            float mapW = Gs.Map.Width;
            float mapH = Gs.Map.Height;
            float X = target.Y;
            float Y = target.X;

            for (int i = 0; i < mapH; i++)
                for (int j = 0; j < mapW; j++)
                    if ( ((i + 1) / mapH) * hei > X && ((j + 1) / mapW) * wid > Y)
                    {
                        Gs.NotifyPlayers(i * Gs.Map.Width + j);
                        p.PaintMap(Gs.Map);
                        return;
                    }
        }

    }
}
