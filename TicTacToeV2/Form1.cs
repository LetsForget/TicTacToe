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
            
            Computer Comp = new Computer(map, first, second);
            Computer Comp2 = new Computer(map, second, first);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.PaintMap(map);

            Computer Comp = new Computer(map, first, second);
            Comp.MakeAMove(3, 2);
            map = Comp.Map;
            p.PaintMap(map);

            Computer Comp2 = new Computer(map, second, first);
            Comp2.MakeAMove(3, 2);
            map = Comp2.Map;
            p.PaintMap(map);
        }
    }
}
