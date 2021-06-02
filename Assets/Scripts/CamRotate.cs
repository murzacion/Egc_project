using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 mPrevPos = Vector3.zero;
    Vector3 mPosdelta = Vector3.zero;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            mPosdelta = Input.mousePosition - mPrevPos;
            if (Vector3.Dot(transform.up, Vector3.up) >= 0) 
            {
                transform.Rotate(transform.up, -Vector3.Dot(mPosdelta, Camera.main.transform.right), Space.World);
            }
            else
            {
                transform.Rotate(transform.up, Vector3.Dot(mPosdelta, Camera.main.transform.right), Space.World);
            }
         
            transform.Rotate(Camera.main.transform.right, Vector3.Dot(mPosdelta, Camera.main.transform.up),Space.World);
        }

        mPrevPos = Input.mousePosition;
    }
}
