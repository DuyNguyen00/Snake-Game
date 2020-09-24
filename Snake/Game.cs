using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    /// <summary>
    /// enum for the direction the snake is allowed to move
    /// </summary>
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    /// <summary>
    /// enum for the different stages of the snake
    /// </summary>
    public enum SnakeStatus
    {
        Moving,
        InvalidDirection,
        Eating,
        Collision
    }
    public class Game : INotifyPropertyChanged
    {
        /// <summary>
        /// keeps track of how many points the player has.
        /// </summary>
        private int _score;

        /// <summary>
        /// Stores whether or not the game is currently being played
        /// </summary>
        public bool Play;

        /// <summary>
        /// public property that has a getter that returns the private score field
        /// </summary>
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnPropertyChanged("Score");
                }
            }
        }

        /// <summary>
        /// reference to the game board object that contains the logic
        /// for moving the snake on the graph.
        /// </summary>
        public GameBoard Grid { get; private set; }

        /// <summary>
        /// size of the game to create
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// last direction that the snake successfully moved
        /// </summary>
        public Direction LastDirection { get; set; }

        /// <summary>
        /// most recent direction reported by the UI
        /// </summary>
        public Direction KeyPress { get; private set; }

        /// <summary>
        /// current status of the snake
        /// </summary>
        public SnakeStatus Status { get; private set; }

        /// <summary>
        /// part of implementing the interface
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// constructor for the Game class. Sets the size, initilializes the game board
        /// score to 2, and play to true.
        /// </summary>
        /// <param name="size"></param>
        public Game(int size)
        {
            this.Size = size;

            this.Grid = new GameBoard(size);

            Score = 1;

            Play = true;
        }

        /// <summary>
        /// asynchronous method that acts as a game clock. The snake in the game is always moving
        /// while the user controls the direction.
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        public async Task StartMoving(IProgress<SnakeStatus> progress)
        {
            do
            {
                Status = Grid.MoveSnake(KeyPress);
                progress.Report(Status);

                if (Status == SnakeStatus.Collision)
                {
                    Play = false;
                }
                else if (Status == SnakeStatus.Moving)
                {
                    LastDirection = KeyPress;
                }
                else if (Status == SnakeStatus.Eating)
                {
                    Score++;
                }
                else
                {
                    Status = Grid.MoveSnake(LastDirection);
                    if (Status == SnakeStatus.Collision)
                    {
                        Play = false;
                    }
                    else if (Status == SnakeStatus.Eating)
                    {
                        Score++;
                    }
                }
                await Task.Delay(150);
            } while (Play != false);
        }

        /// <summary>
        /// property changed event with the appropriate property.
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// method returns the result of the GetSnakePath method
        /// </summary>
        /// <returns></returns>
        public List<GameNode> GetSnakePath()
        {
            return Grid.GetSnakePath();
        }

        /// <summary>
        /// returns the Food property of the game board
        /// </summary>
        /// <returns></returns>
        public GameNode GetFood()
        {
            return Grid.Food;
        }

        /// <summary>
        /// sets the key press field to be up
        /// </summary>
        public void MoveUp()
        {
            KeyPress = Direction.Up;
        }

        /// <summary>
        /// sets the key press field to be down
        /// </summary>
        public void MoveDown()
        {
            KeyPress = Direction.Down;
        }

        /// <summary>
        /// sets the key press field to be left
        /// </summary>
        public void MoveLeft()
        {
            KeyPress = Direction.Left;
        }

        /// <summary>
        /// sets the key press field to be right
        /// </summary>
        public void MoveRight()
        {
            KeyPress = Direction.Right;
        }
    }
}
