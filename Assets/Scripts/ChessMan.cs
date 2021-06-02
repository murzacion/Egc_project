using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessMan : MonoBehaviour
{
    public int CurrentX { set; get; }
    public int CurrentY { set; get; }
    public bool isWhite;

    public void SetPosition(int x,int y)
    {
        this.CurrentX = x;
        this.CurrentY = y;
    }

    public virtual bool[,] possibleMove() 
    {
        return new bool[8,8];
    }
}
