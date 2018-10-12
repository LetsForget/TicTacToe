using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeV2.GameMap.Cells;

namespace TicTacToeV2.GameMap
{
    public class Tac : ICellable
    {
        public State State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = State.Tac;
            }
        }
        State _state;
        public Tac()
        {
            State = State.Tac;
        }
        public int Weight { get; set; }

        public void Paint(int i, int j, PictureBox pb, Map map)
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
            g.DrawLine(new Pen(Color.Blue, 2), UpperLeftCorner.X, UpperLeftCorner.Y, DownRightCorner.X - 5, DownRightCorner.Y - 5);
            g.DrawLine(new Pen(Color.Blue, 2), DownRightCorner.X - 5, UpperLeftCorner.Y, UpperLeftCorner.X, DownRightCorner.Y - 5);
        }
    }
}
