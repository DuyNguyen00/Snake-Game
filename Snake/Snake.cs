using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Snake : Form
    {
        /// <summary>
        /// calculateed size of a game square
        /// </summary>
        private int _squareWidth;

        /// <summary>
        /// width and height of the game in number of nodes/game squares
        /// </summary>
        private int _size;

        /// <summary>
        /// gives the UI access to informing the game when the user has changed directions
        /// </summary>
        private Game _game;

        /// <summary>
        /// used to give the snake color
        /// </summary>
        private SolidBrush _bodyBrush = new SolidBrush(Color.Blue);

        /// <summary>
        /// used to give the food color
        /// </summary>
        private SolidBrush _foodBrush = new SolidBrush(Color.Red);

        /// <summary>
        /// gives each snake square an outline
        /// </summary>
        private Pen _pen = new Pen(Color.Black, 2);

        public Snake()
        {
            InitializeComponent();
            NewGame();
        }

        /// <summary>
        /// creates a new game of a default size, and binds all the score and food together.
        /// </summary>
        private void NewGame()
        {
            _size = 25;
            _game = new Game(_size);
            uxPictureBox.Height = 600;
            uxPictureBox.Width = 600;
            uxMenuStrip.Width = 600;

            this.Width = 617;
            this.Height = 663;

            _squareWidth = uxPictureBox.Width / _size;

            Binding bind = new Binding("Text", _game, "Score");
            uxScore.DataBindings.Clear();
            uxScore.DataBindings.Add(bind);

            Progress<SnakeStatus> progress = new Progress<SnakeStatus>();
            progress.ProgressChanged += (s, e) =>
            {
                Refresh();
                if (e == SnakeStatus.Collision)
                {
                    MessageBox.Show("Game over!");
                }
            };

            _game.StartMoving(progress);
        }

        /// <summary>
        /// event handler that will draw all of the game graphics.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPictureBox_Paint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            var snakePath = _game.GetSnakePath();

            foreach (var node in snakePath)
            {
                var rec = new Rectangle(node.X * _squareWidth, node.Y * _squareWidth, _squareWidth, _squareWidth);

                graphics.FillRectangle(_bodyBrush, rec);
            }
            var food = _game.GetFood();
            var cir = new Rectangle(food.X * _squareWidth, food.Y * _squareWidth, _squareWidth, _squareWidth);

            graphics.FillEllipse(_foodBrush, cir);
        }

        /// <summary>
        /// KeyDown event handler to control the UI designer window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserInterface_KeyDown(object sender, KeyEventArgs e)
        {
            if (_game.Play == true)
            {
                if (e.KeyCode == Keys.Down)
                {
                    _game.MoveDown();
                }
                else if (e.KeyCode == Keys.Up)
                {
                    _game.MoveUp();
                }
                else if (e.KeyCode == Keys.Left)
                {
                    _game.MoveLeft();
                }
                else
                {
                    _game.MoveRight();
                }

                uxPictureBox.Refresh();
            }


        }

        /// <summary>
        /// click event handler for the menu strip item for creating a new game.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNewGameMenuStrip_Click(object sender, EventArgs e)
        {
            NewGame();
        }
    }
}
