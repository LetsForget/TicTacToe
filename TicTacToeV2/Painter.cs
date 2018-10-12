using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeV2.GameMap;
using TicTacToeV2.GameMap.Cells;
namespace TicTacToeV2
{
    public class Painter
    {
        public Graphics G;
        public PictureBox Pb;
        public Pen NetPen = new Pen(Color.Black, 4);

        public Painter(Graphics g, PictureBox pb)
        {
            G = g;
            Pb = pb;
        }
        public void PaintMap(Map map)
        {
            int width = map.Width;
            int height = map.Height;

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    map.Cells[i * width + j].Paint(i, j, Pb, map);
        }
        public void PaintToe(int i, int j, PictureBox pb, Map map)
        {
            Point UpperLeftCorner = new Point(Convert.ToInt32(((float)i / map.Height) * pb.Height),
                                              Convert.ToInt32(((float)j / map.Width) * pb.Width));
            Point DownRightCorner = new Point(Convert.ToInt32(((float)(i + 1) / map.Height) * pb.Height),
                                              Convert.ToInt32(((float)(j + 1) / map.Width) * pb.Width));
            Graphics g = pb.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Black, 1),
                            new Rectangle(UpperLeftCorner.X, UpperLeftCorner.Y,
                                          DownRightCorner.X - UpperLeftCorner.X - 5,
                                          DownRightCorner.Y - UpperLeftCorner.Y - 5));
        }
    }
}
