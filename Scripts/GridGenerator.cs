using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    private CameraView _camView = null;

    [SerializeField]
    private MazeGen _mazeGen = null;

    [SerializeField]
    private GameObject _cell = null; //Get cell prefab

    [SerializeField]
    private Slider _inputWidth = null;
    [SerializeField]
    private Slider _inputHeight = null;

    public GameObject[] cellList;//array for cells

    public int width = 3;
    public int height = 3;

    private int _num = 0;


    public void UpdateSize()
    {
        //updates the values of the grid size
        width = (int)_inputWidth.value;
        height = (int)_inputHeight.value;
    }

    public void GenerateGrid()
    {
        //clears grid before creating new one
        ClearGrid();

        _num = 0;
        //Sets the lenght of array
        cellList = new GameObject[width*height];

        //double for loop to generate 2d grid
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                //create object and add to array
                GameObject _cellObj = Instantiate(_cell, transform);
                _cellObj.transform.position = new Vector2(j,-i);
                cellList[_num] = _cellObj;
                _num += 1;
            }
        }

        //resize cam after new grid gen
        _camView.ResizeCam();
    }

    public void ClearGrid()
    {
        //stops current maze gen update
        _mazeGen.startGen = false;

        //Clears all cells
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
        //could also use for loop through the array. and destroy them that way
    }
}
