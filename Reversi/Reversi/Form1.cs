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
        public gameState currentGameState = new gameState();            // Track the game state.
        public bool CPUgame = false;                                    // Boolean to see if CPU is playing.

        private boardHandler myReversiBoard = new boardHandler();       // BoardHandler object to handle the board.
        private int whitePoints = 0;                                    // Integer to track the white color points.
        private int blackPoints = 0;                                    // Integer to track the black color points.

        public static PictureBox[,] boardImages = new PictureBox[8, 8]; // Array of PictureBoxes for the game board.

        public Form1()
        {
            InitializeComponent();

            currentGameState = gameState.RestingState;

            // Assign the boardImages to the appropriate PictureBox.
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

            myReversiBoard.initializeBoard();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        // A function for checking to see if the place on the board is already played.
        public bool spaceIsOccupied(int row, int col)
        {
            if (myReversiBoard.getPieceAtLocation(row, col).getPieceType() == pieceType.NOPIECE)
            {
                return false;
            }
            return true;
        }

        // A function to place a game piece on the board.
        public void placePiece(int row, int col)
        {
            if (spaceIsOccupied(row, col))
            {
                System.Windows.Forms.MessageBox.Show("Space is occupied, cannot place piece.");
                return;
            }

            if (currentGameState == gameState.P1WhiteTurn)
            {
                myReversiBoard.placePiece(row, col, pieceType.WHITEPIECE);
                currentGameState = gameState.P2BlackTurn;
                currentTurnPicture.Image = Properties.Resources.BlackPiece;
            }
            else if (currentGameState == gameState.P2BlackTurn)
            {
                myReversiBoard.placePiece(row, col, pieceType.BLACKPIECE);
                currentGameState = gameState.P1WhiteTurn;
                currentTurnPicture.Image = Properties.Resources.WhitePiece;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Tried to place piece with no active player.");
            }
        }

        // A function to start a new game when New 2 Player Game button is pressed.
        private void new2PGame_Click(object sender, EventArgs e)
        {
            // Loop through each row and column and place a blank piece on each PictureBox.
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    myReversiBoard.placePiece(row, col, pieceType.NOPIECE);
                }
            }

            // Track the score before the default pieces have been played.
            trackScore();

            // Place the default beginning pieces.
            myReversiBoard.placePiece(3, 3, pieceType.BLACKPIECE);
            myReversiBoard.placePiece(3, 4, pieceType.WHITEPIECE);
            myReversiBoard.placePiece(4, 3, pieceType.WHITEPIECE);
            myReversiBoard.placePiece(4, 4, pieceType.BLACKPIECE);
            currentGameState = gameState.P1WhiteTurn;
            currentTurnPicture.Image = Properties.Resources.WhitePiece;
        }

        // A function to place a piece on the board once the space has been clicked.
        private void boardSpaceClick(object sender, EventArgs e)
        {
            // Create a PictureBox variable to be used to retrieve the variable name of the PictureBox.
            PictureBox boardPiece = (PictureBox)sender;

            // Place the piece by parsing the first integer value and second integer value 
            // of the PictureBox's variable name. The pictureBox's variable name is 1 above
            // the index value of the boardImages array.
            // Since the PictureBox variable name convention is "Box#_#" we can retreive
            // the number at index 3 and 5 of the variable name. We must subtract one
            // in order to match the index of the array.
            placePiece(
                (int)Char.GetNumericValue(boardPiece.Name.ElementAt(3))-1,
                (int)Char.GetNumericValue(boardPiece.Name.ElementAt(5))-1);

            // Track the score after a piece has been placed.
            trackScore();
        }

        // A function to keep track of the score.
        private void trackScore()
        {
            // Clear the points to recount after a piece has been played.
            whitePoints = 0;
            blackPoints = 0;

            // Loop through the board to count each piece and increment the score of the matching color.
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (myReversiBoard.getPieceAtLocation(row, col).getPieceType() == pieceType.WHITEPIECE)
                    {
                        whitePoints++;
                    }
                    else if (myReversiBoard.getPieceAtLocation(row, col).getPieceType() == pieceType.BLACKPIECE)
                    {
                        blackPoints++;
                    }
                }
            }
            
            // Display the score in the labels.
            whiteScore.Text = whitePoints + "";
            blackScore.Text = blackPoints + "";
        }
    }
}
