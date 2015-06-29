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

    public enum gameState
    {
        RestingState,
        P1WhiteTurn,
        P2BlackTurn,
        CPUBlackTurn,
        GameOver
    }

    public partial class Form1 : Form
    {
        public gameState currentGameState = new gameState();
        public bool CPUgame = false;

        private boardHandler myReversiBoard = new boardHandler();

        public static  PictureBox[,] boardImages = new PictureBox[8, 8];

        public Form1()
        {
            InitializeComponent();

            currentGameState = gameState.RestingState;

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

        public static void imageBoardPlacePiece(int row, int col, pieceType inPiece)
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

        public void placePiece(int row, int col)
        {
            if (currentGameState == gameState.P1WhiteTurn)
            {
                myReversiBoard.placePiece(row, col, pieceType.WHITEPIECE);
                //System.Windows.Forms.MessageBox.Show("Placed white piece.");
                currentGameState = gameState.P2BlackTurn;
            }
            else if (currentGameState == gameState.P2BlackTurn)
            {
                myReversiBoard.placePiece(row, col, pieceType.BLACKPIECE);
                //System.Windows.Forms.MessageBox.Show("Placed black piece.");
                currentGameState = gameState.P1WhiteTurn;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Tried to place piece with no active player.");
            }
        }

        private void new2PGame_Click(object sender, EventArgs e)
        {
            myReversiBoard.placePiece(3, 3, pieceType.BLACKPIECE);
            myReversiBoard.placePiece(3, 4, pieceType.WHITEPIECE);
            myReversiBoard.placePiece(4, 3, pieceType.WHITEPIECE);
            myReversiBoard.placePiece(4, 4, pieceType.BLACKPIECE);
            currentGameState = gameState.P1WhiteTurn;
        }

        private void boardSpaceClick(object sender, EventArgs e)
        {
            //string s = "unknown button";
            if (sender == Box1_1)
            {
                placePiece(0, 0);
            }
            else if (sender == Box1_2)
            {
                placePiece(0, 1);
            }
            else if (sender == Box1_3)
            {
                placePiece(0, 2);
            }
            else if (sender == Box1_4)
            {
                placePiece(0, 3);
            }
            else if (sender == Box1_5)
            {
                placePiece(0, 4);
            }
            else if (sender == Box1_6)
            {
                placePiece(0, 5);
            }
            else if (sender == Box1_7)
            {
                placePiece(0, 6);
            }
            else if (sender == Box1_8)
            {
                placePiece(0, 7);
            }
            //---------------------------------------
            else if (sender == Box2_1)
            {
                placePiece(1, 2);
            }
            else if (sender == Box2_2)
            {
                placePiece(1, 1);
            }
            else if (sender == Box2_3)
            {
                placePiece(1, 2);
            }
            else if (sender == Box2_4)
            {
                placePiece(1, 3);
            }
            else if (sender == Box2_5)
            {
                placePiece(1, 4);
            }
            else if (sender == Box2_6)
            {
                placePiece(1, 5);
            }
            else if (sender == Box2_7)
            {
                placePiece(1, 6);
            }
            else if (sender == Box2_8)
            {
                placePiece(1, 7);
            }
            //---------------------------------------
            else if (sender == Box3_1)
            {
                placePiece(2, 2);
            }
            else if (sender == Box3_2)
            {
                placePiece(2, 1);
            }
            else if (sender == Box3_3)
            {
                placePiece(2, 2);
            }
            else if (sender == Box3_4)
            {
                placePiece(2, 3);
            }
            else if (sender == Box3_5)
            {
                placePiece(2, 4);
            }
            else if (sender == Box3_6)
            {
                placePiece(2, 5);
            }
            else if (sender == Box3_7)
            {
                placePiece(2, 6);
            }
            else if (sender == Box3_8)
            {
                placePiece(2, 7);
            }//---------------------------------------
            else if (sender == Box4_1)
            {
                placePiece(3, 2);
            }
            else if (sender == Box4_2)
            {
                placePiece(3, 1);
            }
            else if (sender == Box4_3)
            {
                placePiece(3, 2);
            }
            else if (sender == Box4_4)
            {
                placePiece(3, 3);
            }
            else if (sender == Box4_5)
            {
                placePiece(3, 4);
            }
            else if (sender == Box4_6)
            {
                placePiece(3, 5);
            }
            else if (sender == Box4_7)
            {
                placePiece(3, 6);
            }
            else if (sender == Box4_8)
            {
                placePiece(3, 7);
            }//---------------------------------------
            else if (sender == Box5_1)
            {
                placePiece(4, 2);
            }
            else if (sender == Box5_2)
            {
                placePiece(4, 1);
            }
            else if (sender == Box5_3)
            {
                placePiece(4, 2);
            }
            else if (sender == Box5_4)
            {
                placePiece(4, 3);
            }
            else if (sender == Box5_5)
            {
                placePiece(4, 4);
            }
            else if (sender == Box5_6)
            {
                placePiece(4, 5);
            }
            else if (sender == Box5_7)
            {
                placePiece(4, 6);
            }
            else if (sender == Box5_8)
            {
                placePiece(4, 7);
            }//---------------------------------------
            else if (sender == Box6_1)
            {
                placePiece(5, 2);
            }
            else if (sender == Box6_2)
            {
                placePiece(5, 1);
            }
            else if (sender == Box6_3)
            {
                placePiece(5, 2);
            }
            else if (sender == Box6_4)
            {
                placePiece(5, 3);
            }
            else if (sender == Box6_5)
            {
                placePiece(5, 4);
            }
            else if (sender == Box6_6)
            {
                placePiece(5, 5);
            }
            else if (sender == Box6_7)
            {
                placePiece(5, 6);
            }
            else if (sender == Box6_8)
            {
                placePiece(5, 7);
            }//---------------------------------------
            else if (sender == Box7_1)
            {
                placePiece(6, 2);
            }
            else if (sender == Box7_2)
            {
                placePiece(6, 1);
            }
            else if (sender == Box7_3)
            {
                placePiece(6, 2);
            }
            else if (sender == Box7_4)
            {
                placePiece(6, 3);
            }
            else if (sender == Box7_5)
            {
                placePiece(6, 4);
            }
            else if (sender == Box7_6)
            {
                placePiece(6, 5);
            }
            else if (sender == Box7_7)
            {
                placePiece(6, 6);
            }
            else if (sender == Box7_8)
            {
                placePiece(6, 7);
            }//---------------------------------------
            else if (sender == Box8_1)
            {
                placePiece(7, 2);
            }
            else if (sender == Box8_2)
            {
                placePiece(7, 1);
            }
            else if (sender == Box8_3)
            {
                placePiece(7, 2);
            }
            else if (sender == Box8_4)
            {
                placePiece(7, 3);
            }
            else if (sender == Box8_5)
            {
                placePiece(7, 4);
            }
            else if (sender == Box8_6)
            {
                placePiece(7, 5);
            }
            else if (sender == Box8_7)
            {
                placePiece(7, 6);
            }
            else if (sender == Box8_8)
            {
                placePiece(7, 7);
            }

            //MessageBox.Show("You pressed: " + s);
        }

    }
}
