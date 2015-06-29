﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reversi
{

    public class boardHandler
    {
        /* Board location states
          *  boardTable[row, col]
        */
        public reversiPiece[,] boardTable = new reversiPiece[8, 8];

        public Form1 mainForm;

        // global score vars
        public int whiteScore { get; set; }
        public int blackScore { get; set; }

        //================================================================//

        public void initializeBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    boardTable[row, col] = new reversiPiece();
                    boardTable[row, col].myPictureBox = Form1.boardImages[row, col];
                }
            }
        }

        public reversiPiece getPieceAtLocation(int row, int col)
        {
            return boardTable[row, col];
        }

        public void placePiece(int row, int col, pieceType inPiece)
        {
            boardTable[row, col].setPieceType(inPiece);
            updateBoardWithNewPiece(row, col);
        }

        //================================================================//

        private void updateBoard()
        {

        }

        private void updateBoardWithNewPiece(int row, int col)
        {
            for (int dirRow = -1; dirRow < 2; dirRow++)
            {
                for (int dirCol = -1; dirCol < 2; dirCol++)
                {
                    checkInDirection(row, col, dirRow, dirCol);
                }
            }
        }

        private void checkInDirection(int startRow, int startCol, int dirRow, int dirCol)
        {
            if (dirRow == 0 && dirCol == 0)
            {
                return;
            }

            pieceType newPieceType = getPieceAtLocation(startRow, startCol).getPieceType();

            if (newPieceType == pieceType.NOPIECE)
            {
                return;
            }

            List<reversiPiece> piecesToFlip = new List<reversiPiece>();

            int markRow = startRow;
            int markCol = startCol;

            markRow += dirRow;
            markCol += dirCol;

            while ((markRow >= 0 && markRow <= 7) && (markCol >= 0 && markCol <= 7))
            {
                if (getPieceAtLocation(markRow, markCol).getPieceType() == pieceType.NOPIECE)
                {
                    return;
                }
                else if (getPieceAtLocation(markRow, markCol).getPieceType() != newPieceType)
                {
                    piecesToFlip.Add(getPieceAtLocation(markRow, markCol));
                }
                else if (getPieceAtLocation(markRow, markCol).getPieceType() == newPieceType)
                {
                    if (piecesToFlip.Count != 0)
                    {
                        System.Windows.Forms.MessageBox.Show("Found pieces to flip");
                        flipListOfPieces(piecesToFlip);
                    }
                    return;
                }

                markRow += dirRow;
                markCol += dirCol;

            }

        }


        private void flipListOfPieces(List<reversiPiece> piecesToFlip)
        {
            //System.Windows.Forms.MessageBox.Show("Starting to flip");
            foreach (reversiPiece aPiece in piecesToFlip)
            {
                //System.Windows.Forms.MessageBox.Show("Flip");
                aPiece.switchType();
                if (mainForm.currentGameState == gameState.P1WhiteTurn)
                {
                    this.whiteScore += 1;
                    this.blackScore -= 1;
                }
                else if (mainForm.currentGameState == gameState.P2BlackTurn)
                {
                    this.whiteScore -= 1;
                    this.blackScore += 1;
                }
            }
        }

    
    }

}
