using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace PathFinding
{
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
