using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField]
    private GridGenerator _gridGen = null;

    [SerializeField]
    private Camera _cam = null;

    private Vector3 _viewPoint = new Vector3(0,0,0);

    public void ResizeCam()
    {
        int xPos = _gridGen.width / 2;
        int yPos = _gridGen.height / 2;

        int size = xPos + yPos;

        //sets position of cam in center of grid
        _viewPoint = new Vector3(xPos, -yPos, -10);

        //resizes cam, updates pos to center
        _cam.orthographicSize = size; 
        _cam.gameObject.transform.position = _viewPoint;
    }
}
