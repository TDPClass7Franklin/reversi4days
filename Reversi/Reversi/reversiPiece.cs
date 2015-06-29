using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reversi
{
    public enum pieceType
    {
        WHITEPIECE,
        NOPIECE,
        BLACKPIECE
    }

    public class reversiPiece
    {
        private pieceType myPieceType = pieceType.NOPIECE;

        public PictureBox myPictureBox;
        
        public void setPieceType(pieceType newPieceType)
        {
            myPieceType = newPieceType;

            if (myPieceType == pieceType.NOPIECE)
            {
                myPictureBox.Image = null;
            }
            else
            {
                if (myPieceType == pieceType.WHITEPIECE)
                {
                    myPictureBox.Image = Properties.Resources.WhitePiece;
                }
                else
                {
                    myPictureBox.Image = Properties.Resources.BlackPiece;
                }
            }
        }

        public pieceType getPieceType()
        {
            return myPieceType;
        }

        public void switchType()
        {
            if (myPieceType == pieceType.NOPIECE)
            {
                return;
            }
            else
            {
                if (myPieceType == pieceType.WHITEPIECE)
                {
                    myPieceType = pieceType.BLACKPIECE;
                    myPictureBox.Image = Properties.Resources.BlackPiece;
                    myPictureBox.Invalidate();
                    myPictureBox.Visible = true;
                }
                else
                {
                    myPieceType = pieceType.WHITEPIECE;
                    myPictureBox.Image = Properties.Resources.WhitePiece;
                    myPictureBox.Invalidate();
                    myPictureBox.Visible = true;
                }
            }
        }
    }
}
