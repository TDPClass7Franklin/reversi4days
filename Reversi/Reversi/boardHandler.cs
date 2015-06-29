using System;
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

        Form1 mainForm;

        //================================================================//

        public void initializeBoard()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    boardTable[row, col] = new reversiPiece();
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
            Form1.imageBoardPlacePiece(row, col, inPiece);
            updateBoardWithNewPiece(row, col);
        }

        //================================================================//

        private void updateBoard()
        {

        }

        private void updateBoardWithNewPiece(int row, int col)
        {

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

            while ((markRow >= 0 && markRow <= 7) && (markCol >= 0 && markCol <= 7))
            {
                markRow += dirRow;
                markCol += dirCol;

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
                    flipListOfPieces(piecesToFlip);
                    return;
                }

            }

        }


        private void flipListOfPieces(List<reversiPiece> piecesToFlip)
        {
            foreach (reversiPiece aPiece in piecesToFlip)
            {
                aPiece.switchType();
            }
        }

    
    }

}
