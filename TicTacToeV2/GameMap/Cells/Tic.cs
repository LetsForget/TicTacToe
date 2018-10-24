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
    public class Tic : ICellable
    {
        public State State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = State.Tic;
            }
        }
        State _state;
        public Tic()
        {
            State = State.Tic;
        }

        public void Paint(int i, int j, PictureBox pb, Map map)
        {
            int UpLeftX = Convert.ToInt32(((float)j / map.Width) * pb.Width);
            int UpLeftY = Convert.ToInt32(((float)i / map.Height) * pb.Height);
            Point UpperLeftCorner = new Point(UpLeftX, UpLeftY);

            int DownRightX = Convert.ToInt32(((float)(j + 1) / map.Width) * pb.Width);
            int DownRightY = Convert.ToInt32(((float)(i + 1) / map.Height) * pb.Height);
            Point DownRightCorner = new Point(DownRightX, DownRightY);

            Graphics g = pb.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Black, 1),
                            new Rectangle(UpperLeftCorner.X, UpperLeftCorner.Y,
                                          DownRightCorner.X - UpperLeftCorner.X - 5,
                                          DownRightCorner.Y - UpperLeftCorner.Y - 5));
            g.DrawEllipse(new Pen(Color.Red,2), new Rectangle(UpperLeftCorner.X + 2, UpperLeftCorner.Y + 2,
                                          DownRightCorner.X - UpperLeftCorner.X - 9,
                                          DownRightCorner.Y - UpperLeftCorner.Y - 9));
        }
    }
}
