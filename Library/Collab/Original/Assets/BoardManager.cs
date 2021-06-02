using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private const float Title_size = 1.0f;
    private const float Title_OFFSET = 0.5F;

    private int slectionX = -1;//nothing is selected
    private int slectionY = -1;

    private void Update()
    {
        DrawCheesBoard();
        UpdateSelection();


    }

    private void UpdateSelection()
    {
        if (!Camera.main)
            return;
        RaycastHit hit;
        //if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit,25.0f)) 
    }
    private void DrawCheesBoard()
    {
        Vector3 widthLine = Vector3.right * 8;
        Vector3 heigthLine = Vector3.forward * 8;
        for (int i = 0; i <= 8; i++)
        {
            Vector3 start = Vector3.forward * i;
            Debug.DrawLine(start, start + widthLine);
            for (int j = 0; j <= 8; j++)
            {
                Vector3 start1 = Vector3.right * j;
                Debug.DrawLine(start1, start1 + heigthLine);
            }
        }
    }
}
