using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessMan
{
    int i, j,m,n,l,k,a,d;
    public override bool[,] possibleMove()
    {
        bool[,] r = new bool[8, 8];
        ChessMan c;
        //topLeft
        i = CurrentX;
        j = CurrentY;
        while (true) 
        {
            i--;
            j++;
            if (i < 0 || j >= 8)
                break;
            c = BoardManager.Instance.ChessMans[i, j];
            if (c == null)
                r[i, j] = true;
            else
            {
                if (isWhite = !c.isWhite)
                    r[i, j] = true;
                break;
            }
        }

        //topRight
        m = CurrentX;
        n = CurrentY;
        while (true)
        {
            m++;
            n++;
            if (m >=8  || n >= 8)
                break;
            c = BoardManager.Instance.ChessMans[m, n];
            if (c == null)
                r[m, n] = true;
            else
            {
                if (isWhite = !c.isWhite)
                    r[m, n] = true;
                break;
            }
            
        }
        //DownLeft
        l = CurrentX;
        k = CurrentY;
        while (true)
        {
            l--;
            k--;
            if (l <0 || k < 0)
                break;
            c = BoardManager.Instance.ChessMans[l, k];
            if (c == null)
                r[l, k] = true;
            else
            {
                if (isWhite = !c.isWhite)
                    r[l, k] = true;
                break;
            }
        }

        //DownRight
        a = CurrentX;
        d = CurrentY;
        while (true)
        {
            a++;
            d--;
            if (a >=8 || d < 0)
                break;
            c = BoardManager.Instance.ChessMans[a, d];
            if (c == null)
                r[a, d] = true;
            else
            {
                if (isWhite = !c.isWhite)
                    r[a,d] = true;
                break;
            }
        }
        return r;
    }

}
