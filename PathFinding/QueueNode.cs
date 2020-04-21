using System;
using System.Collections.Generic;

/// <summary>
/// Helper class that represents current investigated node userd in the QUEUE.
/// </summary>
public class QueueNode
{
    public int Row { get; set; }

    public int Column { get; set; }

    // Holds the path from the starting field to the current.
    public List<Tuple<int,int>> PathToSell;

    public QueueNode(int row, int col, List<Tuple<int, int>> pathToSell)
    {
        this.Row = row;
        this.Column = col;
        this.PathToSell = pathToSell;
    }
};