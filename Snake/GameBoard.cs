using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public class GameBoard
    {
        /// <summary>
        /// return the game node that contains the food.
        /// </summary>
        public GameNode Food { get; set; }

        /// <summary>
        /// the adjacency matrix for storing the graph of the game board.
        /// </summary>
        public GameNode[,] Grid { get; private set; }

        /// <summary>
        /// a reference to where the head of the snake is currently at.
        /// </summary>
        public GameNode Head { get; set; }

        /// <summary>
        /// a reference to where the tail of the snake is currently at.
        /// </summary>
        public GameNode Tail { get; set; }

        /// <summary>
        /// constructor that initializes the game board to a new board of the given size.
        /// </summary>
        /// <param name="size"></param>
        public GameBoard(int size)
        {
            Grid = new GameNode[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    GameNode node = new GameNode(j, i);
                    Grid[i, j] = node;
                }
            }

            Grid[size / 2, size / 2].Data = GridData.SnakeHead;
            Head = Grid[size / 2, size / 2];
            Tail = Head;

            AddFood();
        }

        /// <summary>
        /// function that randomly places the snake food on the board.
        /// </summary>
        public void AddFood()
        {
            GameNode foodLoc;
            do
            {
                foodLoc = Grid[new Random().Next(25), new Random().Next(25)];
            } while (foodLoc.Data != GridData.Empty);

            foodLoc.Data = GridData.SnakeFood;
            Food = foodLoc;
        }

        /// <summary>
        /// helper method that will return the node that the snake would be going to
        /// if it was headed in the given direction.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public GameNode GetNextNode(GameNode node, Direction dir)
        {
            if (dir == Direction.Up)
            {
                if (node.Y - 1 < 0)
                    return null;
                return Grid[node.Y - 1, node.X];
            }
            else if (dir == Direction.Down)
            {
                if (node.Y + 1 > 25 - 1)
                    return null;
                return Grid[node.Y + 1, node.X];
            }
            else if (dir == Direction.Left)
            {
                if (node.X - 1 < 0)
                    return null;
                return Grid[node.Y, node.X - 1];
            }
            else
            {
                if (node.X + 1 > 25 - 1)
                    return null;
                return Grid[node.Y, node.X + 1];
            }
        }

        /// <summary>
        /// helper method for the GetNextNode above
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public GameNode GetNextNode(Direction dir)
        {
            return GetNextNode(Head, dir);
        }

        /// <summary>
        /// main logic on how the snake moves through the game board.
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        public SnakeStatus MoveSnake(Direction dir)
        {
            var nextNode = GetNextNode(dir);

            if (nextNode == null)
                return SnakeStatus.Collision;
            if (nextNode.Data == GridData.SnakeBody)
            {
                if (nextNode.Edge == Head)
                    return SnakeStatus.InvalidDirection;
                return SnakeStatus.Collision;
            }
            nextNode.Edge = null;
            Head.Data = GridData.SnakeBody;
            Head.Edge = nextNode;

            if (nextNode.Data == GridData.SnakeFood)
            {
                nextNode.Data = GridData.SnakeHead;
                AddFood();
                Head = nextNode;
                return SnakeStatus.Eating;
            }

            nextNode.Data = GridData.SnakeHead;
            Head = nextNode;
            Tail.Data = GridData.Empty;
            Tail = Tail.Edge;

            return SnakeStatus.Moving;
        }

        /// <summary>
        /// method returns a list of game nodes that contain the snake starting from the tail
        /// </summary>
        /// <returns></returns>
        public List<GameNode> GetSnakePath()
        {
            var currNode = Tail;
            var nodeList = new List<GameNode>();

            while (currNode != null)
            {
                nodeList.Add(currNode);
                currNode = currNode.Edge;
            }

            return nodeList;
        }


    }
}
