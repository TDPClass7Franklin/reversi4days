using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reversi
{

    public partial class Form1 : Form
    {
        /* Game States:
         * 0    resting state, game was just loaded and there are no active games.
         * 1    player 1 turn.
         * 2    player 2 turn.
         * 3    CPU turn.
         * 4    Game ended.
         */
        public uint gameState = 0;

        /* Game Modes:
         * 0    resting state
         * 1    2 player mode
         * 2    1 player mode
         */ 
        public uint gameMode = 0;

        private boardHandler myReversiBoard = new boardHandler();

        public static  PictureBox[,] boardImages = new PictureBox[8, 8];

        public Form1()
        {
            InitializeComponent();

            myReversiBoard.initializeBoard();

            boardImages[0, 0] = Box1_1;
            boardImages[0, 1] = Box1_2;
            boardImages[0, 2] = Box1_3;
            boardImages[0, 3] = Box1_4;
            boardImages[0, 4] = Box1_5;
            boardImages[0, 5] = Box1_6;
            boardImages[0, 6] = Box1_7;
            boardImages[0, 7] = Box1_8;

            boardImages[1, 0] = Box2_1;
            boardImages[1, 1] = Box2_2;
            boardImages[1, 2] = Box2_3;
            boardImages[1, 3] = Box2_4;
            boardImages[1, 4] = Box2_5;
            boardImages[1, 5] = Box2_6;
            boardImages[1, 6] = Box2_7;
            boardImages[1, 7] = Box2_8;

            boardImages[2, 0] = Box3_1;
            boardImages[2, 1] = Box3_2;
            boardImages[2, 2] = Box3_3;
            boardImages[2, 3] = Box3_4;
            boardImages[2, 4] = Box3_5;
            boardImages[2, 5] = Box3_6;
            boardImages[2, 6] = Box3_7;
            boardImages[2, 7] = Box3_8;

            boardImages[3, 0] = Box4_1;
            boardImages[3, 1] = Box4_2;
            boardImages[3, 2] = Box4_3;
            boardImages[3, 3] = Box4_4;
            boardImages[3, 4] = Box4_5;
            boardImages[3, 5] = Box4_6;
            boardImages[3, 6] = Box4_7;
            boardImages[3, 7] = Box4_8;

            boardImages[4, 0] = Box5_1;
            boardImages[4, 1] = Box5_2;
            boardImages[4, 2] = Box5_3;
            boardImages[4, 3] = Box5_4;
            boardImages[4, 4] = Box5_5;
            boardImages[4, 5] = Box5_6;
            boardImages[4, 6] = Box5_7;
            boardImages[4, 7] = Box5_8;

            boardImages[5, 0] = Box6_1;
            boardImages[5, 1] = Box6_2;
            boardImages[5, 2] = Box6_3;
            boardImages[5, 3] = Box6_4;
            boardImages[5, 4] = Box6_5;
            boardImages[5, 5] = Box6_6;
            boardImages[5, 6] = Box6_7;
            boardImages[5, 7] = Box6_8;

            boardImages[6, 0] = Box7_1;
            boardImages[6, 1] = Box7_2;
            boardImages[6, 2] = Box7_3;
            boardImages[6, 3] = Box7_4;
            boardImages[6, 4] = Box7_5;
            boardImages[6, 5] = Box7_6;
            boardImages[6, 6] = Box7_7;
            boardImages[6, 7] = Box7_8;

            boardImages[7, 0] = Box8_1;
            boardImages[7, 1] = Box8_2;
            boardImages[7, 2] = Box8_3;
            boardImages[7, 3] = Box8_4;
            boardImages[7, 4] = Box8_5;
            boardImages[7, 5] = Box8_6;
            boardImages[7, 6] = Box8_7;
            boardImages[7, 7] = Box8_8;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void updateGame()
        {

        }

        public static void placePiece(int row, int col, pieceType inPiece)
        {
            if (inPiece == pieceType.NOPIECE)
            {
                boardImages[row, col].Image = null;
            }
            else if (inPiece == pieceType.BLACKPIECE)
            {
                boardImages[row, col].Image = Properties.Resources.BlackPiece;
            }
            else if (inPiece == pieceType.WHITEPIECE)
            {
                boardImages[row, col].Image = Properties.Resources.WhitePiece;
            }
        }

        private void new2PGame_Click(object sender, EventArgs e)
        {
            myReversiBoard.placePiece(3, 3, pieceType.BLACKPIECE);
            myReversiBoard.placePiece(3, 4, pieceType.BLACKPIECE);
            myReversiBoard.placePiece(4, 3, pieceType.BLACKPIECE);
            myReversiBoard.placePiece(4, 4, pieceType.BLACKPIECE);
        }

        private void boardSpaceClick(object sender, EventArgs e)
        {
            string s = "unknown button";
            if (sender == Box1_1)
            {
                s = "button1";
            }
            else if (sender == Box1_2)
            {
                s = "button2";
            }
            MessageBox.Show("You pressed: " + s);
        }


    }
}
