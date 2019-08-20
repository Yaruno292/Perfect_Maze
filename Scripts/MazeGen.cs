using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGen : MonoBehaviour
{

    [SerializeField]
    private GridGenerator _gridGen = null;

    [SerializeField]
    private Sprite _white = null;//White sprite

    private int[] _direction;//Array of possible directions

    private int j = 0;//Tries
    private int t = 0;//current start pos of i
    private int i = 0;//current pos

    public bool startGen = false;

    public void GenMaze()
    {
        _direction = new int[4];

        _direction[0] = 1; //right
        _direction[1] = -1; //left
        _direction[2] = -_gridGen.width; //up
        _direction[3] = _gridGen.width; //down

        if (_gridGen.cellList[0] != null)
        {
            i = 0;
            t = 0;
            j = 0;
            _gridGen.cellList[i].GetComponent<SpriteRenderer>().sprite = _white;
            startGen = true;
        }
    }

    //I may not use getcomponent in update....
    //Thing is the gameobject keeps changing

    private void Update()
    {
        if (startGen)
        {
            //Go random Dir
            int rand = Random.Range(0, 4);//random number
            int currentDir = _direction[rand];//sets random number to random dir

            //Check if Dir is okay
            if (i + (currentDir*2) < _gridGen.cellList.Length && i + (currentDir*2) > 0)
            {
                if (_gridGen.cellList[i + (currentDir * 2)].GetComponent<SpriteRenderer>().sprite != _white)//2 steps ahead
                {
                    if (rand > 1)//cell dir up and down
                    {
                        //Check if there is actually a cell to check for
                        if (i + currentDir + _direction[0] < _gridGen.cellList.Length && i + currentDir + _direction[0] > 0
                            && i + currentDir + _direction[1] < _gridGen.cellList.Length && i + currentDir + _direction[1] > 0)
                        {
                            //Check if the cell is white or not
                            if (_gridGen.cellList[i + currentDir + _direction[0]].GetComponent<SpriteRenderer>().sprite != _white
                            && _gridGen.cellList[i + currentDir + _direction[1]].GetComponent<SpriteRenderer>().sprite != _white)
                            {
                                //clear path
                                _gridGen.cellList[i + currentDir].GetComponent<SpriteRenderer>().sprite = _white;
                                i = i + currentDir;
                                j = 0;//resets tries if path found
                            }
                            else
                            {
                                j += 1;//if its white, add 1 to tries
                            }
                        }
                        else
                        {
                            j += 1;//if there is no cell, add 1 to tries
                        }
                    }

                    if (rand < 2)//cell dir left or right
                    {
                        //Check if cell exists
                        if (i + currentDir + _direction[2] < _gridGen.cellList.Length && i + currentDir + _direction[2] > 0
                            && i + currentDir + _direction[3] < _gridGen.cellList.Length && i + currentDir + _direction[3] > 0)
                        {
                            //Check if cell is black or white
                            if (_gridGen.cellList[i + currentDir + _direction[2]].GetComponent<SpriteRenderer>().sprite != _white
                            && _gridGen.cellList[i + currentDir + _direction[3]].GetComponent<SpriteRenderer>().sprite != _white)
                            {
                                //clear path
                                _gridGen.cellList[i + currentDir].GetComponent<SpriteRenderer>().sprite = _white;
                                i = i + currentDir;
                                j = 0;//resets tries if path found
                            }
                            else
                            {
                                j += 1;//add a try if its white
                            }
                        }
                        else
                        {
                            j += 1;//add try if cell doesnt exist
                        }
                    }
                }
                else
                {
                    j += 1;//add try if the cell ahead is white
                }
            }
            else
            {
                j += 1;//add try if cell ahead doesnt exist
            }

            Debug.Log("try: " + j + " : " + "cell: " + i);
            //Check if reached dead end, then start new line
            //if tries reach 8, start a new line
            if (j >= 8)
            {
                //Check if its not the end of grid
                if (t < _gridGen.cellList.Length)
                {
                    Debug.Log("reached end");
                    t++;
                    i = t + 1;
                    j = 0;
                }
                else
                {
                    //End of grid. stop making maze
                    startGen = false;
                }
            }
            

            //I tried making a check surroundings for white tiles first
            //but the tries were easier and quicker to make.

            /*
            //Check if last cell, then scan for open spots
            for (int l = 0; l < 4; l++)
            {
                Debug.Log(j);
                if (_gridGen.cellList[i + (_direction[l]*2)].GetComponent<SpriteRenderer>().sprite == _white 
                    || _gridGen.cellList[i + (_direction[l] * 2)].GetComponent<SpriteRenderer>().sprite == null)
                {
                    j += 1;
                }
                                
                if (j == 4)
                {
                    Debug.Log("reached end");
                    for (int t = 0; t < _gridGen.cellList.Length; t++)
                    {
                        if (_gridGen.cellList[j].GetComponent<SpriteRenderer>().sprite != _white)
                        {
                            i = t + 1;
                            break;
                        }
                    }
                }
            }
            */
        }
    }
}
