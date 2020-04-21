public class QueueNode
{
    // The cordinates of a cell 
    public int Row { get; set; }

    public int Column { get; set; }

    // cell's distance of from the source 
    public int Dist;

    public QueueNode(int row, int col, int dist)
    {
        this.Row = row;
        this.Column = col;
        this.Dist = dist;
    }
};