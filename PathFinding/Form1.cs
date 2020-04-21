using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathFinding
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            Label.Text = "Please choose your starting point";
        }

        private PositionInTheLabyrinth startingField;

        private PositionInTheLabyrinth targetField;

        private List<PositionInTheLabyrinth> Walls = new List<PositionInTheLabyrinth>();

        private PositionInTheLabyrinth[,] buttons = new PositionInTheLabyrinth[30, 60];

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    PositionInTheLabyrinth button = new PositionInTheLabyrinth(i, j)
                    {
                        Location = new Point(j * 20, i * 20),
                        Size = new Size(20, 20),
                        BackColor = Color.White,
                };

                button.Click += HandleButtonClicked;

                this.buttons[i, j] = button;

                this.labyrinthPanel.Controls.Add(button);
            }
        }
    }


    private void HandleButtonClicked(object sender, EventArgs e)
    {
        switch (Label.Text)
        {
            case "Please choose your starting point":
                this.startingField = (PositionInTheLabyrinth)sender;
                this.startingField.BackColor = Color.Green;
                Label.Text = "Please choose your targetPoint";
                break;

            case "Please choose your targetPoint":
                this.targetField = (PositionInTheLabyrinth)sender;
                this.targetField.BackColor = Color.Red;
                Label.Text = "Select walls";
                break;

            case "Select walls":
                this.Walls.Add((PositionInTheLabyrinth)sender);
                ((PositionInTheLabyrinth)sender).BackColor = Color.Black;
                this.FindPathButton.Visible = true;
                break;
        }
    }

    private void labyrinthPanel_Paint(object sender, PaintEventArgs e)
    {

    }

    private void Label_Click(object sender, EventArgs e)
    {

    }

    private void FindPathButton_Click(object sender, EventArgs e)
    {
        List<Tuple<int, int>> path = this.BFS(this.startingField.Row, this.startingField.Column, this.targetField.Row, this.targetField.Column);

        foreach (var item in path)
        {
            this.buttons[item.Item1, item.Item2].BackColor = Color.Yellow;
        }
            MessageBox.Show("Path is found! See it and press OK to redraw the labyrinth.");

        GetInInitialSetup();
    }

    private void GetInInitialSetup()
    {
        this.targetField.BackColor = Color.Red;
        this.startingField.BackColor = Color.Green;

        for (int i = 0; i < 30; i++)
        {
            for (int j = 0; j < 60; j++)
            {
                this.buttons[i, j].HasBeenVisited = false;
                if (this.buttons[i, j].BackColor == Color.Yellow)
                {
                    this.buttons[i, j].BackColor = Color.White;
                }
            }
        }


    }

    private List<Tuple<int, int>> BFS(int sourceRow, int sourceCol, int destRow, int destCol)
    {
        if (buttons[sourceRow, sourceCol].BackColor == Color.Black ||
            buttons[destRow, destCol].BackColor == Color.Black)
            return null;

        this.buttons[sourceRow, sourceCol].HasBeenVisited = true;

        Queue<QueueNode> q = new Queue<QueueNode>();

        QueueNode s = new QueueNode(sourceRow, sourceCol, new List<Tuple<int, int>>());
        q.Enqueue(s);

        while (q.Count != 0)
        {
            QueueNode curr = q.Peek();

            if (curr.Row == destRow && curr.Column == destCol)
                return curr.PathToSell;

            q.Dequeue();

            List<Tuple<int, int>> newPath;

            int row = curr.Row - 1;
            int col = curr.Column;

            if (IsValid(row, col) &&
                    buttons[row, col].BackColor != Color.Black &&
               buttons[row, col].HasBeenVisited == false)
            {
                buttons[row, col].HasBeenVisited = true;
                newPath = new List<Tuple<int, int>>(curr.PathToSell);
                newPath.Add(new Tuple<int, int>(row, col));
                QueueNode Adjcell = new QueueNode(row, col, newPath);
                q.Enqueue(Adjcell);
            }

            row = curr.Row + 1;
            col = curr.Column;

            if (IsValid(row, col) &&
                    buttons[row, col].BackColor != Color.Black &&
               buttons[row, col].HasBeenVisited == false)
            {
                buttons[row, col].HasBeenVisited = true;
                newPath = new List<Tuple<int, int>>(curr.PathToSell);
                newPath.Add(new Tuple<int, int>(row, col));
                QueueNode Adjcell = new QueueNode(row, col, newPath);
                q.Enqueue(Adjcell);
            }

            row = curr.Row;
            col = curr.Column + 1;

            if (IsValid(row, col) &&
                    buttons[row, col].BackColor != Color.Black &&
               buttons[row, col].HasBeenVisited == false)
            {
                buttons[row, col].HasBeenVisited = true;
                newPath = new List<Tuple<int, int>>(curr.PathToSell);
                newPath.Add(new Tuple<int, int>(row, col));
                QueueNode Adjcell = new QueueNode(row, col, newPath);
                q.Enqueue(Adjcell);
            }

            row = curr.Row;
            col = curr.Column - 1;

            if (IsValid(row, col) &&
                    buttons[row, col].BackColor != Color.Black &&
               buttons[row, col].HasBeenVisited == false)
            {
                buttons[row, col].HasBeenVisited = true;
                newPath = new List<Tuple<int, int>>(curr.PathToSell);
                newPath.Add(new Tuple<int, int>(row, col));
                QueueNode Adjcell = new QueueNode(row, col, newPath);
                q.Enqueue(Adjcell);
            }

        }
        return null;
    }

    private bool IsValid(int row, int col)
    {
        return row >= 0 && row <= 29 && col >= 0 && col <= 59;
    }
}
}
