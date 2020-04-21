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
        /// <summary>
        /// Prepares the initial view.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            Label.Text = "Please choose your starting point";
        }

        /// <summary>
        /// Holds the starting field from which the pathfinding starts.
        /// </summary>
        private PositionInTheLabyrinth startingField;

        /// <summary>
        /// Holds the target field to which the pathfinding has to go.
        /// </summary>
        private PositionInTheLabyrinth targetField;

        /// <summary>
        /// Holds the positions of the walls through which the pathfinding can't get.
        /// </summary>
        private List<PositionInTheLabyrinth> Walls = new List<PositionInTheLabyrinth>();

        /// <summary>
        /// The labyrinth
        /// </summary>
        private PositionInTheLabyrinth[,] buttons = new PositionInTheLabyrinth[30, 60];

        /// <summary>
        /// Fills the labyrinth and shows it to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Sets starting , target or walls fields depeding on the label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    if (((PositionInTheLabyrinth)sender).BackColor == Color.White)
                    {
                        ((PositionInTheLabyrinth)sender).BackColor = Color.Black; 
                    }
                    else if(((PositionInTheLabyrinth)sender).BackColor == Color.Black)
                    {
                        ((PositionInTheLabyrinth)sender).BackColor = Color.White;
                    }

                    this.FindPathButton.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Finds the colsest path and displays it to the user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindPathButton_Click(object sender, EventArgs e)
        {
            List<Tuple<int, int>> path = this.FindPath(this.startingField.Row, this.startingField.Column, this.targetField.Row, this.targetField.Column);

            if (path != null)
            {
                foreach (var item in path.Take(path.Count - 1))
                {
                    this.buttons[item.Item1, item.Item2].BackColor = Color.Yellow;
                }
                MessageBox.Show("Path is found! See it and press OK to redraw the labyrinth."); 
            }
            else
            {
                MessageBox.Show("No path was found! Press OK to redraw the labyrinth.");
            }

            GetInInitialSetup();
        }

        /// <summary>
        /// Prepares the board for another pathfinding.
        /// </summary>
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

        /// <summary>
        /// Method which uses BFS to find the shortest path.
        /// </summary>
        /// <param name="sourceRow"></param>
        /// <param name="sourceCol"></param>
        /// <param name="destRow"></param>
        /// <param name="destCol"></param>
        /// <returns></returns>
        private List<Tuple<int, int>> FindPath(int sourceRow, int sourceCol, int destRow, int destCol)
        {
            if (buttons[sourceRow, sourceCol].BackColor == Color.Black ||
                buttons[destRow, destCol].BackColor == Color.Black)
                return null;

            this.buttons[sourceRow, sourceCol].HasBeenVisited = true;

            Queue<QueueNode> queue = new Queue<QueueNode>();

            QueueNode s = new QueueNode(sourceRow, sourceCol, new List<Tuple<int, int>>());
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                QueueNode curr = queue.Peek();

                if (curr.Row == destRow && curr.Column == destCol)
                    return curr.PathToSell;

                queue.Dequeue();

                List<Tuple<int, int>> newPath;

                int[] rowChange = { -1, 0, 0, 1 };
                int[] colChange = { 0, -1, 1, 0 };

                int row;
                int col;

                for (int i = 0; i < 4; i++)
                {
                    row = curr.Row + rowChange[i];
                    col = curr.Column + colChange[i];

                    if (IsValid(row, col) &&
                        buttons[row, col].BackColor != Color.Black &&
                   buttons[row, col].HasBeenVisited == false)
                    {
                        buttons[row, col].HasBeenVisited = true;
                        newPath = new List<Tuple<int, int>>(curr.PathToSell);
                        newPath.Add(new Tuple<int, int>(row, col));
                        QueueNode Adjcell = new QueueNode(row, col, newPath);
                        queue.Enqueue(Adjcell);
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Validates if the position is in the labyrinth.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsValid(int row, int col)
        {
            return row >= 0 && row <= 29 && col >= 0 && col <= 59;
        }
    }
}
