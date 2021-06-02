using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessMan
{
    public override bool[,] possibleMove(){
        bool[,]r=new bool[8, 8];
        ChessMan c;
        int i,j,m,n;
        i = CurrentX;
        //Right
        while (true) 
        {
            i++;
            if (i >= 8) 
            break;
            
            c = BoardManager.Instance.ChessMans[i, CurrentY];
            if (c == null)
                r[i, CurrentY] = true;
            else
            {
                if (c.isWhite != isWhite)
                    r[i, CurrentY]=true;
                break;
            }
        }
        //left
        j= CurrentX;
        while (true)
        {
            j--;
            if (j < 0)
            break;
            c = BoardManager.Instance.ChessMans[j, CurrentY];
            if (c == null)
                r[j, CurrentY] = true;
            else
            {
                if (c.isWhite != isWhite)
                    r[j, CurrentY] = true;
                break;
            }
        }

        //up
        m = CurrentY;
        while (true)
        {
            m++;
            if (m >= 8)
            {
                break;
            }
            c = BoardManager.Instance.ChessMans[CurrentX, m];
            if (c == null)
                r[CurrentX, m] = true;
            else
            {
                if (c.isWhite != isWhite)
                    r[CurrentX, m] = true;
                break;
            }
        }

        //down
        n = CurrentY;
        while (true)
        {
            n--;
            if (n < 0)
            {
                break;
            }
            c = BoardManager.Instance.ChessMans[CurrentX, n];
            if (c == null)
                r[CurrentX, n] = true;
            else
            {
                if (c.isWhite != isWhite)
                    r[CurrentX, n] = true;
                break;
            }
        }
        return r;
    }

}
