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
        
        public void setPieceType(pieceType newPieceType)
        {
            myPieceType = newPieceType;
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
                }
                else
                {
                    myPieceType = pieceType.WHITEPIECE;
                }
            }
        }


    }
}
