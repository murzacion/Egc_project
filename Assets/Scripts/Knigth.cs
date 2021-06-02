using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knigth : ChessMan
{
    public override bool[,] possibleMove()
    {
        bool[,] r = new bool[8, 8];

        //UpLeft
        KnigthMove(CurrentX - 1, CurrentY + 2, ref r);

        //UpRight
        KnigthMove(CurrentX + 1, CurrentY + 2, ref r);

        //RightUP
        KnigthMove(CurrentX + 2, CurrentY + 1, ref r);

        //RightDown
        KnigthMove(CurrentX + 2, CurrentY - 1, ref r);

        //downLeft
        KnigthMove(CurrentX - 1, CurrentY - 2, ref r);

        //downRight
        KnigthMove(CurrentX + 1, CurrentY - 2, ref r);

        //LeftUP
        KnigthMove(CurrentX - 2, CurrentY + 1, ref r);

        //LeftDown
        KnigthMove(CurrentX - 2, CurrentY - 1, ref r);



        return r;
    }

    public void KnigthMove(int x,int y,ref bool[,] r) 
    {
        ChessMan c;
        if(x>=0 && x<8  && y>=0 && y < 8)
        {
            c = BoardManager.Instance.ChessMans[x, y];
            if (c == null)
                r[x, y] = true;
            else
            {
                if (isWhite = !c.isWhite)
                    r[x, y] = true;
                
            }
        }
    }
}
