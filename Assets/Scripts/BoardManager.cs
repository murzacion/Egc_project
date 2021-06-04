using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance { get; set; }
    private bool [,] allowedMoves { get; set; }

    private const float Title_size = 1.0f;
    private const float Title_OFFSET = 0.5F;
    public ChessMan[,] ChessMans { set; get; }
    private ChessMan selectedChessMan;

    private int selectionX = -1;//nothing is selected
    private int selectionY = -1;
    private Material prevoiusMat;
    public Material selectedMat;

    public int[] EnPassantMove { set; get; }

    public List<GameObject> chessmanPrefabs;
    public List<GameObject> activechessman;

    private Quaternion orientation = Quaternion.Euler(0, 180, 0);

    public bool isWhiteTurn = true;
    private void Update()
    {
        DrawCheesBoard();
        UpdateSelection();
        if (Input.GetMouseButtonDown(0)) 
        {
            if(selectionX>=0 && selectionY >= 0)
            {
                if (selectedChessMan == null)
                {
                    SelectChessMan(selectionX, selectionY);
                }
                else
                {
                    moveChessMan(selectionX, selectionY);
                }
            }
        }
    }

    private void SelectChessMan(int x,int y)
    {
        if (ChessMans[x, y] == null)
          return;
        if (ChessMans[x, y].isWhite != isWhiteTurn) 
          return;
        bool hasAtleastOneMove = false;
        allowedMoves = ChessMans[x,y].possibleMove();
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            { 
                if (allowedMoves[i, j])
                    hasAtleastOneMove = true;
            }
        }
        if (!hasAtleastOneMove)
            return;
        selectedChessMan = ChessMans[x, y];
        prevoiusMat = selectedChessMan.GetComponent<MeshRenderer>().material;
        selectedMat.mainTexture = prevoiusMat.mainTexture;
        selectedChessMan.GetComponent<MeshRenderer>().material = selectedMat;
        BoardHighLights.Instance.highlightAllowedMoves(allowedMoves);
    }
     
    private void moveChessMan(int x,int y) 
    {
        if (allowedMoves[x,y]) 
        {
            ChessMan c = ChessMans[x, y];
            if (c != null && c.isWhite!=isWhiteTurn) 
            {
                //Capture a piece

                //If it is the king

                if (c.GetType() == typeof(King))
                {
                    //End the game
                    EndGame();
                   return;
                }
                activechessman.Remove(c.gameObject);
                Destroy(c.gameObject);
            }
            EnPassantMove[0] = -1;
            EnPassantMove[1] = -1;
            if (x == EnPassantMove[0] && y == EnPassantMove[1])
            {
                if(y == 6)
                {
                    c = ChessMans[x, y - 1];
                    activechessman.Remove(c.gameObject);
                    Destroy(c.gameObject);
                } 
                else
                {
                    c = ChessMans[x, y + 1];
                    activechessman.Remove(c.gameObject);
                    Destroy(c.gameObject);
                }
            }
            if (selectedChessMan.GetType() == typeof(Pawn))
            {
                if (y == 7)
                {
                    activechessman.Remove(selectedChessMan.gameObject);
                    Destroy(selectedChessMan.gameObject);
                    SpawnChessman(1, x, y);

                }
                if (y == 0)
                {
                    activechessman.Remove(selectedChessMan.gameObject);
                    Destroy(selectedChessMan.gameObject);
                    SpawnChessman(7, x, y);

                }
                if (selectedChessMan.CurrentY == 1 && y == 3)
                {
                    EnPassantMove[0] = x;
                    EnPassantMove[1] = y - 1;
                } else if (selectedChessMan.CurrentY == 6 && y == 4)
                {
                    EnPassantMove[0] = x;
                    EnPassantMove[1] = y + 1;
                }
            }

            ChessMans[selectedChessMan.CurrentX, selectedChessMan.CurrentY] = null;
            selectedChessMan.transform.position = GetTileCenter(x, y);
            selectedChessMan.SetPosition(x, y);
            ChessMans[x, y] = selectedChessMan;
            isWhiteTurn = !isWhiteTurn;
        }
        selectedChessMan.GetComponent<MeshRenderer>().material = prevoiusMat; 
        BoardHighLights.Instance.HideHighlights();
        selectedChessMan = null;
    }
    private void Start()
    {
        Instance = this;
        SpawnAllChesman();
    }
    private Vector3 GetTileCenter(int x,int y)
    {
        Vector3 origin=Vector3.zero;
        origin.x = (Title_size * x) + Title_OFFSET;
        origin.z = (Title_size * y) + Title_OFFSET;
        return origin;
    }
    private void SpawnChessman(int index,int x,int y) 
    {
        GameObject go = Instantiate(chessmanPrefabs[index], GetTileCenter(x,y), orientation) as GameObject;
        go.transform.SetParent(transform);
        ChessMans[x, y] = go.GetComponent<ChessMan>();
        ChessMans[x, y].SetPosition(x, y);
        activechessman.Add(go);
    }
    private void SpawnAllChesman()
    {
        activechessman = new List<GameObject>();
        ChessMans = new ChessMan[8, 8];
        EnPassantMove = new int[2]{-1, -1};

        //spawn the white chess
        //king
        SpawnChessman(0, 3, 0);

        //queen
        SpawnChessman(1, 4, 0);

        //Rooks
        SpawnChessman(2, 0, 0);
        SpawnChessman(2, 7, 0);

        //Bishops
        SpawnChessman(3,2, 0);
        SpawnChessman(3, 5, 0);

        //Knights
        SpawnChessman(4, 1, 0);
        SpawnChessman(4, 6, 0);

        //Pawns
       for(int i = 0; i < 8; i++)
        {
            SpawnChessman(5, i, 1);
        }

        //spawn the black chess
        //king
        SpawnChessman(6, 4, 7);

        //queen
        SpawnChessman(7, 3, 7);

        //Rooks
        SpawnChessman(8, 0, 7);
        SpawnChessman(8, 7, 7);

        //Bishops
        SpawnChessman(9, 2, 7);
        SpawnChessman(9, 5, 7);

        //Knights
        SpawnChessman(10,1, 7);
        SpawnChessman(10, 6, 7);

        //Pawns
        for (int i = 0; i < 8; i++)
        {
            SpawnChessman(11, i, 6);
        }

    }
    private void UpdateSelection()
    {
        if (!Camera.main)
            return;
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit,25.0f,LayerMask.GetMask("ChessPlane")))
        {
            selectionX = (int)hit.point.x;
            selectionY = (int)hit.point.z;
        }
        else
        {
            selectionX = -1;
            selectionY = -1;
        }

    }
    private void DrawCheesBoard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heigthLine = Vector3.forward * 8;
        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <=8; j++)
            {
                Vector3 start1 = Vector3.right * j;
                Debug.DrawLine(start1, start1 + heigthLine);
            }
        }

        //Draw the selection
        if(selectionX>=0 && selectionY >= 0)
        {
            Debug.DrawLine(
                Vector3.forward*selectionY+Vector3.right*selectionX,
                Vector3.forward * (selectionY +1)+ Vector3.right * (selectionX+1));
            Debug.DrawLine(
              Vector3.forward * (selectionY + 1) + Vector3.right * selectionX,
              Vector3.forward * selectionY  + Vector3.right * (selectionX + 1));
        }
    }
    private void EndGame()
    {
        if (isWhiteTurn)
        {
           SceneManager.LoadScene(3);
        } else
        {
            SceneManager.LoadScene(4);
        }
        isWhiteTurn = true;
        foreach (GameObject go in activechessman)
            Destroy(go);
        isWhiteTurn = true;
        BoardHighLights.Instance.HideHighlights();

        SpawnAllChesman(); 
    }
}
