using System;
using System.Collections.Generic;

public class QueueNode
{
    // The cordinates of a cell 
    public int Row { get; set; }

    public int Column { get; set; }

    // cell's distance of from the source 
    public List<Tuple<int,int>> PathToSell;

    public QueueNode(int row, int col, List<Tuple<int, int>> pathToSell)
    {
        this.Row = row;
        this.Column = col;
        this.PathToSell = pathToSell;
    }
};