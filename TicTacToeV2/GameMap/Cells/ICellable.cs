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
    public delegate void PaintDelegate(int i, int j, Map map);
    public interface ICellable
    {
        State State { get; set; }
        void Paint(int i, int j, PictureBox pb, Map map);
        
    }
}
