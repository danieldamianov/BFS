using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PathFinding
{
    /// <summary>
    /// Class that extends the button to have some additional properties related to the board.
    /// </summary>
    public class PositionInTheLabyrinth : Button
    {
        public PositionInTheLabyrinth(int row, int column) : base()
        {
            Row = row;
            Column = column;
            HasBeenVisited = false;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public bool HasBeenVisited { get; set; }
    }
}
