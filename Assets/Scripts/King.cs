using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : ChessMan
{
    public override bool[,] possibleMove()
    {
        bool[,] r = new bool[8, 8];
        ChessMan c;
        int i, j,m,n;
        i = CurrentX-1;
        j = CurrentY+1;
        //TopSide

        if (CurrentY != 7)
        {
            for (int k = 0; k < 3; k++)
            {
                if (i >= 0 || i < 8)
                {

                    c = BoardManager.Instance.ChessMans[i, j];
                    if (c == null)
                        r[i, j] = true;
                    else if (isWhite != c.isWhite)
                        r[i, j] = true;
                    break;

                }
                i++;
            }
        }
        //DownSide
        m = CurrentX - 1;
        n = CurrentY - 1;

        if (CurrentY != 0)
        {
            for (int k = 0; k < 3; k++)
            {
                if (m >= 0 || m < 8)
                {

                    c = BoardManager.Instance.ChessMans[m, n];
                    if (c == null)
                        r[m, n] = true;
                    else if (isWhite != c.isWhite)
                        r[m, n] = true;
                    break;

                }
                m++;
            }
        }

        //Middle Left
        if (CurrentX != 0)
        {
            c = BoardManager.Instance.ChessMans[CurrentX-1, CurrentY];
            if (c == null)
               r[CurrentX - 1, CurrentY]=true;
            else if (isWhite != c.isWhite)
                r[CurrentX - 1, CurrentY]=true;
        }
        //Middle Right
        if (CurrentX != 7)
        {
            c = BoardManager.Instance.ChessMans[CurrentX + 1, CurrentY];
            if (c == null)
                r[CurrentX + 1, CurrentY] = true;
            else if (isWhite != c.isWhite)
                r[CurrentX + 1, CurrentY] = true;
        }
        return r;
    }
}
